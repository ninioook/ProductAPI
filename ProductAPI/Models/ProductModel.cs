using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }

    public class UpdateProductModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }

    public class DeleteProductModel
    {
        [Required]
        public int Id { get; set; }
    }
}