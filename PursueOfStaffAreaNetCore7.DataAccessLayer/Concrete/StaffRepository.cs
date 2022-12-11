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
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(DatabaseContext databaseContext):base(databaseContext) { }

        public async Task<List<Staff>> GetStaffsWithAllEntities()
        {
            return await _databaseContext.Staffs.Include(x=>x.EducationState).Include(x=>x.Department).Include(x=>x.Profession).Include(x=>x.Duty).ToListAsync();
        }
    }
}
