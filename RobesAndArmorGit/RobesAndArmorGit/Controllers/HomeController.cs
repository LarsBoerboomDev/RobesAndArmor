using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobesAndArmorGit.Models;
using RobesAndArmorGit.Services;

namespace RobesAndArmorGit.Controllers
{
    public class HomeController : Controller
    {
        private readonly GameContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public string _currentUser;

        public HomeController(GameContext context, UserResolverService userSerivce)
        {
            _context = context;            
            _currentUser = userSerivce.getUserAsync();
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.theNews.ToListAsync());
            
        }
        
        private void checkUse()
        {
            
        }

        public async Task<IActionResult> newsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.theNews
                .SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
