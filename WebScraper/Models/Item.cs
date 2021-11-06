namespace WebScraper
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Item
    {
        private string productName;
        private string price;
        private decimal rating;
        private const decimal maxRating = (decimal)5.0;

        public Item(string productName, string price, decimal rating)
        {
            this.productName = productName;
            this.price = price;
            this.rating = rating;
        }


        [Required]
        public string ProductName
        {
            get => productName;
            set => productName = value;
        }

        [Required]
        public string Price
        {
            get => price;
            set => price = value;
        }

        [Required]
        public decimal Rating
        {
            get
            {
                return this.rating;
            }
            set
            {
                if (value > maxRating)
                {
                    value = RatingNormalization(value);
                }

                this.rating = value;
            }
        }


        private decimal RatingNormalization(decimal value)
        {
            var normalizatedRating = Math.Round((value / 10) * 5, 1);
            return normalizatedRating;
        }
    }
}
