using MISA.WebFresher042023.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Interfaces.Infrastructures
{
    public interface IProviderRepository : IBaseRepository<Provider>
    {
        Task<FilterProvider?> GetFilterAsync(int pageSize, int pageNumber, string? textSearch);

        Task<int> InsertAsync (Provider provider, List<Guid>? groupIds);

        Task<int> UpdateAsync(Provider provider, Guid id, List<Guid>? groupIds);
        Task<string?> GetByCodeMaxAsync();
    }
}
