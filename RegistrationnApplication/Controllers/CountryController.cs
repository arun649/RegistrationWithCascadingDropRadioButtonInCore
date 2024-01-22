using Microsoft.AspNetCore.Mvc;
using RegistrationnApplication.Models;
using RegistrationnApplication.Repositories.Interface;

namespace RegistrationnApplication.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepositroy _repositroy;
        public CountryController(ICountryRepositroy repositroy)
        {
            _repositroy = repositroy;
        }
        public async Task<IActionResult> Index()
        {

            var record = await _repositroy.GetAllCountryList();
            return View(record);
        }
        public  async Task<IActionResult> Details(int id)
        {
            var record =await _repositroy.GetCountryById(id);
            return View(record);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _repositroy.GetCountryById(id);
            return View(record);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Cofirmation(int id) 
        { 
            if(id != 0)
            {
               await _repositroy.DeleteCountry(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
               await _repositroy.CreateCountry(country);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var record = await _repositroy.GetCountryById(id);
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Country country)
        {
            if(country.CountryId != 0) 
            { 
              await  _repositroy.UpdateCountry(country);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
