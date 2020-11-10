using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Contracts;
using test_managment.Data;
using Microsoft.EntityFrameworkCore;

namespace test_managment.Respository
{
    public class TestTypeRepository : ITestTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public TestTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(TestType entity)
        {
            await _db.TestTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(TestType entity)
        {
           _db.TestTypes.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<TestType>> FindAll()
        {
            var testTypes = await _db.TestTypes.ToListAsync();
            return testTypes;
        }

        public async Task<TestType> FindById(int id)
        {
            var testType = await _db.TestTypes.FindAsync(id);
            return testType;
        }

        public async Task<ICollection<TestType>> GetPatientsByTestType(int id)
        {
            throw new NotImplementedException();
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

        public async Task<bool> Update(TestType entity)
        {
            _db.TestTypes.Update(entity);
            return await Save();
        }
    }
}
