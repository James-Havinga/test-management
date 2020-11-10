using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Data;

namespace test_managment.Contracts
{
    public interface ITestAllocationRepository : IRepositoryBase<TestAllocation>
    {
        Task<bool> CheckAllocation(int testTypeId, string patientId);
        Task<ICollection<TestAllocation>> GetTestAllocationsByPatient(string id);
        Task<TestAllocation> GetTestAllocationsByPatientAndType(string id, int testTypeId);
    }
}
