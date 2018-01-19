using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cheese.Web.Data.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;

namespace Cheese.Web.Data
{
	public class CosmosDbClient
	{
		private const string EndpointUrl = "https://mwang888.documents.azure.com:443/";
		private const string PrimaryKey = "M1RQbrYiagfqRA7on78EbXYselGQQi5nHvP9XiGjrWmio8KYvaJHtb06m2AXl3eAam3PbN3VucwI61c7muvdAw==";
		private DocumentClient Client;
		private const string DbName = "CheeseDB";
		private const string FavTableName = "Favorites";

		public CosmosDbClient()
		{
			Client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
			Initialize();
		}

		private async Task Initialize()
		{
			await Client.CreateDatabaseIfNotExistsAsync(new Database { Id = DbName });
			await Client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DbName), new DocumentCollection { Id = FavTableName });
		}

		public async Task AddFavorite(Favorite favorite)
		{
			//favorite.Id = Guid.NewGuid();
			await Client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DbName, FavTableName), favorite);
		}

		public async Task<List<Favorite>> GetFavoritesByUser(Guid userId)
		{			
			FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };
			var results = new List<Favorite>();
						
			using (var favQuery = Client.CreateDocumentQuery<Favorite>(
					UriFactory.CreateDocumentCollectionUri(DbName, FavTableName), queryOptions)
					.Where(f => f.User.Id == userId)
					.AsDocumentQuery())
			{
				while (favQuery.HasMoreResults)
				{
					foreach (Favorite fav in await favQuery.ExecuteNextAsync<Favorite>())
					{
						results.Add(fav);
					}
				}
			}

			return results;
		}
	}
}
