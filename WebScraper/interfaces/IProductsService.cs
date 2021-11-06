namespace WebScraper
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task<IList<Item>> GetAllItems(string pagePath);

        Task PrintProducts(string pagePath);
    }
}
