using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_managment.Contracts;
using test_managment.Data;
using test_managment.Models;

namespace test_managment.Controllers
{
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
        public ActionResult Index()
        {
            var testTypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<TestType>, List<TestTypeVM>>(testTypes);
            return View(model);
        }

        // GET: TestTypes/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var testType = _repo.FindById(id);
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
        public ActionResult Create(TestTypeVM model)
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

                var isSuccess = _repo.Create(testType);

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
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var testType = _repo.FindById(id);
            var model = _mapper.Map<TestTypeVM>(testType);

            return View(model);
        }

        // POST: TestTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var testType = _mapper.Map<TestType>(model);
                var isSuccess = _repo.Update(testType);

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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}