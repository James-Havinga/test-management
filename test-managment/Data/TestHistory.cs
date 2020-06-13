using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Data
{
    public class TestHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RequestingPatientId")]
        public Patient RequestingPatient { get; set; }
        public string RequestingPatientId { get; set; }
        public DateTime TestDate { get; set; }
        [ForeignKey("TestTypeId")]
        public TestType TestType { get; set; }
        public int TestTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        [ForeignKey("ApprovedById")]
        public Patient ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }
}
