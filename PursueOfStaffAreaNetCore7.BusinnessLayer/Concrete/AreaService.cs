using AutoMapper;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete
{
    public class AreaService : Service<Area>, IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaService(IGenericRepository<Area> repository, IUnitOfWork unitOfWork, IAreaRepository areaRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }
        public async Task<List<ListAreaViewModel>> GetAreasWithStaff()
        {
            var areas = await _areaRepository.GetAreasWithStaff();
            var listAreaViewModel = _mapper.Map<List<ListAreaViewModel>>(areas.ToList());
            return listAreaViewModel;
        }
    }
}
