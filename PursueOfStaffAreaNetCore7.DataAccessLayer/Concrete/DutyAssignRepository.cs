using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.DataContext;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Concrete
{
    public class DutyAssignRepository : GenericRepository<DutyAssign>, IDutyAssignRepository
    {
        public DutyAssignRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        public async Task<List<DutyAssign>> GetDutyAssignsWithStaffAndArea()
        {
            return await _databaseContext.DutyAssigns.Include(x=>x.Area).Include(x=>x.Staff).ToListAsync();
        }
    }
}
