using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShelterService shelterService;

        public HomeController(IShelterService shelterService)
        {
            this.shelterService = shelterService;
        }

        public IActionResult Index()
        {
            return View(this.shelterService.GetAnimals());
        }

        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveAnimal(Animal animal)
        {
            this.shelterService.AddAnimal(animal);
            return RedirectToAction("Index");
        }

        public IActionResult GetAnimal(int id)
        {
            var animal = this.shelterService.GetById(id);
            return View(animal);
        }

        public IActionResult EditAnimal(Animal animalToEdit)
        {
            this.shelterService.EditAnimal(animalToEdit);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnimal(int id)
        {
            this.shelterService.DeleteAnimal(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
