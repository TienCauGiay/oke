using MISA.WebFresher042023.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Interfaces.Infrastructures
{
    /// <summary>
    /// Interface GroupProvider repository
    /// </summary>
    /// Created By: BNTIEN (27/07/2023)
    public interface IGroupProviderRepository : IBaseRepository<GroupProvider>
    {
        /// <summary>
        /// Hàm cập nhật thông tin 1 nhóm nhà cung cấp
        /// </summary>
        /// <param name="groupProvider"></param>
        /// <param name="providerId"></param>
        /// <param name="groupId"></param>
        /// <returns>Số hàng bị ảnh hưởng sau khi cập nhật</returns>
        Task<int> UpdateAsync(GroupProvider groupProvider, Guid providerId, Guid groupId);
    }
}
