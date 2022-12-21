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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public Task<List<User>> GetUsersWithStaff()
        {
            return _databaseContext.Users.Include(x => x.Staff).Include(x=>x.Staff.Department).Include(x=>x.Staff.Profession).Include(x=>x.Staff.Degree).Include(x => x.Staff.StaffStatu).Include(x => x.Staff.Duty).Include(x => x.Staff.EducationState).ToListAsync();
        }
    }
}
