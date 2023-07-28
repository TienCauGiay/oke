using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.WebFresher042023.Core.Interfaces.Infrastructures;
using MISA.WebFresher042023.Core.Interfaces.UnitOfWork;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher042023.Infrastructure.Repository
{
    /// <summary>
    /// class triển khai các phương thức chung truy vấn cơ sở dữ liệu
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// Created By: BNTIEN (17/06/2023)
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        protected readonly IUnitOfWork _unitOfWork;

        private string className = typeof(TEntity).Name;

        /// <summary>
        /// Hàm tạo, tiêm DI
        /// </summary>
        /// <param name="configuration"></param>
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Method chung
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>danh sách entities</returns>
        /// Created By: BNTIEN (17/06/2023)
        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            try
            {
                var entities = await _unitOfWork.Connection.QueryAsync<TEntity>($"Proc_{className}_GetAll", null, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return entities;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy thông tin entities theo code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>entities theo code</returns>
        /// Created By: BNTIEN (17/06/2023)
        public async Task<TEntity?> GetByCodeAsync(string code)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@code", code);

                var entities = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>($"Proc_{className}_GetByCode", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return entities;
            }
            catch
            {
                return default(TEntity);
            }
        }

        /// <summary>
        /// Lấy thông tin entities theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>entities theo id</returns>
        /// Created By: BNTIEN (17/06/2023)
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                var entities = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>($"Proc_{className}_GetById", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return entities;
            }
            catch { return default(TEntity); }
        }

        /// <summary>
        /// Thêm mới 1 entities
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số hàng bị ảnh hưởng sau khi thêm</returns>
        /// Created By: BNTIEN (17/06/2023)
        public async Task<int> InsertAsync(TEntity entity)
        {
            try
            {
                var parameters = new DynamicParameters();
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name.Contains($"{className}Id"))
                    {
                        parameters.Add($"@{className}Id", Guid.NewGuid());
                    }
                    else if (prop.Name.Contains("CreatedDate"))
                    {
                        parameters.Add($"@CreatedDate", DateTime.Now);
                    }
                    else
                    {
                        parameters.Add($"@{prop.Name}", prop.GetValue(entity));
                    }
                }

                var rowsAffected = await _unitOfWork.Connection.ExecuteAsync($"Proc_{className}_Insert", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return rowsAffected;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Cập nhật thông tin entities
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns>Số hàng bị ảnh hưởng sau khi sửa</returns>
        /// Created By: BNTIEN (17/06/2023)
        public async Task<int> UpdateAsync(TEntity entity, Guid id)
        {
            try
            {
                var parameters = new DynamicParameters();
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name.Contains("ModifiedDate"))
                    {
                        parameters.Add($"@ModifiedDate", DateTime.Now);
                    }
                    else
                    {
                        parameters.Add($"@{prop.Name}", prop.GetValue(entity));
                    }
                }
                var rowsAffected = await _unitOfWork.Connection.ExecuteAsync($"Proc_{className}_Update", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return rowsAffected;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Xóa thực thể theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Số hàng bị ảnh hưởng sau khi xóa</returns>
        /// Created By: BNTIEN (17/06/2023)
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                var rowsAffected = await _unitOfWork.Connection.ExecuteAsync($"Proc_{className}_Delete", parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
                return rowsAffected;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Xóa nhiều thực thể theo các id tương ứng
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>số hàng bị ảnh hưởng sau khi xóa</returns>
        /// Created By: BNTIEN (17/06/2023)
        public virtual async Task<int> DeleteMultipleAsync(List<Guid> ids)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ids", ids);
                string query = $"DELETE FROM {className} WHERE {className}Id IN @ids";
                var res = await _unitOfWork.Connection.ExecuteAsync(query, parameters, _unitOfWork.Transaction);

                await _unitOfWork.CommitAsync();

                return res;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return 0;
            }
        }
        #endregion
    }
}
