using MISA.WebFresher042023.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Core.Interfaces.Infrastructures
{
    /// <summary>
    /// Interface account repository
    /// </summary>
    /// Created By: BNTIEN (19/07/2023)
    public interface IAccountRepository : IBaseRepository<Account>
    {
        /// <summary>
        /// Tìm kiếm và phân trang trên giao diện
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="textSearch"></param>
        /// <param name="isRoot"></param>
        /// <param name="grade"></param>
        /// <param name="accountNumber"></param>
        /// <returns>Danh sách tài khoản theo tìm kiếm, phân trang</returns>
        /// Created By: BNTIEN (19/07/2023)
        Task<FilterAccount?> GetFilterAsync(int pageSize, int pageNumber, string? textSearch, int isRoot, int grade, string? accountNumber);

        /// <summary>
        /// Đếm xem 1 node cha có bao nhiêu con
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>Số lượng code của node cha đó</returns>
        /// Created By: BNTIEN (21/07/2023)
        Task<(Account?, int)> GetCountChildren(string accountNumber);

        /// <summary>
        /// Lấy danh sách các con của tài khoản có số tài khoản là tham số truyền vào
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>Danh sách tài khoản con</returns>
        /// Created By: BNTIEN (21/07/2023)
        Task<List<Account>?> GetAllChildrenAsync(string accountNumber);
        /// <summary>
        /// Cập nhật trạng thái cho các tài khoản
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="state"></param>
        /// <param name="isUpdateChildren"></param>
        /// <returns>Số hàng bị ảnh hưởng sau khi cập nhật</returns>
        /// /// Created By: BNTIEN (26/07/2023)
        Task<int> UpdateStateAsync(string accountNumber, int state, int isUpdateChildren);
    }
}
