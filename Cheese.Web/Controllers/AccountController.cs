using Cheese.Web.Data;
using Cheese.Web.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheese.Web.Controllers
{
    public class AccountController
    {
		private CosmosDbClient DbClient { get; set; }

		public AccountController(CosmosDbClient dbClient)
		{
			DbClient = dbClient;
		}

		[HttpPost("api/favorites")]
		public Task AddFavorite([FromBody] Favorite favorite)
		{
			return DbClient.AddFavorite(favorite);
		}

		[HttpGet("api/favorites")]
		public Task<List<Favorite>> GetFavorite([FromQuery] Guid userId)
		{
			return DbClient.GetFavoritesByUser(userId);
		}
	}
}
