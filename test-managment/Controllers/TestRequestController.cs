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
    [Authorize]
    public class TestRequestController : Controller
    {
        private readonly ITestRequestRepository _testRequestRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Patient> _userManager;

        public TestRequestController(
            ITestRequestRepository testRequestRepo,
            IMapper mapper,
            UserManager<Patient> userManager
            )
        {
            _testRequestRepo = testRequestRepo;
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
            return View();
        }

        // GET: TestRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestRequest/Create
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