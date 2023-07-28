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
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string?> GetByCodeMaxAsync()
        {
            try
            {
                var res = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<string>("Proc_Provider_GetCodeMax", commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return !string.IsNullOrEmpty(res) ? res.ToString() : "";
            }
            catch
            {
                return null;
            }
        }

        public async Task<FilterProvider?> GetFilterAsync(int pageSize, int pageNumber, string? textSearch)
        {
            try
            {
                textSearch = textSearch ?? string.Empty;
                var parameters = new DynamicParameters();
                parameters.Add("@PageSize", pageSize);
                parameters.Add("@PageNumber", pageNumber);
                parameters.Add("@TextSearch", textSearch);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var result = await _unitOfWork.Connection.QueryAsync<Provider>("Proc_Provider_GetFilter", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
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

                return new FilterProvider
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
                return new FilterProvider
                {
                    TotalPage = 0,
                    TotalRecord = 0,
                    CurrentPage = 0,
                    CurrentPageRecords = 0,
                    Data = new List<Provider>()
                };
            }
        }

        public async Task<int> InsertAsync(Provider provider, List<Guid>? groupIds)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                // Thêm nhà cung cấp
                var rowsAffected = 0;
                provider.ProviderId = Guid.NewGuid();
                var parameters = new DynamicParameters();
                foreach (var prop in provider.GetType().GetProperties())
                {
                    if (prop.Name.Contains("CreatedDate"))
                    {
                        parameters.Add("@CreatedDate", DateTime.Now);
                    }
                    else
                    {
                        parameters.Add($"@{prop.Name}", prop.GetValue(provider));
                    }
                }

                rowsAffected += await _unitOfWork.Connection.ExecuteAsync($"Proc_Provider_Insert", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

                // Thêm nhóm nhà cung cấp
                if(groupIds?.Count> 0)
                {
                    foreach(var groupId in groupIds)
                    {
                        var parameters2 = new DynamicParameters();
                        parameters2.Add("@GroupId", groupId);
                        parameters2.Add("@ProviderId", provider.ProviderId);
                        parameters2.Add("@CreatedBy", "");
                        parameters2.Add("@CreatedDate", DateTime.Now);
                        rowsAffected += await _unitOfWork.Connection.ExecuteAsync($"Proc_GroupProvider_Insert", parameters2, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                    }
                }

                await _unitOfWork.CommitAsync();
                return rowsAffected;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return 0;
            }
        }

        public async Task<int> UpdateAsync(Provider provider, Guid id, List<Guid>? groupIds)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var rowsAffected = 0;
                // Cập nhật thông tin nhà cung cấp
                rowsAffected += await base.UpdateAsync(provider, id);

                // Cập nhật thông tin nhóm nhà cung cấp

                await _unitOfWork.CommitAsync();
                return rowsAffected;
            }
            catch 
            {
                await _unitOfWork.RollbackAsync();
                return 0;
            }
        }

        public override async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var rowsAffected = 0;
                var parameters = new DynamicParameters();
                parameters.Add("@idProvider", id);

                // Xóa các nhóm nhà cung cấp có mã nhà cung cấp là id
                rowsAffected += await _unitOfWork.Connection.ExecuteAsync($"Proc_GroupProvider_Delete", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

                // Xóa nhà cung cấp
                rowsAffected += await base.DeleteAsync(id);

                await _unitOfWork.CommitAsync();
                return rowsAffected;
            }
            catch 
            {
                await _unitOfWork.RollbackAsync();
                return 0;
            }
        }

        public override async Task<int> DeleteMultipleAsync(List<Guid> ids)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var rowsAffected = 0;
                foreach (var id in ids)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@idProvider", id);

                    // Xóa các nhóm nhà cung cấp có mã nhà cung cấp là id
                    rowsAffected += await _unitOfWork.Connection.ExecuteAsync($"Proc_GroupProvider_Delete", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                }

                // Xóa các nhà cung cấp
                rowsAffected += await base.DeleteMultipleAsync(ids);

                await _unitOfWork.CommitAsync();
                return rowsAffected;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return 0;
            }
        }
    }
}
