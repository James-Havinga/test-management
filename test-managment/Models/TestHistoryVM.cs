using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Models
{
    public class TestHistoryVM
    {
        public int Id { get; set; }
        public PatientVM RequestingPatient { get; set; }
        public string RequestingPatientId { get; set; }
        [Required]
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
}
