using Microsoft.AspNetCore.Mvc;
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
            InitArbetsPass(viewModel);

            
            ViewBag.count = 0;
            ViewBag.modalId = "";

            if (iDate.Year != 0001)
            {

                viewModel.dayData.FirstDayOfWeek = DateMapper(iDate, viewModel);
                viewModel.dayData.FullDate = iDate;

            } else
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                viewModel.dayData.FullDate = date;
                viewModel.dayData.FirstDayOfWeek = DateMapper(date, viewModel);
            }
            
            



            return View(viewModel);
        }

        public int DateMapper(DateTime date, ViewModel viewModel)
        {

            string day = date.DayOfWeek.ToString();
            viewModel.dayData.Days = DateTime.DaysInMonth(date.Year, date.Month);
            //viewModel.dayData.MonthName = DateTime.GetMonth


            int number = 0;

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
            DateTime date1 = new DateTime(2020, 01, 01);
            DateTime date2 = new DateTime(2020, 01, 02);
            DateTime date3 = new DateTime(2020, 01, 07);
            DateTime date4 = new DateTime(2020, 01, 06);
            DateTime date5 = new DateTime(2020, 01, 22);
            DateTime date6 = new DateTime(2020, 01, 10);


            ArbetsPass arb1 = new ArbetsPass(1, date1, 1, "Reception");
            ArbetsPass arb2 = new ArbetsPass(1, date2, 1, "Städare");
            ArbetsPass arb3 = new ArbetsPass(1, date3, 2, "Reception");
            ArbetsPass arb4 = new ArbetsPass(1, date4, 2, "Förberedelse");
            ArbetsPass arb5 = new ArbetsPass(1, date5, 3, "Förberedelse");
            ArbetsPass arb6 = new ArbetsPass(1, date6, 3, "Vakt");

            viewModel.arbetspassList.Add(arb1);
            viewModel.arbetspassList.Add(arb2);
            viewModel.arbetspassList.Add(arb3);
            viewModel.arbetspassList.Add(arb4);
            viewModel.arbetspassList.Add(arb5);
            viewModel.arbetspassList.Add(arb6);
        }
    }
}
