using Microsoft.EntityFrameworkCore;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AllowRequest> AllowRequests { get; set; }
        public DbSet<AllowType> AllowTypes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Duty> Dutys { get; set; }
        public DbSet<DutyAssign> DutyAssigns { get; set; }
        public DbSet<EducationState> EducationStates { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<StaffStatu> StaffStatus { get; set; }

    }
}
