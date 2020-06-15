using Microsoft.EntityFrameworkCore;
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

        public bool CheckAllocation(int testTypeId, string patientId)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.PatientId == patientId && q.TestTypeId == testTypeId && q.Period == period).Any();
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
            var testAllocations = _db.TestAllocations
                .Include(q => q.TestType)
                .Include(q => q.Patient)
                .ToList();
            return testAllocations;
        }

        public TestAllocation FindById(int id)
        {
            var testAllocations = _db.TestAllocations
                .Include(q => q.TestType)
                .Include(q => q.Patient)
                .FirstOrDefault(q => q.Id == id);
            return testAllocations;
        }

        public ICollection<TestAllocation> GetTestAllocationsByPatient(string id)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.PatientId == id && q.Period == period)
                .ToList();
        }

        public bool isExists(int id)
        {
            var exists = _db.TestTypes.Any(q => q.Id == id);
            return exists;
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
