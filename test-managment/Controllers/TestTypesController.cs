using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_managment.Contracts;
using test_managment.Data;
using test_managment.Models;

namespace test_managment.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TestTypesController : Controller
    {
        private readonly ITestTypeRepository _repo;
        private readonly IMapper _mapper;

        public TestTypesController(ITestTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        
        // GET: TestTypes
        public async Task<ActionResult> Index()
        {
            var testTypes = await _repo.FindAll();
            var model = _mapper.Map<List<TestType>, List<TestTypeVM>>(testTypes.ToList());
            return View(model);
        }

        // GET: TestTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _repo.isExists(id); 
            if (isExists)
            {
                return NotFound();
            }

            var testType = await _repo.FindById(id);
            var model = _mapper.Map<TestTypeVM>(testType);
            return View(model);
        }

        // GET: TestTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TestTypeVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var testType = _mapper.Map<TestType>(model);
                testType.DateCreated = DateTime.Now;

                var isSuccess = await _repo.Create(testType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: TestTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _repo.isExists(id);
            if (isExists)
            {
                return NotFound();
            }
            var testType = await _repo.FindById(id);
            var model = _mapper.Map<TestTypeVM>(testType);

            return View(model);
        }

        // POST: TestTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TestTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var testType = _mapper.Map<TestType>(model);
                var isSuccess = await _repo.Update(testType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: TestTypes/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            var testType = await _repo.FindById(id);
            var isSuccess = await _repo.Delete(testType);

            if (testType == null)
            {
                return NotFound();
            }

            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: TestTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TestTypeVM model)
        {
            try
            {
                // TODO: Add delete logic here
                var testType = await _repo.FindById(id);
                var isSuccess = await _repo.Delete(testType);

                if (testType == null)
                {
                    return NotFound();
                }

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }
    }
}