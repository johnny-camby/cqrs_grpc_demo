

using Microsoft.AspNetCore.Http;

namespace XmlDataExtractManager.Interfaces
{
    public interface IBufferedFileUploadService
    {
        Task<(bool, string)> UploadFile(IFormFile file);
    }
}
