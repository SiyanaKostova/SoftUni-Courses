using SoftUniBazar.Data;
using System;

namespace SoftUniBazar.Models
{
    public class AllAdsViewModel
    {
        public AllAdsViewModel(int id, string name, string imageUrl, string category, DateTime createdOn, string description, decimal price, string owner)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Category = category;
            CreatedOn = createdOn.ToString(DataConstants.DateFormat);
            Description = description;
            Price = price;
            Owner = owner;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string CreatedOn { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Owner { get; set; }
    }
}