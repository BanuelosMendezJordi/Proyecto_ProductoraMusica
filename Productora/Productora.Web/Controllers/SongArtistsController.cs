using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Productora.Web.Models;

namespace Productora.Web.Controllers
{
    public class SongArtistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SongArtists
        public ActionResult Index()
        {
            var songArtists = db.SongArtists.Include(s => s.Artist).Include(s => s.Song);
            return View(songArtists.ToList());
        }

        // GET: SongArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongArtist songArtist = db.SongArtists.Find(id);
            if (songArtist == null)
            {
                return HttpNotFound();
            }
            return View(songArtist);
        }

        // GET: SongArtists/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "StageName");
            ViewBag.SongId = new SelectList(db.Songs, "Id", "SongTitle");
            return View();
        }

        // POST: SongArtists/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SongId,ArtistId")] SongArtist songArtist)
        {
            if (ModelState.IsValid)
            {
                db.SongArtists.Add(songArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "StageName", songArtist.ArtistId);
            ViewBag.SongId = new SelectList(db.Songs, "Id", "SongTitle", songArtist.SongId);
            return View(songArtist);
        }

        // GET: SongArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongArtist songArtist = db.SongArtists.Find(id);
            if (songArtist == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "StageName", songArtist.ArtistId);
            ViewBag.SongId = new SelectList(db.Songs, "Id", "SongTitle", songArtist.SongId);
            return View(songArtist);
        }

        // POST: SongArtists/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SongId,ArtistId")] SongArtist songArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(songArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "StageName", songArtist.ArtistId);
            ViewBag.SongId = new SelectList(db.Songs, "Id", "SongTitle", songArtist.SongId);
            return View(songArtist);
        }

        // GET: SongArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongArtist songArtist = db.SongArtists.Find(id);
            if (songArtist == null)
            {
                return HttpNotFound();
            }
            return View(songArtist);
        }

        // POST: SongArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SongArtist songArtist = db.SongArtists.Find(id);
            db.SongArtists.Remove(songArtist);
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
