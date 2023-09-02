using AzureCosmosDB.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AzureCosmosDB.Dao
{
    public class CosmosDbService : ICosmosDbService
    {

        private readonly Container container;

        public CosmosDbService(CosmosClient cosmosClient,string dbname, string contName)
        {
            container = cosmosClient.GetContainer(dbname, contName);
        }

        public async Task AddPersonAsync(Person person) => await container.CreateItemAsync(person,new PartitionKey(person.Id));
        

        public async Task DeletePersonAsync(Person person) => await container.DeleteItemAsync<Person>(person.Id,new PartitionKey(person.Id));


        public async Task<IEnumerable<Person>> GetAllPersonsAsync(string queryString)
        {
            List<Person> persons = new List<Person>();
            var query = container.GetItemQueryIterator<Person>(new QueryDefinition(queryString));
            while (query.HasMoreResults)
            {
                var result = await query.ReadNextAsync();
                persons.AddRange(result.ToList());
            }

            return persons;
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            try
            {
                return await container.ReadItemAsync<Person>(id, new PartitionKey(id));
            }
            catch (CosmosException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {

                return null;
            }
        }

        public async Task UpdatePersonAsync(Person person) => await container.UpsertItemAsync(person, new PartitionKey(person.Id));

    }
}