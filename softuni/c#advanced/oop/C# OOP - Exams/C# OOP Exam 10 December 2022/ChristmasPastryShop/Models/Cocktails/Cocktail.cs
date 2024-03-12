using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }
        private string name;

        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value; 
            }
        }

        private string size;

        public string Size
        {
            get => size;
            private set
            { 
                size = value;
            }
        }

        private double price;

        public double Price
        {
            get => price;
            private set
            {
                if (this.Size == "Small")
                {
                    value /= 3;
                }
                if (this.Size == "Middle")
                {
                    value = (value / 3) * 2;
                }
                price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}
