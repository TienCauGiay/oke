using MISA.WebFresher042023.Core.DTO.GroupProviders;
using MISA.WebFresher042023.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Interfaces.Services
{
    /// <summary>
    /// Interface GroupProvider service
    /// </summary>
    /// Created By: BNTIEN (27/07/2023)
    public interface IGroupProviderService : IBaseService<GroupProviderDto, GroupProviderCreateDto, GroupProviderUpdateDto>
    {
    }
}
