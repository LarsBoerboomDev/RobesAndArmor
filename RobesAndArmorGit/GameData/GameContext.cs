using GameData.Models;

using Microsoft.EntityFrameworkCore;


namespace GameData
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions options) : base(options) { }

        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<News> theNews { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Inventory_has_Item> Inventory_has_Item { get; set; }
        public DbSet<Enemy_has_Item> Enemy_has_Item { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Inventory_has_Item>()
                .HasKey(t => new { t.InventoryId, t.ItemId });

            modelBuilder.Entity<Enemy_has_Item>()
                .HasKey(t => new { t.EnemyId, t.ItemId });
           
        }
        

        /*
        public DbSet<Models.Type> types { get; set; }
        public DbSet<Enemy> enemies { get; set; }
        public DbSet<News> newsLetter { get; set; }
        */

    }
}
