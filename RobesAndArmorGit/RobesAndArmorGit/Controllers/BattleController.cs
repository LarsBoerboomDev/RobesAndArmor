using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RobesAndArmorGit.Controllers
{
    public class BattleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}