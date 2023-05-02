
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.CQRS.FileUpload.Commands.Import
{
    public class FileUploadCommandRequest : IRequest
    {
        public IFormFile? File { get; set; }
    }
}
