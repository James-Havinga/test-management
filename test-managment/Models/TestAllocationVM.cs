using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Data;

namespace test_managment.Models
{
    public class TestAllocationVM
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }
        public PatientVM Patient { get; set; }
        public string PatientId { get; set; }
        public TestTypeVM TestType { get; set; }
        public int TestTypeId { get; set; }

    }

    public class CreateTestAllocationVM
    {
        public int NumberUpdated { get; set; }
        public List<TestTypeVM> TestTypes { get; set; }
    }

    public class EditTestAllocationVM
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public PatientVM Patient { get; set; }
        public string PatientId { get; set; }
        public TestTypeVM TestType { get; set; }
    }

    public class ViewAllocationsVM
    {
        public PatientVM Patient { get; set; }
        public string PatientId { get; set; }
        public List<TestAllocationVM> TestAllocations { get; set; }

    }
}
