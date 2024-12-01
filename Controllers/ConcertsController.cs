using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TP3.Models;

namespace TP3.Controllers
{
    public class ConcertsController : Controller
    {
        private static List<Concert> concerts = new List<Concert>()
        {
            new Concert { Id = 1, Title = "Ziara by Sami Lajmi", Artist = "Ziara", Date = DateTime.Now.AddDays(10), Location = "Carthage Amphitheatre", TicketPrice = 50 },
            new Concert { Id = 2, Title = "Rap night", Artist = "Redstar", Date = DateTime.Now.AddDays(20), Location = "Carthage Amphitheatre", TicketPrice = 75 }
        };

        // GET: ConcertsController
        public ActionResult Index()
        {
            return View(concerts);
        }

        // GET: ConcertsController/Details/5
        public ActionResult Details(int id)
        {
            var concert = concerts[id-1];
            if (concert == null) return NotFound();
            return View(concert);
        }

        // GET: ConcertsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConcertsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Concert concert)
        {
            if (ModelState.IsValid)
            {
                concert.Id = concerts.Count+1;
                concerts.Add(concert);
                return RedirectToAction("Index");
            }
            return View(concert);
        }

        // GET: ConcertsController/Edit/5
        public ActionResult Edit(int id)
        {
            var concert = concerts[id-1];
            if (concert == null) return NotFound();
            return View(concert);
        }

        // POST: ConcertsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Concert newConcert)
        {
            var concert = concerts[id-1];
            if (concert == null) return NotFound();
            if (ModelState.IsValid)
            {
                concert.Title = newConcert.Title;
                concert.Artist = newConcert.Artist;
                concert.Date = newConcert.Date;
                concert.Location = newConcert.Location;
                concert.TicketPrice = newConcert.TicketPrice;
                return RedirectToAction("Index");
            }
            return View(concert);
        }

        // GET: ConcertsController/Delete/5
        public ActionResult Delete(int id)
        {
            var concert = concerts[id - 1];
            if (concert == null) return NotFound();
            concerts.Remove(concert);
            return RedirectToAction("Index");
        }

        // POST: ConcertsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
            
        //}
    }
}
