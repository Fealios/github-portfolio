using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitPortfolio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GitPortfolio.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GitPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly GitPortfolioContext _db;
        // GET: /<controller>/
        public HomeController(GitPortfolioContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Github()
        {
            var list = Data.GetRepos();
            return View(list);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Visited(VisitorViewModel visitor)
        {
            var tempVisitor = new Visitor { Name = visitor.Name };
            _db.Visitors.Add(tempVisitor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
