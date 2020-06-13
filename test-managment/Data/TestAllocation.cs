﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Data
{
    public class TestAllocation
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTested { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public string PatientId { get; set; }
        [ForeignKey("TestTypeId")]
        public TestType TestType { get; set; }
        public int TestTypeId { get; set; }
    }
}