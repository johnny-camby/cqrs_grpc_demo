using BusinessLogic.CQRS.FileUpload.Commands.Import;
using Google.Protobuf;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebXmlImporter.Models;
using XmlData.GrpcServices;
using static XmlData.GrpcServices.CustomerData;

namespace WebXmlImporter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly  CustomerDataClient _client;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger,
            CustomerDataClient client,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            CustomersResponse data = new CustomersResponse();

            try
            {
                 data = await _client.GetCustomersAsync(new CustomersRequest());
            }
            catch (Exception ex)
            {
                _logger.LogError($"error {ex.Message}");
            }

            return View(data.Customers);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var customer = await _client.GetCustomerByIdAsync(new GetCustomerByIdRequest { CustomerId = id.ToString() });

            return View(customer);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerRequest createCustomerRequest)
        {
            CreateCustomerResponse? createCustomerResponse = null;

            if (ModelState.IsValid)
            {
                createCustomerResponse = await _client.CreateNewAsync(createCustomerRequest);
                return RedirectToAction(nameof(Index));
            }

            return View(createCustomerResponse);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var customer = await _client.GetCustomerByIdAsync(new GetCustomerByIdRequest { CustomerId = id.ToString() });

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Guid id, PutCustomerRequest putCustomerRequest)
        {
            if (id == default)
            {
                return NotFound();
            }

            var customer = await _client.GetCustomerByIdAsync(new GetCustomerByIdRequest { CustomerId = id.ToString() });

            if (customer != null)
            {
                putCustomerRequest.Customer.Id = id.ToString();
                await _client.PutCustomerAsync(putCustomerRequest);
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == default)
            {
                return NotFound();
            }

            var customer = await _client.GetCustomerByIdAsync(new GetCustomerByIdRequest { CustomerId = id.ToString() });

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _client.DeleteCustomerAsync(new DeleteCustomerRequest { CustomerId = id.ToString() });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UploadXmlAsync([FromForm] FileUploadCommandRequest content)
        {

            if (content.File != null)
            {
                try
                {
                    await _mediator.Send(content);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error Uploading file: {ex.Message}");
                }


                //try
                //{
                //    
                //    //using FileStream fs = await ProcessFileStream(content);

                //    //string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                //    //if (!Directory.Exists(path))
                //    //{
                //    //    Directory.CreateDirectory(path);
                //    //}
                //    //using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                //    //{
                //    //    await file.CopyToAsync(fileStream);
                //    //}
                //    //var filePath = Path.Combine(path, file.FileName);


                //    string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                //    if (!Directory.Exists(path))
                //    {
                //        Directory.CreateDirectory(path);
                //    }

                //    Metadata md = new Metadata();
                //    var filePath = Path.Combine(path, content.File.FileName);
                //    //FileStream fs = System.IO.File.OpenRead(filePath);

                //    using var fs = new FileStream(Path.Combine(path, content.File.FileName), FileMode.Create);

                //    using var call = _client.UploadXml(md);
                //    var stream = call.RequestStream;

                //    while (true)
                //    {
                //        byte[] buffer = new byte[64 * 1024];
                //        int numRead = await fs.ReadAsync(buffer, 0, buffer.Length);

                //        if (numRead == 0)
                //        {
                //            break;
                //        }

                //        if (numRead < buffer.Length)
                //        {
                //            Array.Resize(ref buffer, numRead);
                //        }

                //        await stream.WriteAsync(new UploadXmlRequest
                //        {
                //            Data = ByteString.CopyFrom(buffer),
                //            Metadata = new FileMetadata
                //            {
                //                FileName = content.File.FileName,
                //                FilePath = filePath,
                //            }
                //        });
                //    }
                //    await stream.CompleteAsync();
                //    await call;                   
                //}
                //catch (Exception ex)
                //{
                //    //Log
                //}

            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<FileStream> ProcessFileStream(FileUploadCommandRequest content)
        {
            var call = _client.UploadXml();
            await call.RequestStream.WriteAsync(new UploadXmlRequest
            {
                Metadata = new FileMetadata
                {
                    FileName = content.File.FileName
                }
            });

            byte[] buffer = new byte[64 * 1024];
            var fs = System.IO.File.OpenRead(content.File.FileName);
            // await using var fs = new FileStream(content.File.FileName, FileMode.Open, FileAccess.Read);

            while (true)
            {
                var count = await fs.ReadAsync(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }

                if (count < buffer.Length)
                {
                    Array.Resize(ref buffer, count);
                }

                await call.RequestStream.WriteAsync(new UploadXmlRequest
                {
                    Data = UnsafeByteOperations.UnsafeWrap(buffer.AsMemory(0, count))
                });
            }
            await call.RequestStream.CompleteAsync();
            await call;
            return fs;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}