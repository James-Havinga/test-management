using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Models
{
    public class TestRequestVM
    {
        public int Id { get; set; }
        public PatientVM RequestingPatient { get; set; }
        public string RequestingPatientId { get; set; }
        public DateTime TestDate { get; set; }
        public TestTypeVM TestType { get; set; }
        public int TestTypeId { get; set; }
        public IEnumerable<SelectListItem> TestTypes { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public PatientVM ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }

    public class AdminTestRequestViewVM
    {
        [Display(Name = "Total Number Of Requsts")]
        public int TotalRequests { get; set; }
        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        public List<TestRequestVM> TestRequests { get; set; }
    }

    public class CreateTestRequestVM
    {
        [Display(Name = "Testing Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime TestDate { get; set; }
        public IEnumerable<SelectListItem> TestTypes { get; set; }
        [Display(Name ="Test Types")]
        public int TestTypeId { get; set; }

    }

    public class PatientTestRequestViewVM
    {
        public List<TestAllocationVM> TestAllocations { get; set; }
        public List<TestRequestVM> TestRequests { get; set; }

    }
}
