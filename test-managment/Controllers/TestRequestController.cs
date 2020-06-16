using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using test_managment.Contracts;
using test_managment.Data;
using test_managment.Models;

namespace test_managment.Controllers
{
    [Authorize]
    public class TestRequestController : Controller
    {
        private readonly ITestRequestRepository _testRequestRepo;
        private readonly ITestTypeRepository _testTypeRepo;
        private readonly ITestAllocationRepository _testAllocationRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Patient> _userManager;

        public TestRequestController(
            ITestRequestRepository testRequestRepo,
            ITestTypeRepository testTypeRepo,
            ITestAllocationRepository testAllocationRepository,
            IMapper mapper,
            UserManager<Patient> userManager
            )
        {
            _testRequestRepo = testRequestRepo;
            _testTypeRepo = testTypeRepo;
            _testAllocationRepository = testAllocationRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var testRequests = _testRequestRepo.FindAll();
            var testRequestsModel = _mapper.Map<List<TestRequestVM>>(testRequests);
            var model = new AdminTestRequestViewVM
            {
                TotalRequests = testRequestsModel.Count,
                ApprovedRequests = testRequestsModel.Count(q => q.Approved == true),
                PendingRequests = testRequestsModel.Count(q => q.Approved == null),
                RejectedRequests = testRequestsModel.Count(q => q.Approved == false),
                TestRequests = testRequestsModel
            };
            return View(model);
        }

        // GET: TestRequest/Details/5
        public ActionResult Details(int id)
        {
            var testRequest = _testRequestRepo.FindById(id);
            var model = _mapper.Map<TestRequestVM>(testRequest);
            return View(model);
        }

        public ActionResult ApproveRequest(int id)
        {
            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                var testRequest = _testRequestRepo.FindById(id);
                testRequest.Approved = true;
                testRequest.ApprovedById = user.Id;
                testRequest.DateActioned = DateTime.Now;

                var isSuccess = _testRequestRepo.Update(testRequest);

                return RedirectToAction(nameof(Index));

            }
            catch ( Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        public ActionResult RejectRequest(int id)
        {
            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                var testRequest = _testRequestRepo.FindById(id);
                testRequest.Approved = false;
                testRequest.ApprovedById = user.Id;
                testRequest.DateActioned = DateTime.Now;

                var isSuccess = _testRequestRepo.Update(testRequest);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: TestRequest/Create
        public ActionResult Create()
        {
            var testTypes = _testTypeRepo.FindAll();
            var testTypeItems = testTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var model = new CreateTestRequestVM
            {
                TestTypes = testTypeItems
            };
            return View(model);
        }

        // POST: TestRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTestRequestVM model)
        {
            
            try
            {
                var testTypes = _testTypeRepo.FindAll();
                var testTypeItems = testTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                model.TestTypes = testTypeItems;

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                
                var patient = _userManager.GetUserAsync(User).Result;
                var allocation = _testAllocationRepository.GetTestAllocationsByPatientAndType(patient.Id, model.TestTypeId);

                var testRequestModel = new TestRequestVM
                {
                    RequestingPatientId = patient.Id,
                    TestDate = model.TestDate,
                    Approved = null,
                    DateActioned = DateTime.Now,
                    DateRequested = DateTime.Now,
                    TestTypeId = model.TestTypeId
                };

                var testRequest = _mapper.Map<TestRequest>(testRequestModel);
                var isSuccess = _testRequestRepo.Create(testRequest);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index),"Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: TestRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestRequest/Edit/5
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

        // GET: TestRequest/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: TestRequest/Delete/5
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