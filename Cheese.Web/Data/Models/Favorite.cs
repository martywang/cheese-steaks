using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheese.Web.Data.Models
{
    public class Favorite
    {
		//public Guid Id { get; set; }
		public User User { get; set; }
		public Store Store { get; set; }
		public int Rating { get; set; }
		public string Review { get; set; }
    }
}
