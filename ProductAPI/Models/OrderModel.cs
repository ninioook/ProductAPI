﻿namespace ProductAPI.Models
{
    public class AddOrderModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}