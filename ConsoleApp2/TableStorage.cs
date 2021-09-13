using ConsoleAppAzureTableStorage.Domain;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCustomerTable
{
    class TableStorage : ITableStorage<Customer>
    {
        CloudTable cloudTable1;
        public TableStorage(CloudTable table)
        {
            CloudStorageAccount cloudStorageAccountc = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);//// oh dear me...

            CloudTableClient tableClient = cloudStorageAccountc.CreateCloudTableClient();

            string tableName = "CustomerTable";
            CloudTable cloudTable1 = tableClient.GetTableReference(tableName);
        }
        

        public void DeleteEntity(string partitionKey, string rowKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetEntitiesByPartitionKey(string partitionKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetEntitiesByRowKey(string rowKey)
        {
            throw new NotImplementedException();
        }

        public Customer GetEntityByPartitionKeyAndRowKey(string partitionKey, string rowKey)
        {
            throw new NotImplementedException();
        }

        public async void InsertOrUpdateAsync(Customer entity)
        {
            Customer customerEntity = new Customer("124345", "Pieterse", "Sjaak", EnumCustomerType.gold);

            try
            {
                TableOperation tableOperation = TableOperation.Insert(customerEntity);
                TableResult result = await cloudTable1.ExecuteAsync(tableOperation);
                Customer insertedCustomer = result.Result as Customer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
