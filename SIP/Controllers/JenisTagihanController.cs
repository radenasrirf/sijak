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
    public class JenisTagihanController : Controller
    {
        private SIPEntities db = new SIPEntities();

        // GET: /JenisTagihan/
        public ActionResult Index()
        {
            return View(db.JenisTagihan.ToList());
        }

        // GET: /JenisTagihan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenisTagihan jenistagihan = db.JenisTagihan.Find(id);
            if (jenistagihan == null)
            {
                return HttpNotFound();
            }
            return View(jenistagihan);
        }

        // GET: /JenisTagihan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /JenisTagihan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nama,PersenDenda")] JenisTagihan jenistagihan)
        {
            if (ModelState.IsValid)
            {
                db.JenisTagihan.Add(jenistagihan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jenistagihan);
        }

        // GET: /JenisTagihan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenisTagihan jenistagihan = db.JenisTagihan.Find(id);
            if (jenistagihan == null)
            {
                return HttpNotFound();
            }
            return View(jenistagihan);
        }

        // POST: /JenisTagihan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nama,PersenDenda")] JenisTagihan jenistagihan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jenistagihan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jenistagihan);
        }

        // GET: /JenisTagihan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenisTagihan jenistagihan = db.JenisTagihan.Find(id);
            if (jenistagihan == null)
            {
                return HttpNotFound();
            }
            return View(jenistagihan);
        }

        // POST: /JenisTagihan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JenisTagihan jenistagihan = db.JenisTagihan.Find(id);
            db.JenisTagihan.Remove(jenistagihan);
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
