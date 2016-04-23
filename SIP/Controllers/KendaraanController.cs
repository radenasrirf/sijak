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
    public class KendaraanController : Controller
    {
        private SIPEntities db = new SIPEntities();

        // GET: /Kendaraan/
        public ActionResult Index()
        {
            var kendaraan = db.Kendaraan.Include(k => k.BahanBakar).Include(k => k.JenisKendaraan).Include(k => k.Merek).Include(k => k.PemilikKendaraan).Include(k => k.Samsat).Include(k => k.Tagihan).Include(k => k.Warna).Include(k => k.Warna1);
            return View(kendaraan.ToList());
        }

        // GET: /Kendaraan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendaraan kendaraan = db.Kendaraan.Find(id);
            if (kendaraan == null)
            {
                return HttpNotFound();
            }
            return View(kendaraan);
        }

        // GET: /Kendaraan/Create
        public ActionResult Create()
        {
            ViewBag.BahanBakarID = new SelectList(db.BahanBakar, "ID", "Nama");
            ViewBag.JenisKendaraanID = new SelectList(db.JenisKendaraan, "ID", "Jenis");
            ViewBag.MerekID = new SelectList(db.Merek, "ID", "Nama");
            ViewBag.PemilikKendaraanID = new SelectList(db.PemilikKendaraan, "ID", "Nama");
            ViewBag.SamsatID = new SelectList(db.Samsat, "ID", "Nama");
            ViewBag.PemilikKendaraanID = new SelectList(db.Tagihan, "ID", "ID");
            ViewBag.WarnaID = new SelectList(db.Warna, "ID", "Nama");
            ViewBag.WarnaTNKBID = new SelectList(db.Warna, "ID", "Nama");
            return View();
        }

        // POST: /Kendaraan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PemilikKendaraanID,SamsatID,MerekID,JenisKendaraanID,WarnaID,WarnaTNKBID,BahanBakarID,NoPolisi,Tipe,TahunPembuatan,TahunPerakitan,IsiSilinder,NoMesin,NoRangka,NoBPKB")] Kendaraan kendaraan)
        {
            if (ModelState.IsValid)
            {
                db.Kendaraan.Add(kendaraan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BahanBakarID = new SelectList(db.BahanBakar, "ID", "Nama", kendaraan.BahanBakarID);
            ViewBag.JenisKendaraanID = new SelectList(db.JenisKendaraan, "ID", "Jenis", kendaraan.JenisKendaraanID);
            ViewBag.MerekID = new SelectList(db.Merek, "ID", "Nama", kendaraan.MerekID);
            ViewBag.PemilikKendaraanID = new SelectList(db.PemilikKendaraan, "ID", "Nama", kendaraan.PemilikKendaraanID);
            ViewBag.SamsatID = new SelectList(db.Samsat, "ID", "Nama", kendaraan.SamsatID);
            ViewBag.PemilikKendaraanID = new SelectList(db.Tagihan, "ID", "ID", kendaraan.PemilikKendaraanID);
            ViewBag.WarnaID = new SelectList(db.Warna, "ID", "Nama", kendaraan.WarnaID);
            ViewBag.WarnaTNKBID = new SelectList(db.Warna, "ID", "Nama", kendaraan.WarnaTNKBID);
            return View(kendaraan);
        }

        // GET: /Kendaraan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendaraan kendaraan = db.Kendaraan.Find(id);
            if (kendaraan == null)
            {
                return HttpNotFound();
            }
            ViewBag.BahanBakarID = new SelectList(db.BahanBakar, "ID", "Nama", kendaraan.BahanBakarID);
            ViewBag.JenisKendaraanID = new SelectList(db.JenisKendaraan, "ID", "Jenis", kendaraan.JenisKendaraanID);
            ViewBag.MerekID = new SelectList(db.Merek, "ID", "Nama", kendaraan.MerekID);
            ViewBag.PemilikKendaraanID = new SelectList(db.PemilikKendaraan, "ID", "Nama", kendaraan.PemilikKendaraanID);
            ViewBag.SamsatID = new SelectList(db.Samsat, "ID", "Nama", kendaraan.SamsatID);
            ViewBag.PemilikKendaraanID = new SelectList(db.Tagihan, "ID", "ID", kendaraan.PemilikKendaraanID);
            ViewBag.WarnaID = new SelectList(db.Warna, "ID", "Nama", kendaraan.WarnaID);
            ViewBag.WarnaTNKBID = new SelectList(db.Warna, "ID", "Nama", kendaraan.WarnaTNKBID);
            return View(kendaraan);
        }

        // POST: /Kendaraan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PemilikKendaraanID,SamsatID,MerekID,JenisKendaraanID,WarnaID,WarnaTNKBID,BahanBakarID,NoPolisi,Tipe,TahunPembuatan,TahunPerakitan,IsiSilinder,NoMesin,NoRangka,NoBPKB")] Kendaraan kendaraan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kendaraan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BahanBakarID = new SelectList(db.BahanBakar, "ID", "Nama", kendaraan.BahanBakarID);
            ViewBag.JenisKendaraanID = new SelectList(db.JenisKendaraan, "ID", "Jenis", kendaraan.JenisKendaraanID);
            ViewBag.MerekID = new SelectList(db.Merek, "ID", "Nama", kendaraan.MerekID);
            ViewBag.PemilikKendaraanID = new SelectList(db.PemilikKendaraan, "ID", "Nama", kendaraan.PemilikKendaraanID);
            ViewBag.SamsatID = new SelectList(db.Samsat, "ID", "Nama", kendaraan.SamsatID);
            ViewBag.PemilikKendaraanID = new SelectList(db.Tagihan, "ID", "ID", kendaraan.PemilikKendaraanID);
            ViewBag.WarnaID = new SelectList(db.Warna, "ID", "Nama", kendaraan.WarnaID);
            ViewBag.WarnaTNKBID = new SelectList(db.Warna, "ID", "Nama", kendaraan.WarnaTNKBID);
            return View(kendaraan);
        }

        // GET: /Kendaraan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kendaraan kendaraan = db.Kendaraan.Find(id);
            if (kendaraan == null)
            {
                return HttpNotFound();
            }
            return View(kendaraan);
        }

        // POST: /Kendaraan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kendaraan kendaraan = db.Kendaraan.Find(id);
            db.Kendaraan.Remove(kendaraan);
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
