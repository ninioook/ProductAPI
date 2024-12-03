﻿namespace ProductAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}