using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameData;
using GameData.Models;
using Microsoft.EntityFrameworkCore;

namespace TheLogic
{
    class Types
    {
        private readonly GameContext _context;

        public Types(GameContext context)
        {
            _context = context;
        }

        public async Task<List<GameData.Models.Type>> Index()
        {
            List<GameData.Models.Type> types;
            types = await _context.Types.ToListAsync();
            return types;
        } 

        public async Task<GameData.Models.Type> Details(int id)
        {
            GameData.Models.Type type = await _context.Types.SingleOrDefaultAsync(m => m.Id == id);
            return type;
        }
    }
}
