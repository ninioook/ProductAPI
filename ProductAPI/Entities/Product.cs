﻿namespace ProductAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}