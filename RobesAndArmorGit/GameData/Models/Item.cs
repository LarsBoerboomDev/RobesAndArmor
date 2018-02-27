using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameData.Models
{
    public class Item
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Def { get; set; }
        public int Atk { get; set; }        

        [ForeignKey("Type")]
        public int typeId { get; set; }

    }
}
