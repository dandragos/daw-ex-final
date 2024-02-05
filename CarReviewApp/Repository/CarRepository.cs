using System;
using CarReviewApp.Data;
using CarReviewApp.Interfaces;
using CarReviewApp.Models;
namespace CarReviewApp.Repository
{
	public class CarRepository : ICarRepository
	{
		private readonly DataContext _context;

		public CarRepository(DataContext context)
		{
			_context = context;
		}

        public bool CarExists(int carId)
        {
            return _context.Car.Any(k => k.Id == carId);
        }

        public Car GetCar(int id)
        {
            return _context.Car.Where(k => k.Id == id).FirstOrDefault();
        }

        public Car GetCar(string name)
        {
            return _context.Car.Where(k => k.Name == name).FirstOrDefault();
        }

        //public decimal GetCarRating(int carId)
        //{
        //    var review = _context.Reviews.Where(k => k.Car.Id == carId);

        //    if (review.Count() <= 0)
        //        return 0;

        //    return ((decimal)review.Sum(r => r.Rating) / review.Count());

        //}

        public ICollection<Car> GetCars()
		{

			return _context.Car.OrderBy(k => k.Id).ToList();
		}
	}
}

