using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Models
{
    public class TestAllocationVM
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateTested { get; set; }
        public PatientVM Patient { get; set; }
        public string PatientId { get; set; }
        public TestTypeVM TestType { get; set; }
        public int TestTypeId { get; set; }

        public IEnumerable<SelectListItem> Patients { get; set; }
        public IEnumerable<SelectListItem> TestTypes { get; set; }
    }
}
