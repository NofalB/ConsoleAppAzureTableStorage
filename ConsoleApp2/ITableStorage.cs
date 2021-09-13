using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCustomerTable
{
    public interface ITableStorage<T> where T: TableEntity, new()
    {
        void InsertOrUpdateAsync(T entity);
        void DeleteEntity(string partitionKey, string rowKey);
        IEnumerable<T> GetEntitiesByPartitionKey(string partitionKey);
        IEnumerable<T> GetEntitiesByRowKey(string rowKey);
        T GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey);

    }
}
