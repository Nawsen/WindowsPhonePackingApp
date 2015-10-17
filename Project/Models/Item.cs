using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
   public class Item
    {
        public String Name { get; set; }
        public Boolean Ready { get; set; }

        public Item(String name)
        {
            Name = name;
            Ready = false;
        }

    }
}
