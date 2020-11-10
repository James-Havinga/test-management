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

        public async Task<bool> CheckAllocation(int testTypeId, string patientId)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations.Where(q => q.PatientId == patientId && q.TestTypeId == testTypeId && q.Period == period).Any();
        }

        public async Task<bool> Create(TestAllocation entity)
        {
            await _db.TestAllocations.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(TestAllocation entity)
        {
            _db.TestAllocations.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<TestAllocation>> FindAll()
        {
            var testAllocations = await _db.TestAllocations
                .Include(q => q.TestType)
                .Include(q => q.Patient)
                .ToListAsync();
            return testAllocations;
        }

        public async Task<TestAllocation> FindById(int id)
        {
            var testAllocations = await _db.TestAllocations
                .Include(q => q.TestType)
                .Include(q => q.Patient)
                .FirstOrDefaultAsync(q => q.Id == id);
            return testAllocations;
        }

        public async Task<ICollection<TestAllocation>> GetTestAllocationsByPatient(string id)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations
                .Where(q => q.PatientId == id && q.Period == period)
                .ToList();
        }

        public async Task<TestAllocation> GetTestAllocationsByPatientAndType(string id, int testTypeId)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations
                .FirstOrDefault(q => q.PatientId == id && q.Period == period && q.TestTypeId == testTypeId);
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.TestTypes.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(TestAllocation entity)
        {
            _db.TestAllocations.Update(entity);
            return await Save();
        }
    }
}
