namespace WebScraper
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using WebScraper.interfaces;

    public class ProductsService : IProductsService
    {

        public async Task<IList<Item>> GetAllItems(string pagePath)
        {
            if (pagePath == null)
            {
                throw new ArgumentNullException("Page path not found");
            }

            IFileReader fileReader = new FileReader();
            var page = await fileReader.ReadPageFromFile(pagePath);

            if (page == null)
            {
                throw new ArgumentNullException("Page not found");
            }

            IHtmlParser htmlParser = new HtmlParser();
            var products = await htmlParser.ParseHtml(page);


            return products;
        }

        public async Task PrintProducts(string pagePath)
        {
            var products = await GetAllItems(pagePath);

            if(products.Count == 0)
            {
                throw new ArgumentException("Products not found!");
            }

            IJsonCreator jsonCreator = new JsonCreator();
            var printJson = jsonCreator.CreateJson(products);

            Console.WriteLine(printJson);
        }
    }
}
