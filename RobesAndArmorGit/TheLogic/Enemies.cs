using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameData;
using GameData.Models;
using Microsoft.EntityFrameworkCore;

namespace TheLogic
{
   public class Enemies
    {

        private readonly GameContext _context;
       

        public Enemies(GameContext context)
        {
             _context = context;                   
        }
       
        public async Task<List<GameData.Models.Enemy>> getAllEnemies()
        {


            GameData.Models.test test = new test(_context);
            

            List<GameData.Models.Enemy> enemies;
       
            
            enemies = await _context.Enemies.ToListAsync();
            return enemies;
        }




        public async Task<Enemy> getEnemyDetails(int id)
        {
            Enemy enemy = await _context.Enemies.SingleOrDefaultAsync(m => m.Id == id);
            return enemy;
        }
               
        

        public async void create(Enemy enemy, List<string> drops)
        {
            
            _context.Add(enemy);
            await _context.SaveChangesAsync();

            Enemy_has_Item enemyItem = new Enemy_has_Item();


            foreach (string item in drops)
            {
                enemyItem.Enemy = enemy;
                GameData.Models.Item Item = await _context.Items.SingleOrDefaultAsync(m => m.Id == Convert.ToInt32(item));
                enemyItem.Item = Item;
                _context.Add(enemyItem);
                await _context.SaveChangesAsync();
            }    
        }       
        
        public async Task<Enemy> EditEnemy(int id)
        {

            return null;
        }

        public void saveEnemy(int id, string name, string level, string atk, string def, string health, string enemyImage, List<string> drops, Enemy enemy)
        {

        }

        public void deleteEnemy(int id)
        {

        }
    }
}
