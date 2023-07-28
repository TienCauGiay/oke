using MISA.WebFresher042023.Core.Interfaces.UnitOfWork;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MISA.WebFresher042023.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Class triển khai các phương thức xử lí transaction
    /// </summary>
    /// Created By: BNTIEN (22/07/2023)
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbConnection _connection;
        private DbTransaction _transaction = null;

        public UnitOfWork(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }
        public DbConnection Connection => _connection;
        public DbTransaction Transaction => _transaction;

        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Open)
            {
                if(_transaction == null)
                {
                    _transaction = _connection.BeginTransaction();
                }
            }
            else
            {
                _connection.Open();
                if (_transaction == null)
                {
                    _transaction = _connection.BeginTransaction();
                }

            }
        }

        public async Task BeginTransactionAsync()
        {
            if (_connection.State == ConnectionState.Open)
            {
                if(_transaction == null)
                {
                _transaction = await _connection.BeginTransactionAsync();
                }
            }
            else
            {
                await _connection.OpenAsync();
                if (_transaction == null)
                {
                    _transaction = await _connection.BeginTransactionAsync();
                }

            }
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }

            await DisposeAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;

            _connection.Close();
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            _transaction = null;
            await _connection.CloseAsync();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
            await DisposeAsync();
        }
    }
}
