using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.WebFresher042023.Core.Entities;
using MISA.WebFresher042023.Core.Interfaces.Infrastructures;
using MISA.WebFresher042023.Core.Interfaces.UnitOfWork;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Infrastructure.Repository
{
    /// <summary>
    /// class triển khai các phương thức của thực thể account truy vấn cơ sở dữ liệu
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// Created By: BNTIEN (19/07/2023)
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        /// <summary>
        /// Hàm tạo
        /// </summary>
        /// <param name="configuration"></param>
        public AccountRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Method riêng (Account)

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
        public async Task<FilterAccount?> GetFilterAsync(int pageSize, int pageNumber, string? textSearch, int isRoot, int grade, string? accountNumber)
        {
            try
            {
                textSearch = textSearch ?? string.Empty;
                accountNumber = string.IsNullOrEmpty(accountNumber) ? string.Empty : accountNumber + "_";
                var parameters = new DynamicParameters();
                parameters.Add("@PageSize", pageSize);
                parameters.Add("@PageNumber", pageNumber);
                parameters.Add("@TextSearch", textSearch);
                parameters.Add("@IsRoot", isRoot);
                parameters.Add("@Grade", grade);
                parameters.Add("@AccountNumber", accountNumber);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var result = await _unitOfWork.Connection.QueryAsync<Account>("Proc_Account_GetFilter", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                var totalRecord = parameters.Get<int>("@TotalRecord");

                var currentPageRecords = 0;
                if (pageNumber < Math.Ceiling((decimal)totalRecord / pageSize))
                {
                    currentPageRecords = pageSize;
                }
                else if (pageNumber == Math.Ceiling((decimal)totalRecord / pageSize))
                {
                    currentPageRecords = totalRecord - (pageNumber - 1) * pageSize;
                }

                return new FilterAccount
                {
                    TotalPage = (int)Math.Ceiling((decimal)totalRecord / pageSize),
                    TotalRecord = totalRecord,
                    CurrentPage = pageNumber,
                    CurrentPageRecords = currentPageRecords,
                    Data = result.ToList()
                };
            }
            catch
            {
                return new FilterAccount
                {
                    TotalPage = 0,
                    TotalRecord = 0,
                    CurrentPage = 0,
                    CurrentPageRecords = 0,
                    Data = new List<Account>()
                };
            }
        }

        /// <summary>
        /// Đếm xem 1 node cha có bao nhiêu con
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>Số lượng code của node cha đó</returns>
        /// Created By: BNTIEN (21/07/2023)
        public async Task<(Account?, int)> GetCountChildren(string accountNumber)
        {
            try
            {
                var patternAccountNumber = accountNumber + "_";
                var parameters = new DynamicParameters();
                parameters.Add("@accountNumber", patternAccountNumber);
                parameters.Add("@countChildren", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var res = await _unitOfWork.Connection.QueryAsync<Account>("Proc_Account_CountChildren", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return (res.ElementAt(0), parameters.Get<int>("@countChildren"));
            }
            catch
            {
                return (default(Account), 0);
            }
        }

        /// <summary>
        /// Lấy danh sách các con của tài khoản có số tài khoản là tham số truyền vào
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>Danh sách tài khoản con</returns>
        /// Created By: BNTIEN (21/07/2023)
        public async Task<List<Account>?> GetAllChildrenAsync(string accountNumber)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@accountNumber", accountNumber);

                var res = await _unitOfWork.Connection.QueryAsync<Account>("Proc_Account_GetChildren", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

                return (List<Account>?)res;
            }
            catch
            {
                return new List<Account>();
            }
        }

        /// <summary>
        /// Cập nhật trạng thái cho các tài khoản
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="state"></param>
        /// <param name="isUpdateChildren"></param>
        /// <returns>Số hàng bị ảnh hưởng sau khi cập nhật</returns>
        /// Created By: BNTIEN (26/07/2023)
        public async Task<int> UpdateStateAsync(string accountNumber, int state, int isUpdateChildren)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@accountNumber", accountNumber);
                parameters.Add("@state", state);
                parameters.Add("@isUpdateChildren", isUpdateChildren);

                var rowsAffected = await _unitOfWork.Connection.ExecuteAsync($"Proc_Account_UpdateState", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return rowsAffected;
            }
            catch { return 0; }
        }
        #endregion
    }
}
