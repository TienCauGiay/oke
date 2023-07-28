using AutoMapper;
using MISA.WebFresher042023.Core.DTO.GroupProviders;
using MISA.WebFresher042023.Core.Entities;
using MISA.WebFresher042023.Core.Interfaces.Infrastructures;
using MISA.WebFresher042023.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Services
{
    /// <summary>
    /// Class triển khai các phương thức của entities group provider
    /// </summary>
    /// Created By: BNTIEN (27/07/2023)
    public class GroupProviderService : BaseService<GroupProvider, GroupProviderDto, GroupProviderCreateDto, GroupProviderUpdateDto>, IGroupProviderService
    {
        private readonly IGroupProviderRepository _groupProviderRepository;
        /// <summary>
        /// Hàm tạo
        /// </summary>
        /// <param name="baseRepository"></param>
        /// <param name="mapper"></param>
        public GroupProviderService(IGroupProviderRepository groupProviderRepository, IMapper mapper) : base(groupProviderRepository, mapper)
        {
            _groupProviderRepository = groupProviderRepository;
        }
    }
}
