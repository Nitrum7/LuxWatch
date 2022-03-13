using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxWatch.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Sex { get; set; }
    }
}
