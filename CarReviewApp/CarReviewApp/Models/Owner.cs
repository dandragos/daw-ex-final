using System;
namespace CarReviewApp.Models
{
	public class Owner
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Region { get; set; }

		public Country Country { get; set; }

		public ICollection<CarOwner> CarOwners { get; set; }




	}
}

