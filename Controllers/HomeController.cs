using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.Data.Entity;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        WaterMetrContext db = new WaterMetrContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты WaterMetr
            IEnumerable<WaterMetr> waterMetrs = db.WaterMetrs;
            IEnumerable<Home> homes = db.Homes;
            // передаем все объекты в динамическое свойство WaterMetrs в ViewBag
            ViewBag.WaterMetrs = waterMetrs;
            ViewBag.Homes = homes;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(WaterMetr waterMetr)
        {
            // добавляем информацию о покупке в базу данных
            db.WaterMetrs.Add(waterMetr);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + waterMetr.Number + ", добавлен!";
        }

        [HttpPost]
        public ActionResult MyAction(string Number, string Indications, string action)
        {
            if (action == "add")
            {
                WaterMetr waterMetr = new WaterMetr();
                waterMetr.Number = Convert.ToInt32(Number);
                waterMetr.Indications = Convert.ToInt32(Indications);
                db.WaterMetrs.Add(waterMetr);
                db.SaveChanges();
                // получаем из бд все объекты WaterMetr
                IEnumerable<WaterMetr> waterMetrs = db.WaterMetrs;
                // передаем все объекты в динамическое свойство WaterMetrs в ViewBag
                ViewBag.WaterMetrs = waterMetrs;
                return View();
            }
            else if (action == "delete")
            {
                WaterMetr waterMetr1 = new WaterMetr();
                waterMetr1.Number = Convert.ToInt32(Number);
                waterMetr1.Indications = Convert.ToInt32(Indications);
                db.WaterMetrs.Add(waterMetr1);
                return View();
            }
            WaterMetr waterMetr2 = new WaterMetr();
            waterMetr2.Number = Convert.ToInt32(Number);
            waterMetr2.Indications = Convert.ToInt32(Indications);
            db.WaterMetrs.Add(waterMetr2);
            return View();
        }
        [HttpPost]
        /// <summary>Добавляет в БД дом</summary>
        public ActionResult AddHome(string Address, string action)
        {
            if (action == "add")
            {
                IEnumerable<Home> homes = db.Homes;
                if (homes.Any(h => h.Address == Address))
                {
                    ViewBag.Homes = homes;
                    return View();
                }
                   
                Home home = new Home();
                home.Address = Address;
                db.Homes.Add(home);
                db.SaveChanges();
                ViewBag.Homes = homes;
                return View();
            }
            return View();
        }

        [HttpPost]
        /// <summary>Удаляет из БД дом по Id</summary>
        public ActionResult RemoveHome(string HomeId, string action)
        {
            if (action == "remove")
            {
                IEnumerable<Home> homes = db.Homes;
                var dh = homes.FirstOrDefault(h => h.Id == Convert.ToInt32(HomeId));
                if (dh != null)
                {
                    db.Homes.Remove(dh);
                    db.SaveChanges();
                    ViewBag.Homes = homes;
                    return View();
                }
                ViewBag.Homes = homes;
                return View();
            }
            return View();
        }

        [HttpPost]
        /// <summary>Ищет дом по Id </summary>
        public ActionResult FindHome(string HomeId, string action)
        {
            if (action == "find")
            {
                IEnumerable<Home> homes = db.Homes;
                var dh = homes.FirstOrDefault(h => h.Id == Convert.ToInt32(HomeId));
                if (dh != null)
                {
                    ViewBag.Homes = dh;
                    return View();
                }
                return View();
            }
            return View();
        }


        public ActionResult ListWaterMetrs()
        {
            var waterMetrs = db.WaterMetrs.Include(p=> p.Home);
            return View(waterMetrs.ToList());
        }

    }
}