using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_managment.Contracts;

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
            return View();
        }

        // GET: TestTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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