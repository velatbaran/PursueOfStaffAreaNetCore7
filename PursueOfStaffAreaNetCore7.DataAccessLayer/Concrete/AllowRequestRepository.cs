using Microsoft.EntityFrameworkCore;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.DataContext;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Concrete
{
    public class AllowRequestRepository : GenericRepository<AllowRequest>, IAllowRequestRepository
    {
        public AllowRequestRepository(DatabaseContext databaseContext) : base(databaseContext) { }
        public async Task<List<AllowRequest>> GetAllowRequestsWithAllEntities()
        {
            var allowRequests = await _databaseContext.AllowRequests.Include(x => x.Staff).Include(x => x.AllowType).Include(x => x.User).ToListAsync();
            return allowRequests;
        }
    }
}
