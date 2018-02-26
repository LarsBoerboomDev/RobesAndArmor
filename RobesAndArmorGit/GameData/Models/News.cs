using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime postDate { get; set; }
    }
}
