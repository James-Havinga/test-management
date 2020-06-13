using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Contracts;
using test_managment.Data;

namespace test_managment.Respository
{
    public class TestAllocationRepository : ITestAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public TestAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(TestAllocation entity)
        {
            _db.TestAllocations.Add(entity);
            return Save();
        }

        public bool Delete(TestAllocation entity)
        {
            _db.TestAllocations.Remove(entity);
            return Save();
        }

        public ICollection<TestAllocation> FindAll()
        {
            var testAllocations = _db.TestAllocations.ToList();
            return testAllocations;
        }

        public TestAllocation FindById(int id)
        {
            var testAllocations = _db.TestAllocations.Find(id);
            return testAllocations;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(TestAllocation entity)
        {
            _db.TestAllocations.Update(entity);
            return Save();
        }
    }
}
