using Dapper;
using MISA.WebFresher042023.Core.Entities;
using MISA.WebFresher042023.Core.Interfaces.Infrastructures;
using MISA.WebFresher042023.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MISA.WebFresher042023.Infrastructure.Repository
{
    /// <summary>
    /// class triển khai các phương thức của thực thể nhóm nhà cung cấp truy vấn cơ sở dữ liệu
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// Created By: BNTIEN (27/07/2023)
    public class GroupProviderRepository : BaseRepository<GroupProvider>, IGroupProviderRepository
    {
        /// <summary>
        /// Hàm tạo
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GroupProviderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Hàm cập nhật thông tin 1 nhóm nhà cung cấp
        /// </summary>
        /// <param name="groupProvider"></param>
        /// <param name="providerId"></param>
        /// <param name="groupId"></param>
        /// <returns>Số hàng bị ảnh hưởng sau khi cập nhật</returns>
        public async Task<int> UpdateAsync(GroupProvider groupProvider, Guid providerId, Guid groupId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GroupIdOld", groupId);
                foreach (var prop in groupProvider.GetType().GetProperties())
                {
                    if (prop.Name.Contains("ModifiedDate"))
                    {
                        parameters.Add($"@ModifiedDate", DateTime.Now);
                    }
                    else
                    {
                        parameters.Add($"@{prop.Name}", prop.GetValue(groupProvider));
                    }
                }
                var rowsAffected = await _unitOfWork.Connection.ExecuteAsync($"Proc_GroupProvider_Update", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return rowsAffected;
            }
            catch
            {
                return 0;
            }
        }
    }
}
