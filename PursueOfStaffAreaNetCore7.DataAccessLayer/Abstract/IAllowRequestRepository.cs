using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract
{
    public interface IAllowRequestRepository : IGenericRepository<AllowRequest>
    {
        Task<List<AllowRequest>> GetAllowRequestsWithAllEntities();
    }
}
