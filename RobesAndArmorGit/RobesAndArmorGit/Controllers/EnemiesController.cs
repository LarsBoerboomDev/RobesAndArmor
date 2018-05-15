using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameData;
using GameData.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using TheLogic;

namespace RobesAndArmorGit.Controllers
{
    public class EnemiesController : Controller
    {
        private readonly GameContext _context;
        TheLogic.Enemies _enemies;

        public EnemiesController(GameContext context)
        {
            _context = context;
            _enemies = new Enemies(_context);
        }

        // GET: Enemies
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enemies.ToListAsync());
        }

        // GET: Enemies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // GET: Enemies/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            Models.ViewModels.EnemyItem enemyItem = new Models.ViewModels.EnemyItem();

            enemyItem.enemyImages = Logic.getImages.gettheImages("Enemy");
            /*
            string path = Path.Combine(Environment.CurrentDirectory, @"wwwroot\images\Enemy\");
            enemyItem.enemyImages = new List<string>();
            foreach (string item in Directory.GetFiles(path))
            {
                enemyItem.enemyImages.Add(Path.GetFileName(item));
            }
            */

            enemyItem.AllItems = await _context.Items.ToListAsync();
            enemyItem.Type = await _context.Types.ToListAsync();
            enemyItem.Enemy = new Enemy();

            return View(enemyItem);
        }

        // POST: Enemies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]       
        //public async Task<IActionResult> Create([Bind("Id,Name,Level,Atk,Def,Health,imageUrl")] Enemy enemy)
        public async Task<IActionResult> Create(string name, string level, string atk, string def, string health, string enemyImage, List<string> drops)
        {
            GameData.Models.Enemy enemy = new Enemy();
            enemy.Name = name;
            enemy.Level = Convert.ToInt32(level);
            enemy.Atk = Convert.ToInt32(atk);
            enemy.Def = Convert.ToInt32(def);
            enemy.Health = Convert.ToInt32(health);
            enemy.imageUrl = enemyImage;

            
            

            _context.Add(enemy);
            await _context.SaveChangesAsync();
             

            GameData.Models.Enemy_has_Item enemyItem = new Enemy_has_Item();
            //_enemies.create(enemy, enemyItem, drops);
             

            foreach (string item in drops)
            {
                enemyItem.Enemy = enemy;
                GameData.Models.Item Item = await _context.Items.SingleOrDefaultAsync(m => m.Id == Convert.ToInt32(item));
                enemyItem.Item = Item;
                
                _context.Add(enemyItem);
                await _context.SaveChangesAsync();
            }
            /*
           
            if (ModelState.IsValid)
            {
                _context.Add(enemy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            */
            //return View(enemy);
            return RedirectToAction(nameof(Index));
        }

        // GET: Enemies/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {

            Models.ViewModels.EnemyItem enemyItem = new Models.ViewModels.EnemyItem();
            

            if (id == null)
            {
                return NotFound();
            }

            enemyItem.Enemy = await _context.Enemies.SingleOrDefaultAsync(m => m.Id == id);
            
           enemyItem.Enemy_Has_Item =  _context.Enemy_has_Item.Where(m => m.EnemyId == id).ToList();
            enemyItem.enemyImages = Logic.getImages.gettheImages("Enemy");
            enemyItem.AllItems = await _context.Items.ToListAsync();
            


            //var enemy = await _context.Enemies.SingleOrDefaultAsync(m => m.Id == id);
            if (enemyItem.Enemy == null)
            {
                return NotFound();
            }
            return View(enemyItem);
        }

        // POST: Enemies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]     
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Level,Atk,Def,Health,imageUrl")] Enemy enemy)
        public async Task<IActionResult> Edit(int id ,string name, string level, string atk, string def, string health, string enemyImage, List<string> drops, Enemy enemy)
        {
            /*
            if (id != enemy.Id)
            {
                return NotFound();
            }
            */
            if (ModelState.IsValid)
            {
                enemy.imageUrl = enemyImage;
                enemy.Id = id;
                 _context.Enemy_has_Item.RemoveRange(_context.Enemy_has_Item.Where(m => m.EnemyId == id));
                await _context.SaveChangesAsync();

                try
                {
                    _context.Update(enemy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnemyExists(enemy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                Enemy_has_Item enemyItem = new Enemy_has_Item();
                foreach (var item in drops)
                {
                    enemyItem.Enemy = enemy;
                    
                    GameData.Models.Item Item = await _context.Items.SingleOrDefaultAsync(m => m.Id == Convert.ToInt32(item));
                    enemyItem.Item = Item;
                    

                    _context.Add(enemyItem);
                    await _context.SaveChangesAsync();
                }
                                    
             
               
                return RedirectToAction(nameof(Index));
            }
            return View(enemy);
        }

        // GET: Enemies/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // POST: Enemies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enemy = await _context.Enemies.SingleOrDefaultAsync(m => m.Id == id);
            _context.Enemies.Remove(enemy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnemyExists(int id)
        {
            return _context.Enemies.Any(e => e.Id == id);
        }
    }
}
