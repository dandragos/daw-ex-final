using System;
using CarReviewApp.Interfaces;
using CarReviewApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace CarReviewApp.Controllers

{
	[Route("api/[controller]")]
	[ApiController]

	public class CarController : Controller
	{
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
		{
            _carRepository = carRepository;
        }


		[HttpGet]

		[ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]

		public IActionResult GetCars()
		{
			var cars = _carRepository.GetCars();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(cars);
		}

        [HttpGet("{carId}")]
		[ProducesResponseType(200, Type = typeof(Car))]
		[ProducesResponseType(400)]

		public IActionResult GetCar(int carId)
		{
			if (!_carRepository.CarExists(carId))
				return NotFound();

			var car = _carRepository.GetCar(carId);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(car);


		}


    }
}

