namespace WebScraper
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AngleSharp;

    public class HtmlParser : IHtmlParser
    {
        public async Task<IList<Item>> ParseHtml(string page)
        {
            var config = Configuration.Default;
            using var context = BrowsingContext.New(config);
            using var doc = await context.OpenAsync(req => req.Content(page));

            var items = doc.QuerySelectorAll("div[class='item']");

            IList<Item> products = new List<Item>();

            foreach (var item in items)
            {
                var productName = item
                     .QuerySelector("img")
                     .GetAttribute("alt");

                var ratingElement = double
                     .Parse(item.GetAttribute("rating"))
                     .ToString();
                
                decimal rating;
                decimal.TryParse(ratingElement, out rating);


                var price = item
                    .QuerySelector("span[style='display: none']")
                    .TextContent
                    .ToString()
                    .Replace(",", "")    
                    .Trim(new Char[] {'$', '.'});


                var product = new Item(productName, price, rating)
                {
                    ProductName = productName,
                    Price = price,
                    Rating = rating,

                };
                products.Add(product);
            }

            return products;
        }

    }
}
