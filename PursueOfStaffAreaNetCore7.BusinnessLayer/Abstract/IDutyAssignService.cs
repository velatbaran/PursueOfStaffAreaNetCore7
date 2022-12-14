using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.DutyAssign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract
{
    public interface IDutyAssignService : IService<DutyAssign>
    {
        Task<List<ListDutyAssignViewModel>> GetDutyAssignsWithStaffAndArea();
    }
}
