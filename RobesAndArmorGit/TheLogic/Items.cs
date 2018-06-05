using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameData;
using GameData.Models;
using Microsoft.EntityFrameworkCore;

namespace TheLogic
{
    public class Items
    {
        private readonly GameContext _context;

        public Items(GameContext context)
        {
            _context = context;
        }

        public async Task<List<GameData.Models.Item>> getAllItems()
        {

            
            List<GameData.Models.Item> items;


            items = await _context.Items.ToListAsync();
            return items;
        }



    }
}
