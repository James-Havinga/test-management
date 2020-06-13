using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Models
{
    public class TestTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }
    }

    
}
