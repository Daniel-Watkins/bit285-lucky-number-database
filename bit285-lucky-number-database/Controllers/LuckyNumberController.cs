using bit285_lucky_number_database.Models;
using lucky_number_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bit285_lucky_number_database.Controllers
{
    public class LuckyNumberController : Controller
    {
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LuckyNumber userLuck)
        {
            if (ModelState.IsValid)
            {
                Session["_ID"] = userLuck.Id;
                dbc.LuckyNumbers.Add(userLuck);
                dbc.SaveChanges();
                return View("Spin", userLuck);
            }
            return View();
        }
        // GET: LuckyNumber
        public ActionResult Spin()
        {
            /*LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };
            dbc.LuckyNumbers.Add(myLuck);
            dbc.SaveChanges();*/
            //LuckyNumber databaseLuck = dbc.LuckyNumbers.Where(m => m.Id == Convert.ToInt32(Session["_ID"])).First();
            return View();
        }

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky)
        {
            LuckyNumber databaseLuck = dbc.LuckyNumbers.Where(m=>m.Id == Convert.ToInt32(Session["_ID"])).First();
            //Change the Balance in the database
            if(databaseLuck.Balance>0)
            {
                databaseLuck.Balance -= 1;
            }
            databaseLuck.Number = lucky.Number;
            dbc.SaveChanges();
            return View(databaseLuck);
        }
    }
}