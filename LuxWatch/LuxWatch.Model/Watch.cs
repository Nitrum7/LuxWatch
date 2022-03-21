namespace LuxWatch.Model
{
    using System.ComponentModel.DataAnnotations;
    public class Watch
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(12)]
        public string RefNum { get; set; }
        [Required]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
