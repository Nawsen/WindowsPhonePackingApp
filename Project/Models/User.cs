using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project.Models
{
    class User
    {
        public string Id { get; set; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Trips { get; set; }

        public void ConvertToJson(List<Tripsss> TripList)
        {
            //JsonConvert.SerializeObject()
            Trips = JsonConvert.SerializeObject(TripList);
        }
        public List<Tripsss> ConvertFromJson()
        {
            if (Trips != null)
            {
                return JsonConvert.DeserializeObject<List<Tripsss>>(Trips);
            }
            else
            {
                return null;
            }

        }
        public void AddTrip(Tripsss Trip)
        {
            List<Tripsss> TripList;
            if (ConvertFromJson() != null)
            {
                TripList = ConvertFromJson();
            }
            else
            {
                TripList = new List<Tripsss>();
            }
            TripList.Add(Trip);
            ConvertToJson(TripList);
        }
        public void DeleteTrip(Tripsss Trip)
        {
            List<Tripsss> TripList;
            if (ConvertFromJson() != null)
            {
                TripList = ConvertFromJson();
            }
            else
            {
                TripList = new List<Tripsss>();
            }
            TripList.Remove(Trip);
            ConvertToJson(TripList);
        }

        public List<Tripsss> GetTrips()
        {
            return ConvertFromJson();
        }
    }
}
