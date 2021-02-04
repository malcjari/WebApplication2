using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ViewModel
    {
        public ArbetsPass arbetspass { get; set; }

        public List<ArbetsPass> arbetspassList { get; set; }

        public DateDataModel dayData { get; set; }

        public ViewModel()
        {

            this.arbetspass = new ArbetsPass();
            this.arbetspassList = new List<ArbetsPass>();
            this.dayData = new DateDataModel();
        }
    }
}
