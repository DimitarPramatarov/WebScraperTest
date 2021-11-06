using System.Collections.Generic;

namespace WebScraper.interfaces
{
    public interface IJsonCreator
    {
        string CreateJson(IList<Item> products);
    }
}
