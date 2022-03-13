namespace LuxWatch.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
