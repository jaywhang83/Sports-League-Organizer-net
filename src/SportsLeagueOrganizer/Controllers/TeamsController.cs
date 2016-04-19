using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SportsLeagueOrganizer.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
    }
}
