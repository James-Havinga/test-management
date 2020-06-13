using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Contracts;
using test_managment.Data;

namespace test_managment.Respository
{
    public class TestTypeRepository : ITestTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public TestTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(TestType entity)
        {
            _db.TestTypes.Add(entity);
            return Save();
        }

        public bool Delete(TestType entity)
        {
            _db.TestTypes.Remove(entity);
            return Save();
        }

        public ICollection<TestType> FindAll()
        {
            var testTypes = _db.TestTypes.ToList();
            return testTypes;
        }

        public TestType FindById(int id)
        {
            var testType = _db.TestTypes.Find(id);
            return testType;
        }

        public ICollection<TestType> GetPatientsByTestType(int id)
        {
            throw new NotImplementedException();
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

        public bool Update(TestType entity)
        {
            _db.TestTypes.Update(entity);
            return Save();
        }
    }
}
