using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheese.Web.Data.Models
{
    public class Location
    {
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string Locality { get; set; }
		public string Region { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
