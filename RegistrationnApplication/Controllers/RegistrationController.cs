using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistrationnApplication.Models;
using RegistrationnApplication.Repositories.Interface;
using RegistrationnApplication.ViewModel;
using System.Collections.Generic;

namespace RegistrationnApplication.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepositorycs _repository;
        private readonly ICountryRepositroy _countryRepositroy;
        private readonly IStateRepository _stateRepository;
        public RegistrationController(IRegistrationRepositorycs repository, ICountryRepositroy countryRepositroy,IStateRepository stateRepository)
        {
            _repository = repository;
            _countryRepositroy = countryRepositroy;
            _stateRepository = stateRepository;

        }
        public async Task<IActionResult> Index()
        {
            var record = await _repository.GetAllRecordAsync();
            return View(record);
        }
        public async Task<IActionResult> Details(int id)
        {
            var record = await _repository.GetRecordById(id);
            return View(record);
        }
        public async Task<IActionResult> Create(int countryId)
        {

            ViewBag.GenderList = await GetGenderList();
            ViewBag.CountryList = await GetCountryList();
            ViewBag.StateList = await GetStateList(countryId);


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Registration registration)
        {
            if(ModelState.IsValid)
            {
               await _repository.CreateRegistartion(registration);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id,int countryId)
        {
            var record = await _repository.GetRecordById(id);
            ViewBag.GenderList = await GetGenderList();
            ViewBag.CountryList = await GetCountryList();
            ViewBag.StateList = await GetStateList(record.CountryId);

            return View(record);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Registration registration)
        {
            if(registration.Id != 0)
            {
                await _repository.UpdateRegistartion(registration);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _repository.GetRecordById(id);
            return View(record);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Confirmation(int id)
        {
             await _repository.DeleteRegistartion(id);
            return RedirectToAction("Index");
        }
        private async Task<IEnumerable<SelectListItem>> GetGenderList()
        {
            var genderlist = await _repository.GetAllGenderAsync();

            return genderlist.Where(c => c.GenderName != null)
                                  .Select(a => new SelectListItem
                                  {
                                      Value = a.GenderId.ToString(),
                                      Text = a.GenderName
                                  }).OrderBy(c => c.Value).ToList();
        }
        private async Task<IEnumerable<SelectListItem>>GetCountryList()
        {
            var countryList = await _countryRepositroy.GetAllCountryList();

            return countryList.Where(c => c.Name != null)
                                  .Select(a => new SelectListItem
                                  {
                                      Value = a.CountryId.ToString(),
                                      Text = a.Name
                                  }).OrderBy(c => c.Value).ToList();
        }
        private async Task<IEnumerable<SelectListItem>> GetStateList(int id)
        {
            var stateList = await _stateRepository.GetStatesByCountryId(id);

            return stateList.Where(c => c.Name != null)
                                  .Select(a => new SelectListItem
                                  {
                                      Value = a.StateId.ToString(),
                                      Text = a.Name
                                  }).OrderBy(c => c.Value).ToList();
        }
        public async Task<JsonResult> GetStatesByCountry(int id)
        {
            IEnumerable<SelectListItem> ststes = await GetStateList(id);
            return Json(ststes);
        }





    }
}
