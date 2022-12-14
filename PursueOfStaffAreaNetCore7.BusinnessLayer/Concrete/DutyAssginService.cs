using AutoMapper;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.DutyAssign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete
{
    public class DutyAssginService : Service<DutyAssign>, IDutyAssignService
    {
        private readonly IDutyAssignRepository _dutyAssignRepository;
        private readonly IMapper _mapper;
        public DutyAssginService(IGenericRepository<DutyAssign> repository, IUnitOfWork unitOfWork, IDutyAssignRepository dutyAssignRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _dutyAssignRepository = dutyAssignRepository;
            _mapper = mapper;
        }
        public async Task<List<ListDutyAssignViewModel>> GetDutyAssignsWithStaffAndArea()
        {
            var dutyAssigns = await _dutyAssignRepository.GetDutyAssignsWithStaffAndArea();
            var listDutyAssignModelView = _mapper.Map<List<ListDutyAssignViewModel>>(dutyAssigns);
            return listDutyAssignModelView;
        }
    }
}
