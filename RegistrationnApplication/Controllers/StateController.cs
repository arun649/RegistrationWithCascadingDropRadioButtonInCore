using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RegistrationnApplication.Models;
using RegistrationnApplication.Repositories.Interface;

namespace RegistrationnApplication.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateRepository _repository;
        private readonly ICountryRepositroy _countryrepository;

        public StateController(IStateRepository repository, ICountryRepositroy countryrepository)
        {
            _repository = repository;
            _countryrepository = countryrepository;

        }
        public async Task<ActionResult> Index()
        {
             
            var rcrd = await _repository.GetAllStates();
            return View(rcrd);
        }
        public async Task<IActionResult> Details(int id)
        {
            var recrd = await _repository.GetStateById(id);
            return View(recrd);
        }
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.CountryList = await _countryrepository.GetAllCountryList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(State state)
        {
            if (ModelState.IsValid)
            { 
                await _repository.CreateState(state);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            var rec = await _repository.GetStateById(id);

            if (rec == null)
            {
                return NotFound();
            }

            ViewBag.CountryList = await _countryrepository.GetAllCountryList();
            return View(rec);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, State state)
        {
            if(state.StateId != 0)
            {
                await _repository.UpdateState(state);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
       
    }
}
