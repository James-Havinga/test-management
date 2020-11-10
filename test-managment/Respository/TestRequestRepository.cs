using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Contracts;
using test_managment.Data;

namespace test_managment.Respository
{
    public class TestRequestRepository : ITestRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public TestRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(TestRequest entity)
        {
            await _db.TestRequests.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(TestRequest entity)
        {
            _db.TestRequests.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<TestRequest>> FindAll()
        {
            var testHistories = await _db.TestRequests
                                .Include(q => q.RequestingPatient)
                                .Include(q => q.ApprovedBy)
                                .Include(q => q.TestType)
                                .ToListAsync();
            return testHistories;
        }

        public async Task<TestRequest> FindById(int id)
        {
            var testHistories = await _db.TestRequests
                                .Include(q => q.RequestingPatient)
                                .Include(q => q.ApprovedBy)
                                .Include(q => q.TestType)
                                .FirstOrDefaultAsync(q => q.Id == id);
            return testHistories;
        }

        public async Task<ICollection<TestRequest>> GetTestRequestsByPatient(string patientid)
        {
            var testRequests = await FindAll();
                return testRequests.Where(q => q.RequestingPatientId == patientid)
                .ToList();
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

        public async Task<bool> Update(TestRequest entity)
        {
            _db.TestRequests.Update(entity);
            return await Save();
        }
    }
}
