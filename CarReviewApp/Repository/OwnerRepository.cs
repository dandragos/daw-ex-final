using CarReviewApp.Data;
using CarReviewApp.Interfaces;
using CarReviewApp.Models;


namespace CarReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owner.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfCar(int carId)
        {
            return _context.CarOwners.Where(k => k.Car.Id == carId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owner.ToList();
        }

        public ICollection<Car> GetCarByOwner(int ownerId)
        {
            return _context.CarOwners.Where(k => k.Owner.Id == ownerId).Select(k => k.Car).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owner.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}