using System.Linq;
using Microsoft.AspNet.Mvc;
using SportsLeagueOrganizer.Models;


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
    }
}


