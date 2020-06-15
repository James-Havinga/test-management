using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test_managment.Contracts;
using test_managment.Data;
using test_managment.Models;

namespace test_managment.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TestAllocationController : Controller
    {

        private readonly ITestTypeRepository _testrepo;
        private readonly ITestAllocationRepository _testallocationrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Patient> _userManager;

        public TestAllocationController(
            ITestTypeRepository testrepo,
            ITestAllocationRepository testallocationrepo,
            IMapper mapper,
            UserManager<Patient> userManager)
        {
            _testrepo = testrepo;
            _testallocationrepo = testallocationrepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: TestAllocation
        public ActionResult Index()
        {
            var testTypes = _testrepo.FindAll().ToList();
            var mappedTestTypes = _mapper.Map<List<TestType>, List<TestTypeVM>>(testTypes);
            var model = new CreateTestAllocationVM
            {
                TestTypes = mappedTestTypes,
                NumberUpdated = 0
            };
            return View(model);
        }


        public ActionResult SetTest(int id)
        {
            var testType = _testrepo.FindById(id);
            var patients = _userManager.GetUsersInRoleAsync("Patient").Result;
            foreach (var pat in patients)
            {
                if (_testallocationrepo.CheckAllocation(id, pat.Id))
                    continue; 
                var allocation = new TestAllocationVM
                {
                    DateCreated = DateTime.Now,
                    PatientId = pat.Id,
                    TestTypeId = id,       
                    NumberOfDays = testType.DefaultDays,
                    Period = DateTime.Now.Year,
                };
                var testAllocation = _mapper.Map<TestAllocation>(allocation);
                _testallocationrepo.Create(testAllocation);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult ListPatients()
        {
            var patients = _userManager.GetUsersInRoleAsync("Patient").Result;
            var model = _mapper.Map<List<PatientVM>>(patients);
            return View(model);
        }

        public ActionResult Details(string id)
        {
            var patient = _mapper.Map<PatientVM>(_userManager.FindByIdAsync(id).Result);
            var allocations = _mapper.Map<List<TestAllocationVM>>(_testallocationrepo.GetTestAllocationsByPatient(id));
            var model = new ViewAllocationsVM
            {
                Patient = patient,
                TestAllocations = allocations
            };
            return View(model);
        }

        // GET: TestAllocation/Details/5


        // GET: TestAllocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestAllocation/Create
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

        // GET: TestAllocation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestAllocation/Edit/5
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

        // GET: TestAllocation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestAllocation/Delete/5
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