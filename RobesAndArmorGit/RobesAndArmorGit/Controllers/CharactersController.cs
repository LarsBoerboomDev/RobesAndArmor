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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Characters.ToListAsync());
        }

        //Fills the usermanager with the logged in user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Characters/Details/5
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

        // GET: Characters/Create
        public async Task<IActionResult> Create()
        {

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
            string id = usr.Id;


            Character newcharacter = new Character();
            newcharacter.Name = names;
            newcharacter.gold = 500;
            newcharacter.imageUrl = Face;
            newcharacter.Level = 1;
            newcharacter.UserID = id;
            
            

            if (ModelState.IsValid)
            {
                _context.Add(newcharacter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newcharacter);
        }

        // GET: Characters/Edit/5
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
