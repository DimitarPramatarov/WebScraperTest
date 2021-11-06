namespace WebScraper
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class FileReader : IFileReader
    {
        public async Task<string> ReadPageFromFile(string path)
        {
            if(path is null)
            {
                throw new ArgumentNullException("Path cannot be empty");
            }

            var page = await File.ReadAllTextAsync(path);

            return page;
        }
    }
}
