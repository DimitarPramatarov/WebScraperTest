namespace WebScraper
{
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            const string pagePath = "~/../../../../htmlFile/page.html";

            IProductsService productsService = new ProductsService();
            await productsService.PrintProducts(pagePath);
        }
    }
}
