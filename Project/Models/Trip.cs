using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Trip
    {
        //public String Id { get; set; }
        public String Name { set; get; }
        //public DateTime Deadline { get; set; }
        public List<Item> Items { get; set; }
        public String ImageUri { get; set; }

        public Trip() { }
        public Trip(String name, DateTime deadline, String uri)
        {
            Items = new List<Item>();
            Name = name;
            //Deadline = deadline;
            Items.Add(new Item("surfplank"));
            Items.Add(new Item("snorkel"));
            Items.Add(new Item("duikbril"));
            Items.Add(new Item("kloni"));
            ImageUri = uri;
            //ImageUri = new Uri("www.google.be");
        }
        public Trip(String name, DateTime deadline, List<Item> items, String uri)
        {
            Name = name;
            Items = items;
            //Deadline = deadline;
            ImageUri = uri;
            //ImageUri = new Uri("www.google.be");
        }

    }
}
