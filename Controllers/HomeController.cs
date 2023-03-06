using DogsMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogsMvc.Controllers
{
    public class HomeController : Controller
    {
        static DataService dataService = new();

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View(dataService.GetAllDogs());
        }

        [HttpGet("/create")]
        public IActionResult CreateDog()
        {
            return View();
        }

        [HttpPost("/create")]
        public IActionResult CreateDog(Dog dog)
        {
            dataService.AddDog(dog);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("dogs/edit/{id}")]
        public IActionResult EditDog(int id) 
        {
            return View(dataService.GetDogById(id));
        }

        [HttpPost("dogs/edit/{id}")]
        public IActionResult EditDog(Dog updatedDog) 
        {
            dataService.EditDog(updatedDog);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteDog(int id) 
        {
            dataService.RemoveDog(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
