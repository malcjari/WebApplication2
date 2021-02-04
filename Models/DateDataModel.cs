using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class DateDataModel
    {
        public int Days { get; set; }
        public int FirstDayOfWeek { get; set; }
        public DateTime FullDate { get; set; }

        public DateTime ClickedFullDate { get; set; }
        public string MonthName { get; set; }
    }
}
