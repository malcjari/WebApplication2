using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(DateTime iDate)
        {

            ViewModel viewModel = new ViewModel();
            //Skapar alla arbetspass och lägger i viewModelListan
            InitArbetsPass(viewModel);

            
            ViewBag.count = 0;


            //Om ett datum skickas med i metoden körs detta
            if (iDate.Year != 0001)
            {
                //Slänger in valt datum i DateMapper som plockar ut relevanta värden
                viewModel.dayData.FirstDayOfWeek = DateMapper(iDate, viewModel);
                viewModel.dayData.FullDate = iDate;
                

            } else
            {
                //Om inget datum har valts, körs denna med dagens datum. Detta är default


                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                viewModel.dayData.FullDate = date;
                viewModel.dayData.FirstDayOfWeek = DateMapper(date, viewModel);
            }



            //Initierar och skapar select listor för formuläret
            Dictionary<int, string> shiftDict = InitShiftList();
            SelectList shiftList = new SelectList(shiftDict, "Key", "Value");
            Dictionary<int, string> taskDict = InitTaskList();
            SelectList taskList = new SelectList(taskDict, "Key", "Value");


            ViewBag.shiftList = shiftList;
            ViewBag.taskList = taskList;

            return View(viewModel);
        }

        public int DateMapper(DateTime date, ViewModel viewModel)
        {
            //Hämtar månadens första dag
            string day = date.DayOfWeek.ToString();
            //Hämtar antalet dagar i månaden
            viewModel.dayData.Days = DateTime.DaysInMonth(date.Year, date.Month);
            //Hämtar månadens namn i en sträng för användning i kalenderns header
            viewModel.dayData.MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);


            int number = 0;


            //Gör om månadens första dag till ett värde som gör att kalenderna synkas rätt och startar på rätt ställe
            switch (day)
            {
                case "Monday":
                    number = 0;
                    break;
                case "Tuesday":
                    number = 1;
                    break;
                case "Wenesday":
                    number = 2;
                    break;
                case "Thursday":
                    number = 3;
                    break;
                case "Friday":
                    number = 4;
                    break;
                case "Saturday":
                    number = 5;
                    break;
                case "Sundday":
                    number = 6;
                    break;
            }

            return number;
        }

        public void InitArbetsPass(ViewModel viewModel)
        {
            DateTime date1 = new DateTime(2020, 2, 1);
            DateTime date2 = new DateTime(2020, 2, 02);
            DateTime date3 = new DateTime(2020, 2, 07);
            DateTime date4 = new DateTime(2020, 2, 06);
            DateTime date5 = new DateTime(2020, 2, 22);
            DateTime date6 = new DateTime(2020, 2, 10);


            ArbetsPass arb1 = new ArbetsPass(1, date1, 1, "Reception");
            ArbetsPass arb2 = new ArbetsPass(1, date2, 1, "Städare");
            ArbetsPass arb3 = new ArbetsPass(1, date3, 2, "Reception");
            ArbetsPass arb4 = new ArbetsPass(1, date4, 2, "Förberedelse");
            ArbetsPass arb5 = new ArbetsPass(1, date5, 3, "Förberedelse");
            ArbetsPass arb6 = new ArbetsPass(1, date6, 3, "Vakt");
            ArbetsPass arb7 = new ArbetsPass(1, date1, 2, "Vakt");

            viewModel.arbetspassList.Add(arb1);
            viewModel.arbetspassList.Add(arb2);
            viewModel.arbetspassList.Add(arb3);
            viewModel.arbetspassList.Add(arb4);
            viewModel.arbetspassList.Add(arb5);
            viewModel.arbetspassList.Add(arb6);
            viewModel.arbetspassList.Add(arb7);
        }

        public Dictionary<int, string> InitShiftList()
        {
            Dictionary<int, string> returnList = new Dictionary<int, string>();

            returnList.Add(1, "Day");
            returnList.Add(2, "Evening");
            returnList.Add(0, "Night");

            return returnList;
        }

        public Dictionary<int, string> InitTaskList()
        {
            Dictionary<int, string> returnList = new Dictionary<int, string>();

            returnList.Add(1, "Reception");
            returnList.Add(2, "Cleaning");

            return returnList;
        }
    }
}
