using AutoMapper;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Concrete;
using PursueOfStaffAreaNetCore7.EntityLayer.Entities;
using PursueOfStaffAreaNetCore7.EntityLayer.ViewModels.Allow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete
{
    public class AllowRequestService : Service<AllowRequest>, IAllowRequestService
    {
        private readonly IAllowRequestRepository _allowRequestRepository;
        private readonly IMapper _mapper;

        public AllowRequestService(IGenericRepository<AllowRequest> repository, IUnitOfWork unitOfWork, IAllowRequestRepository allowRequestRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _allowRequestRepository = allowRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<ListAllowRequestViewModel>> GetAllowRequestsWithAllEntities()
        {
            var allowReguests = await _allowRequestRepository.GetAllowRequestsWithAllEntities();
            var listViewAllowRequests = _mapper.Map<List<ListAllowRequestViewModel>>(allowReguests.ToList());
            return listViewAllowRequests;
        }
    }
}
