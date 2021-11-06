namespace WebScraper
{
    using System.Threading.Tasks;
    
    public interface IFileReader
    {
        Task<string> ReadPageFromFile(string path);
    }
}
