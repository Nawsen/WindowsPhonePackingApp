using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;

namespace windowsprojectService.DataObjects
{
    public class Tripsss : EntityData
    {
        public string Name { set; get; }
        public string Items { get; set; }
        public string ImageUri { get; set; }
        
        public DateTime? Deadline { get; set; }
    }
}
