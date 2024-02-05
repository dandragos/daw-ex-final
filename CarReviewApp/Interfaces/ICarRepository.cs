using System;
using CarReviewApp.Models;
namespace CarReviewApp.Interfaces
{
	public interface ICarRepository
	{
		ICollection<Car> GetCars();

		Car GetCar(int id);
		Car GetCar(string name);
		//decimal GetCarRating(int carId);
		bool CarExists(int carId);
		
	}
}

