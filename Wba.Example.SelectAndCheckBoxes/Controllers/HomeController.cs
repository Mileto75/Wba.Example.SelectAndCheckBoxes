using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wba.Example.SelectAndCheckBoxes.Models;
using Wba.Example.SelectAndCheckBoxes.ViewModels;

namespace Wba.Example.SelectAndCheckBoxes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Select(HomeSelectVm homeSelectVm)
        {
            //overloop de favoriete foods
            foreach(var favoriteFood in homeSelectVm.FavoriteFoods)
            {
                if(favoriteFood.IsSelected)
                {
                    //bewaren in database
                    Console.WriteLine(favoriteFood.FoodId.ToString());
                }
            }
            //dit kan korter met Linq
            var favoriteFoodsSelected = homeSelectVm
                .FavoriteFoods
                .Where(f => f.IsSelected == true);
            
            return Content($"{homeSelectVm.SelectedCountry}");
        }

        [HttpGet]
        public IActionResult Select()
        {
            //laadt formulier met lijst
            //Vm declareren
            HomeSelectVm homeSelectVm = new HomeSelectVm();
            //waarden toevoegen aan lijst
            homeSelectVm.Countries = new List<SelectListItem>();
            //vul de lijst
            homeSelectVm.Countries.Add
                (
                    new SelectListItem { Value="1",Text="België"}
                );
            homeSelectVm.Countries.Add
                (
                    new SelectListItem { Value = "2", Text = "Nederland" }
                );
            homeSelectVm.Countries.Add
                (
                    new SelectListItem { Value = "3", Text = "Italië" }
                );
            //vul de lijst met checkBoxes favorite foods
            homeSelectVm.FavoriteFoods = new List<FoodCheckbox>();
            //checkBoxLijst aan met foods
            homeSelectVm.FavoriteFoods.Add
                (
                    new FoodCheckbox {FoodId=1,Food="Lasagna"}
                );
            homeSelectVm.FavoriteFoods.Add
                (
                    new FoodCheckbox { FoodId = 2, Food = "Stovers" }
                );
            homeSelectVm.FavoriteFoods.Add
                (
                    new FoodCheckbox { FoodId = 3, Food = "Pizza" }
                );
            homeSelectVm.FavoriteFoods.Add
                (
                    new FoodCheckbox { FoodId = 4, Food = "Frieten" }
                );
            return View(homeSelectVm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
