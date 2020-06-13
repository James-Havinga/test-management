using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Contracts;
using test_managment.Data;

namespace test_managment.Respository
{
    public class TestHistoryRepository : ITestHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public TestHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(TestHistory entity)
        {
            _db.TestHistories.Add(entity);
            return Save();
        }

        public bool Delete(TestHistory entity)
        {
            _db.TestHistories.Remove(entity);
            return Save();
        }

        public ICollection<TestHistory> FindAll()
        {
            var testHistories = _db.TestHistories.ToList();
            return testHistories;
        }

        public TestHistory FindById(int id)
        {
            var testHistories = _db.TestHistories.Find(id);
            return testHistories;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(TestHistory entity)
        {
            _db.TestHistories.Update(entity);
            return Save();
        }
    }
}
