using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;

namespace windowsprojectService.DataObjects
{
    public class Item : EntityData
    {
        public string Name { get; set; }
        public Boolean Done { get; set; }
        
    }
}
