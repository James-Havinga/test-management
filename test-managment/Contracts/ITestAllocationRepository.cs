﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Data;

namespace test_managment.Contracts
{
    public interface ITestAllocationRepository : IRepositoryBase<TestAllocation>
    {
        bool CheckAllocation(int testTypeId, string patientId);
    }
}
