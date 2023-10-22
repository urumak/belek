using Microsoft.Azure.Cosmos;

namespace Belek.API
{
    public static class InfrastructureSetUp
    {
        public static void ConfigureCosmosDb(this IServiceCollection services)
        {
            var accountEndpoint = "https://localhost:8081";
            var accountKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

            var cosmosClientOptions = new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions()
                {
                    IgnoreNullValues = true
                },
            };

            var client = new CosmosClient(accountEndpoint, accountKey, cosmosClientOptions);
            services.AddSingleton(_ => client);
        }
    }
}
