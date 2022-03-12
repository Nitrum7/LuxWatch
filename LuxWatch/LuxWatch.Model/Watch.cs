namespace LuxWatch.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Watch
    {
        public string RefNum { get; set; }
        [Required]
        [MaxLength(12)]
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Size { get; set; }
        public string Material { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Store> Stores { get; set; } = new HashSet<Store>();
    }
}
