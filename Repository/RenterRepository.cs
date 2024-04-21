using HomeRenterService.Dtos.Apartment;
using HomeRenterService.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyRent.DbContext;
using MyRent.Model;

namespace HomeRenterService.Repository
{
    public class RenterRepository : IRenter
    {
        private readonly ApplicationDbContext _context;
        public RenterRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<List<Apartment>> GetAllApartments(ApartmentSearch filter, int PageSize, int PageNumber)
        {
            int skip = (PageNumber - 1)*PageSize;
            int take = PageSize;
            List<Apartment> apartments = await _context.apartments.Include(e=>e.images).ToListAsync();
            if (filter.MinSize.HasValue) apartments = apartments.Where(a => a.Size >= filter.MinSize).ToList();
            if (filter.MaxSize.HasValue) apartments = apartments.Where(a => a.Size <= filter.MaxSize).ToList();
            if (filter.MinPrice.HasValue) apartments = apartments.Where(a => a.totalCost >= filter.MinPrice).ToList();
            if (filter.MaxPrice.HasValue) apartments = apartments.Where(a => a.totalCost <= filter.MaxPrice).ToList();
            if (filter.Date.HasValue) apartments = apartments.Where(a => a.availableDate == filter.Date).ToList();
            apartments = apartments.Skip(skip).Take(take).ToList();
            return apartments;
        }

        public async Task<Apartment> GetApartmentById(string id)
        {
            return await _context.apartments.Where(e => e.Id == id).Include(e => e.images).FirstOrDefaultAsync();
        }
    }
}
