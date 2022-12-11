using AutoMapper;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete
{
    public class StaffService : Service<Staff>, IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;

        public StaffService(IGenericRepository<Staff> repository, IUnitOfWork unitOfWork,IStaffRepository staffRepository, IMapper mapper) :base(repository, unitOfWork)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
        }

        public async Task<List<ListStaffViewModel>> GetStaffsWithAllEntities()
        {
            var staffs = await _staffRepository.GetStaffsWithAllEntities();
            var _listStaffViewModels = _mapper.Map<List<ListStaffViewModel>>(staffs.ToList());
            return _listStaffViewModels;
        }
    }
}
