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
                dbc.LuckyNumbers.Add(userLuck);
                dbc.SaveChanges();
                Session["_ID"] = userLuck.Id;
                return RedirectToAction("Spin", userLuck);
            }
            return View();
        }
        // GET: LuckyNumber
        [HttpGet]
        public ActionResult Spin()
        {
            LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };
            if (Session["_ID"] != null)
            {
                myLuck = dbc.LuckyNumbers.Find((int)Session["_ID"]);
                return View(myLuck);
            }
            else
            {
                return View(myLuck);
            }
        }

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky)
        {
            LuckyNumber databaseLuck = dbc.LuckyNumbers.Find((int)Session["_ID"]);
            LuckyNumber tempLuck = new LuckyNumber();
            if (databaseLuck.Balance > 0)
            {
                databaseLuck.Balance -= 1;
            }
            databaseLuck.Balance = databaseLuck.Balance + tempLuck.Balance;
            //Change the Balance in the database
            dbc.SaveChanges();
            return View(databaseLuck);
        }
    }
}