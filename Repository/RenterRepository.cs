using HomeRenterService.Dtos.Apartment;
using HomeRenterService.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyRent.DbContext;
using MyRent.Model;

namespace HomeRenterService.Repository
{
    public class RenterRepository// : IRenter
    {
        private readonly ApplicationDbContext _context;
        public RenterRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<List<Apartment>> GetAllApartments(ApartmentFilter filter)
        {
            List<Apartment> apartments = await _context.apartments.ToListAsync();
            if (filter.MinSize.HasValue) apartments = apartments.Where(a => a.Size >= filter.MinSize).ToList();
            if (filter.MaxSize.HasValue) apartments = apartments.Where(a => a.Size <= filter.MaxSize).ToList();
            if (filter.MinTotalCost.HasValue) apartments = apartments.Where(a => a.totalCost >= filter.MinTotalCost).ToList();
            if (filter.MaxTotalCost.HasValue) apartments = apartments.Where(a => a.totalCost <= filter.MaxTotalCost).ToList();
            if (filter.AvailableDate.HasValue) apartments = apartments.Where(a => a.availableDate == filter.AvailableDate).ToList();
            return apartments;
        }
    }
}
