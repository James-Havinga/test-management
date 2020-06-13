using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_managment.Data
{
    public class Patient : IdentityUser
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

    }
}
