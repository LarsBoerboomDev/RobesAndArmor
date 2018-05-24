using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameData;
using GameData.Models;
using Microsoft.EntityFrameworkCore;

namespace TheLogic
{
    class News
    {
        private readonly GameContext _context;

        public News(GameContext context)
        {
            _context = context;
        }

        public async Task<List<GameData.Models.News>> Index()
        {
            List<GameData.Models.News> news;
            news = await _context.theNews.ToListAsync();
            return news;
        }

        public async Task<GameData.Models.News> Details(int id)
        {
            GameData.Models.News news = await _context.theNews.SingleOrDefaultAsync(m => m.Id == id);
            return news;
        }
    }
}
