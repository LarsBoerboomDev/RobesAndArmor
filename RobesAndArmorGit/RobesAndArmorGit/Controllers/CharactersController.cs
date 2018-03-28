using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameData;
using GameData.Models;
using Microsoft.AspNetCore.Identity;
using RobesAndArmorGit.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RobesAndArmorGit.Controllers
{
    public class CharactersController : Controller
    {
        private readonly GameContext _context;
        private readonly UserManager<ApplicationUser> _userManager; 



        public CharactersController(GameContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Characters
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Characters.ToListAsync());
        }

        //Fills the usermanager with the logged in user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);



        // GET: Characters/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .SingleOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }
       

        public async Task<IActionResult> CharacterInformation()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var character = await _context.Characters.SingleOrDefaultAsync(m => m.UserID == usr.Id);
            Character Char = new Character();
            Char = character;
            return View(Char);
        }

        public async Task<IActionResult> CharDetails()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var character = await _context.Characters.SingleOrDefaultAsync(m => m.UserID == usr.Id);
            Character MyChar = character;
            return View("_CharacterPartial", MyChar);
        }
        
        
        // GET: Characters/Create
        public async Task<IActionResult> Create()
        {
            //Checks if user already has a character
            ApplicationUser usr = await GetCurrentUserAsync();

            var character = await _context.Characters.SingleOrDefaultAsync(m => m.UserID == usr.Id);
            // returns to homepage index if user already has a character
            if(character != null)
            {
                return RedirectToAction("Index", "Home");
            }
            


            Models.ViewModels.CharacterRegistration viewmodel = new Models.ViewModels.CharacterRegistration();
            viewmodel.Classses = await _context.Classes.ToListAsync();
            viewmodel.Character = new GameData.Models.Character();


            return View(viewmodel);
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,imageUrl,Level,Exp,str,Agility,gold,UserID")] Character character, string Face) old class
        public async Task<IActionResult> Create(string names,string Face, string charClass)
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            string id = usr.UserName;

            
            Inventory inventory = new Inventory();
            inventory.Size = 32;
            _context.Add(inventory);
            await _context.SaveChangesAsync();
            
            int classId = Convert.ToInt32(charClass);
            Class CharacterClass = new Class();
            CharacterClass = await _context.Classes.SingleOrDefaultAsync(m => m.Id == classId);
            
            


            Character newcharacter = new Character();
            newcharacter.Name = names;
            newcharacter.gold = 500;
            newcharacter.imageUrl = Face;
            newcharacter.Level = 1;
            newcharacter.Exp = 0;
            newcharacter.UserID = id;
            newcharacter.Health = 100;
            newcharacter.str = CharacterClass.Str;
            newcharacter.Agility = CharacterClass.Agility;
            newcharacter.INT = CharacterClass.Int;
            newcharacter.Class = CharacterClass;
            newcharacter.inventory = inventory;
            
            

            if (ModelState.IsValid)
            {
                _context.Add(newcharacter);
                await _context.SaveChangesAsync();
                await ChangeUserRoleAsync(usr);
                return RedirectToAction("Index", "Home");                
            }
            return View(newcharacter);
        }

        private async Task ChangeUserRoleAsync(ApplicationUser usr)
        {
            //changes the role of a user to player
           await _userManager.RemoveFromRoleAsync(usr, "User");
           await _userManager.AddToRoleAsync(usr, "Player");
        }

        // GET: Characters/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.SingleOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,imageUrl,Level,Exp,str,Agility,gold,UserID")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .SingleOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [Authorize(Roles = "Admin")]        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.SingleOrDefaultAsync(m => m.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
