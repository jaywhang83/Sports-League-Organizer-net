using System.Linq;
using Microsoft.AspNet.Mvc;
using SportsLeagueOrganizer.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

namespace SportsLeagueOrganizer.Controllers
{
    public class TeamsController : Controller
    {
        // GET: /<controller>/
        private SportsLeagueOrganizerContext db = new SportsLeagueOrganizerContext();
        public IActionResult Index()
        {
            return View(db.Teams.Include(x => x.Division).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            return View(thisTeam);
        }

        //New Team
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Team
        public ActionResult Edit(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name"); 
            return View(thisTeam);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Team
        public ActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            return View(thisTeam);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            db.Teams.Remove(thisTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


