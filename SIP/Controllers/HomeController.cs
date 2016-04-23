using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIP.Models;

namespace SIP.Controllers
{
    public class HomeController : Controller
    {
        private SIPEntities db = new SIPEntities();
        public ActionResult Index([Bind(Include = "NoPolisi")] Kendaraan kendaraan)
        {
            //ViewBag.ProvinsiID = new SelectList(db.Provinsi, "ID", "Nama");
            //ViewBag.KotaID = new SelectList(db.Kota, "ID", "Nama");
            //ViewBag.SamsatID = new SelectList(db.Samsat, "ID", "Nama");
            if (kendaraan.NoPolisi != null && kendaraan.NoPolisi != "")
            {
                kendaraan = db.Kendaraan.Where(x=>x.NoPolisi== kendaraan.NoPolisi).FirstOrDefault();
                return View("~/Views/Home/Details.cshtml", kendaraan);
            }
            else
                return View();
        }
    }
}