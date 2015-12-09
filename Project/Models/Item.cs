using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
   public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Boolean Ready { get; set; }
        public Item() { }
        public Item(string name)
        {
            Name = name;
            Ready = false;
        }

    }
}
