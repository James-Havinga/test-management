using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Models
{
    public class DetailsTestTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateTestTypeVM
    {
        [Required]
        public string Names { get; set; }
    }
}
