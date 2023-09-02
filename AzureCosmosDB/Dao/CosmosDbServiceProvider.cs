using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AzureCosmosDB.Dao
{
    public static class CosmosDbServiceProvider
    {
        private const string DatabaseName = "People";
        private const string ContainerName = "Ppik";
        private const string Account = "https://domagojsliepcevic.documents.azure.com:443/";
        private const string Key = "T78SD66YAQO2bCydTz4C5tRxfWj6NWGm3wvURv6H6B8sPWwOKhUOQ0un3cqZbVvBMEWhWLolUQnPACDbEHNMRA==";


        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService;}

        public static async Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient (Account,Key);
            cosmosDbService = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse databaseResponse  = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await databaseResponse.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");

        }
    }
}