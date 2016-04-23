using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIP.Models;

namespace SIP.Controllers
{
    public class PemilikKendaraanController : Controller
    {
        private SIPEntities db = new SIPEntities();

        // GET: /PemilikKendaraan/
        public ActionResult Index()
        {
            return View(db.PemilikKendaraan.ToList());
        }

        // GET: /PemilikKendaraan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PemilikKendaraan pemilikkendaraan = db.PemilikKendaraan.Find(id);
            if (pemilikkendaraan == null)
            {
                return HttpNotFound();
            }
            return View(pemilikkendaraan);
        }

        // GET: /PemilikKendaraan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PemilikKendaraan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,NoKTP,NoNPWP,Nama,Alamat,KodePos")] PemilikKendaraan pemilikkendaraan)
        {
            if (ModelState.IsValid)
            {
                db.PemilikKendaraan.Add(pemilikkendaraan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pemilikkendaraan);
        }

        // GET: /PemilikKendaraan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PemilikKendaraan pemilikkendaraan = db.PemilikKendaraan.Find(id);
            if (pemilikkendaraan == null)
            {
                return HttpNotFound();
            }
            return View(pemilikkendaraan);
        }

        // POST: /PemilikKendaraan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,NoKTP,NoNPWP,Nama,Alamat,KodePos")] PemilikKendaraan pemilikkendaraan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pemilikkendaraan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pemilikkendaraan);
        }

        // GET: /PemilikKendaraan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PemilikKendaraan pemilikkendaraan = db.PemilikKendaraan.Find(id);
            if (pemilikkendaraan == null)
            {
                return HttpNotFound();
            }
            return View(pemilikkendaraan);
        }

        // POST: /PemilikKendaraan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PemilikKendaraan pemilikkendaraan = db.PemilikKendaraan.Find(id);
            db.PemilikKendaraan.Remove(pemilikkendaraan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
