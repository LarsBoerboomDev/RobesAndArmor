using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GameData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobesAndArmorGit.Models;
using Microsoft.AspNetCore.Authorization;

namespace RobesAndArmorGit.Controllers
{
    public class BattleController : Controller
    {
        private readonly GameContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public BattleController(GameContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> battle()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            GameData.Models.Character character =  _context.Characters.SingleOrDefault(m => m.UserID == usr.UserName);
            Models.ViewModels.Battle battle = new Models.ViewModels.Battle();
            
            if(checkForExistingBattle(character) == false)
            {
                battle.battle = newBattle(character);
            }
            else
            {
                battle.battle =  _context.battles.SingleOrDefault(m => m.characterID == character.Id);
            }
            battle.enemy =  _context.Enemies.SingleOrDefault(m => m.Id == battle.battle.enemyId);
            battle.character = character;

            return View(battle);
        }

        private  bool checkForExistingBattle(GameData.Models.Character character)
        {
            //checks if there is an already started battle in the database
            GameData.Models.Battle battle =  _context.battles.SingleOrDefault(m => m.characterID == character.Id);
            if(battle == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private GameData.Models.Battle newBattle(GameData.Models.Character character)
        {
            GameData.Models.Battle battle = new GameData.Models.Battle();
            battle.characterID = character.Id;
            GameData.Models.Enemy enemy = randomEnemy(character.Level);
            battle.enemyId = enemy.Id;
            battle.enemyHealth = enemy.Health;
            _context.Add(battle);
            _context.SaveChanges();

            return battle;


        }
        private GameData.Models.Enemy randomEnemy(int level)
        {
            //Picks a random enemy within range from the characters level
            int charlevel = level;
            IEnumerable<GameData.Models.Enemy> enemies = _context.Set<GameData.Models.Enemy>().FromSql("EXEC GetEnemieswithLevel " +  charlevel);
            List<GameData.Models.Enemy> listEnemy = enemies.Cast<GameData.Models.Enemy>().ToList();
            Random rnd = new Random();
            int r = rnd.Next(listEnemy.Count());
            return listEnemy[r];
        }

        private async void deadCharacter()
        {
            //character is dead delete 10% of his money and update health to full
            Logic.CharacterDeadCalc characterDeadCalc = new Logic.CharacterDeadCalc(); 
            ApplicationUser usr = await GetCurrentUserAsync();
            GameData.Models.Character character = await _context.Characters.SingleOrDefaultAsync(m => m.UserID == usr.UserName);

            character = characterDeadCalc.calcOnDeadMoney(character);
            character.Health = 500;

            GameData.Models.Battle battle = _context.battles.SingleOrDefault(m => m.characterID == character.Id);

            _context.Update(character);
            await _context.SaveChangesAsync();

            _context.battles.Remove(battle);
            await _context.SaveChangesAsync();




        }
        private void deadEnemy()
        {
            
            //ask for the drops
        }

        
        public async Task<IActionResult> damage(int? id)
        {
            //return the view with the new damage
            GameData.Models.Battle battle =  _context.battles.SingleOrDefault(m => m.Id == id);

            Logic.DamageCalc calcdam = new Logic.DamageCalc();
            GameData.Models.Character character =  _context.Characters.FirstOrDefault(m => m.Id == battle.characterID);
            




            Models.ViewModels.Damage damage =  calcdam.calcDamage( _context.Characters.FirstOrDefault(m => m.Id == battle.characterID),  _context.Enemies.FirstOrDefault(m => m.Id == battle.enemyId));
            battle.enemyHealth = damage.enemy.Health;            

            if (calcdam.checkIfCharDead(damage.character))
            {
                //character is dead

                deadCharacter();
            }else if (calcdam.checkIfEnemyDead(battle))
            {
                //enemy is dead
                
                deadEnemy();
            }
            else
            {
                //battle goes on as nobody is dead
                _context.Update(battle);
                await _context.SaveChangesAsync();

                character.Health = damage.character.Health;
                _context.Update(character);
                await _context.SaveChangesAsync();

                return RedirectToAction("battle", "Battle");
            }


            
            

            
                        
            return RedirectToAction("battle", "Battle");

            

            //return View("~/Views/Characters/Battle.cshtml", battle);
        }

    }
}