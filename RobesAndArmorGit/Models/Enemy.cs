using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Health { get; set; }
        public string imageUrl { get; set; }



    }
}
