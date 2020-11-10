﻿using System;
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
        public async Task<ActionResult> Index()
        {
            var testTypes = await _testrepo.FindAll();
            var mappedTestTypes = _mapper.Map<List<TestType>, List<TestTypeVM>>(testTypes.ToList());
            var model = new CreateTestAllocationVM
            {
                TestTypes = mappedTestTypes,
                NumberUpdated = 0
            };
            return View(model);
        }


        public async Task<ActionResult> SetTest(int id)
        {
            var testType = await _testrepo.FindById(id);
            var patients = await _userManager.GetUsersInRoleAsync("Patient");
            
            foreach (var pat in patients)
            {
                if (await _testallocationrepo.CheckAllocation(id, pat.Id))
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
                await _testallocationrepo.Create(testAllocation);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ListPatients()
        {
            var patients = await _userManager.GetUsersInRoleAsync("Patient");
            var model = _mapper.Map<List<PatientVM>>(patients);
            return View(model);
        }

        public async Task<ActionResult> Details(string id)
        {
            var patient = _mapper.Map<PatientVM>(await _userManager.FindByIdAsync(id));
            var allocations = _mapper.Map<List<TestAllocationVM>>(await _testallocationrepo.GetTestAllocationsByPatient(id));
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
        public async Task<ActionResult> Edit(int id)
        {
            var testAllocation = await _testallocationrepo.FindById(id);
            var model = _mapper.Map<EditTestAllocationVM>(testAllocation);
            return View(model);
        }

        // POST: TestAllocation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditTestAllocationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var record = await _testallocationrepo.FindById(model.Id);
                record.NumberOfDays = model.NumberOfDays;
                var isSuccess = await _testallocationrepo.Update(record);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while saving");
                    return View(model);
                }

                return RedirectToAction(nameof(Details), new { id = model.PatientId });
            }
            catch
            {
                return View(model);
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