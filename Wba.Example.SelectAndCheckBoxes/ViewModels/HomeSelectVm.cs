using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Wba.Example.SelectAndCheckBoxes.Models;

namespace Wba.Example.SelectAndCheckBoxes.ViewModels
{
    public class HomeSelectVm
    {
        //lijst input genereren
        [DisplayName("Kies een land:")]
        public int SelectedCountry { get; set; }
        public List<SelectListItem> Countries { get; set; }
        //wat zijn je favoriete gerechten
        public List<FoodCheckbox> FavoriteFoods { get; set; }
    }
}
