
namespace XmlDataExtractManager.Interfaces
{
    public interface IXmlDataExtractorService
    {
        T Deserialize<T>(string input) where T : class;
        Task ProcessXmlAsync(string xmlfile);
    }
}
