namespace LuxWatch.Model
{
    using System.ComponentModel.DataAnnotations;
    public class Material
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
