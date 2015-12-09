using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project.Models
{
    public class Tripsss
    {
        public string Id { get; set; }
        public string Name { set; get; }
        public DateTime? Deadline { get; set; }
        public string Items { get; set; }
        public string ImageUri { get; set; }

        //public List<Item> ItemList
        //{
        //    get
        //    {

        //        return JsonConvert.DeserializeObject<List<Item>>(Items); 
        //    }
        //}

        public Tripsss()
        {
        }
        
        public Tripsss(string name, DateTime deadline, string items, string uri)
        {
            Name = name;
            Items = items;
            Deadline = deadline;
            ImageUri = uri;
        }

        public void ConvertToJson(List<Item> ItemList)
        {
            //JsonConvert.SerializeObject()
            Items = JsonConvert.SerializeObject(ItemList);
        }
        public List<Item> ConvertFromJson()
        {
            if (Items != null)
            {
                return JsonConvert.DeserializeObject<List<Item>>(Items);
            }
            else
            {
                return null;
            }
            
        }

        public void AddItem(Item item)
        {
            List<Item> ItemList;
            if (ConvertFromJson() != null)
            {
                ItemList = ConvertFromJson();
            }
            else
            {
                ItemList = new List<Item>();
            }
            ItemList.Add(item);
            ConvertToJson(ItemList);
        }
        public void DeleteItem(Item item)
        {
            List<Item> ItemList;
            if (ConvertFromJson() != null)
            {
                ItemList = ConvertFromJson();
            }
            else
            {
                ItemList = new List<Item>();
            }
            ItemList.Remove(item);
            ConvertToJson(ItemList);
        }

        public List<Item> GetItems()
        {
            return ConvertFromJson();
        }
    }
}
