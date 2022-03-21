using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxWatch.Web.App.Models
{
    public class IndexWatchesViewModel
    {
        public ICollection<IndexWatchViewModel> Watches { get; set; }
        public int WatchesCount { get; set; }
    }
}
