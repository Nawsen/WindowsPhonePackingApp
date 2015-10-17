using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Trip
    {
        public String Name { set; get; }
        public DateTime Deadline { get; set; }
        public List<Item> Items { get; set; }

        public Trip(String name, DateTime deadline)
        {
            Items = new List<Item>();
            Name = name;
            Deadline = deadline;
            Items.Add(new Item("surfplank"));
            Items.Add(new Item("snorkel"));
            Items.Add(new Item("duikbril"));
        }
    }
}
