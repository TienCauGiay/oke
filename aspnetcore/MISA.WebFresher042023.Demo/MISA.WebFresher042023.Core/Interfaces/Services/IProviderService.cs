using MISA.WebFresher042023.Core.DTO.Employees;
using MISA.WebFresher042023.Core.DTO.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Interfaces.Services
{
    public interface IProviderService : IBaseService<ProviderDto, ProviderCreateDto, ProviderUpdateDto>
    {
        Task<FilterProviderDto?> GetFilterAsync(int pageSize, int pageNumber, string? textSearch);
        Task<string?> GetByCodeMaxAsync();
    }
}
