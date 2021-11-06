namespace WebScraper
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHtmlParser
    {
         Task<IList<Item>> ParseHtml(string html);
    }
}
