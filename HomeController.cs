using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeauges =  _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NonFootballLeagues = _context.Leagues
                .Where(l => l.Sport == "Ice Hockey" || l.Sport == "Field Hockey" || l.Sport == "Baseball" ||  l.Sport == "Basketball" || l.Sport == "Soccer")
                .ToList();
            ViewBag.Conferences = _context.Leagues
                .Where(i => i.Name.Contains("Conference"))
                .ToList();
            ViewBag.Atlantic = _context.Leagues
                .Where(i => i.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.Dallas = _context.Teams
                .Where(i => i.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(i => i.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(i => i.Location.Contains("City"))
                .ToList();
            ViewBag.BeginsWithT = _context.Teams
                .Where(i => i.TeamName.Contains("T"))
                .ToList();
            ViewBag.AtoZ = _context.Teams
                .OrderBy(i => i.Location)
                .ToList();
            ViewBag.ZtoA = _context.Teams
                .OrderByDescending(i => i.Location)
                .ToList();
            ViewBag.Coop = _context.Players
                .Where(i => i.LastName == "Cooper")
                .ToList();
            ViewBag.Josh = _context.Players
                .Where(i => i.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.CoopNoJosh = _context.Players
                .Where(i => i.LastName == "Cooper" && i.FirstName != "Joshua")
                .ToList();
            ViewBag.AlexORWyatt = _context.Players
                .Where(i => i.FirstName == "Joshua" || i.FirstName == "Wyatt")
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}