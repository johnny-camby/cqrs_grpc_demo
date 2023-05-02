
using BusinessLogic.Exceptions;
using MediatR;
using XmlDataExtractManager.Interfaces;

namespace BusinessLogic.CQRS.FileUpload.Commands.Import
{
    public class FileUploadCommandHandler : IRequestHandler<FileUploadCommandRequest>
    {
        private readonly IBufferedFileUploadService _bufferedFileUploadService;
        private readonly IXmlDataExtractorService _xmlDataExtractorService;

        public FileUploadCommandHandler(IBufferedFileUploadService bufferedFileUploadService,
            IXmlDataExtractorService xmlDataExtractorService)
        {
            _bufferedFileUploadService = bufferedFileUploadService;
            _xmlDataExtractorService = xmlDataExtractorService;
        }

        public async Task<Unit> Handle(FileUploadCommandRequest request, CancellationToken cancellationToken)
        {
            (bool isExisting, string xmlfile) = await _bufferedFileUploadService.UploadFile(request.File);

            if (isExisting && !string.IsNullOrEmpty(xmlfile))
            {
                await _xmlDataExtractorService.ProcessXmlAsync(xmlfile);
            }
            else
            {
                throw new NotFoundException(nameof(request.File), request.File);
            }
            return Unit.Value;
        }
    }
}
