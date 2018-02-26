using GameData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameData
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions options) : base(options) { }

        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<News> theNews { get; set; }


        /*
        public DbSet<Models.Type> types { get; set; }
        public DbSet<Enemy> enemies { get; set; }
        public DbSet<News> newsLetter { get; set; }
        */

    }
}
