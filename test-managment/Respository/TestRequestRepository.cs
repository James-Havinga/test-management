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
        public bool Create(TestRequest entity)
        {
            _db.TestRequests.Add(entity);
            return Save();
        }

        public bool Delete(TestRequest entity)
        {
            _db.TestRequests.Remove(entity);
            return Save();
        }

        public ICollection<TestRequest> FindAll()
        {
            var testHistories = _db.TestRequests
                                .Include(q => q.RequestingPatient)
                                .Include(q => q.ApprovedBy)
                                .Include(q => q.TestType)
                                .ToList();
            return testHistories;
        }

        public TestRequest FindById(int id)
        {
            var testHistories = _db.TestRequests
                                .Include(q => q.RequestingPatient)
                                .Include(q => q.ApprovedBy)
                                .Include(q => q.TestType)
                                .FirstOrDefault(q => q.Id == id);
            return testHistories;
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

        public bool Update(TestRequest entity)
        {
            _db.TestRequests.Update(entity);
            return Save();
        }
    }
}
