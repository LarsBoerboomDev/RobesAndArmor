using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Models
{
    public class ItemArchive
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Def { get; set; }
        public int Atk { get; set; }
        public string imgeUrl { get; set; }
        public string Rarity { get; set; }
        public int price { get; set; }
    }
}
