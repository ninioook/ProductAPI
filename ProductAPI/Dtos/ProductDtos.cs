namespace ProductAPI.Dtos
{
    public class ProductListItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }

    public class ProductCategoryListItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}