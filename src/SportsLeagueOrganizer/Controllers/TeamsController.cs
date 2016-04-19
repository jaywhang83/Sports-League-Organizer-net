using System.Linq;
using Microsoft.AspNet.Mvc;
using SportsLeagueOrganizer.Models;
using Microsoft.Data.Entity;

namespace SportsLeagueOrganizer.Controllers
{
    public class TeamsController : Controller
    {
        // GET: /<controller>/
        private SportsLeagueOrganizerContext db = new SportsLeagueOrganizerContext();
        public IActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            return View(thisTeam);
        }

        //New Team
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Team
        public IActionResult Edit(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            return View(thisTeam);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Team
        public IActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            return View(thisTeam);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(x => x.TeamId == id);
            db.Teams.Remove(thisTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


