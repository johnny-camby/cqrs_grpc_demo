using BusinessLogic.CQRS.FileUpload.Commands.Import;
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
        private readonly CustomerDataClient  _client;
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
            catch(Exception ex )
            {
                _logger.LogError($"error {ex.Message}");
            }           

            return View(data.Customers);
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
                    //Log
                }
            }
            return RedirectToAction(nameof(Index));
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