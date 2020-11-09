using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Example.SelectAndCheckBoxes.Models
{
    public class FoodCheckbox
    {
        public string Food { get; set; }
        public int FoodId { get; set; }
        public bool IsSelected { get; set; }
        = false;
        
    }
}
