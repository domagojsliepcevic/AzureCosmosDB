using AzureCosmosDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCosmosDB.Dao
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync(string queryString);

        Task<Person> GetPersonAsync(string id); 

        Task AddPersonAsync(Person person);

        Task UpdatePersonAsync(Person person);

        Task DeletePersonAsync(Person person);

    }
}
