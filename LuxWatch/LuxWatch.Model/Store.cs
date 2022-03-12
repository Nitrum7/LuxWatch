namespace LuxWatch.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = "LuxWatch";
        [Required]
        public int CityId { get; set; }
        public virtual City City{ get; set; }
        public virtual ICollection<Watch> Watches { get; set; } = new HashSet<Watch>();
    }
}
