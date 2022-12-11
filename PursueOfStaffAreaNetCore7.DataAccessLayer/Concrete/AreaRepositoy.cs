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
    public class AreaRepositoy : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepositoy(DatabaseContext databaseContext) : base(databaseContext) { }
        public async Task<List<Area>> GetAreasWithStaff()
        {
            return await _databaseContext.Areas.Include(x => x.Staff).ToListAsync();
        }
    }
}
