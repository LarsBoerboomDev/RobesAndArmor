using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RobesAndArmorGit.Models;

namespace RobesAndArmorGit.Controllers
{
    public class CityController : Controller
    {

        private readonly GameContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CityController(GameContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> shop()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var character =  _context.Characters.SingleOrDefault(m => m.UserID == user.UserName);
            GameData.Models.Character myChar = character;
            var Items = _context.Items.ToList().Where(m => m.Level <= character.Level);


            return View(Items);
        }

        public async Task<IActionResult> buy(int? id)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var character = _context.Characters.SingleOrDefault(m => m.UserID == user.UserName);
            var inventory = _context.Inventories.SingleOrDefault(m => m.Id == character.InventoryId);
            var item = _context.Items.SingleOrDefault(m => m.Id == id);

            GameData.Models.Inventory_has_Item invItems = new GameData.Models.Inventory_has_Item();
            invItems.Inventory = inventory;
            invItems.ItemId = Convert.ToInt32(id);
            _context.Add(invItems);
            await _context.SaveChangesAsync();


            character.gold = character.gold - item.price;
            _context.Update(character);
            await _context.SaveChangesAsync();

            return RedirectToAction("shop", "City");



            
        }
        
    }
}