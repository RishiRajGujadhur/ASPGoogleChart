using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPGoogleChart.Models;

namespace ASPGoogleChart.Controllers
{
    public class GoogleChartController : Controller
    {
        // GET: GoogleChart
        public ActionResult Column()
        {
            return View();
        }

        public JsonResult GetSalesData()
        {
            List<GoogleChartData> sd = new List<GoogleChartData>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                sd = dc.GoogleChartDatas.OrderBy(a => a.Year).ToList();
            }

            var chartData = new object[sd.Count + 1];
            chartData[0] = new object[]{
                    "Year",
                    "Electronics",
                    "Book And Media",
                    "Home And Kitchen"
                };
            int j = 0;
            foreach (var i in sd)
            {
                j++;
                chartData[j] = new object[] { i.Year, i.Electronics, i.BookAndMedia, i.HomeAndKitchen };
            }

            return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}