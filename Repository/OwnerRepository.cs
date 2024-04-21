using HomeRenterService.Dtos.Apartment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyRent.DbContext;
using MyRent.Dtos.Apartment;
using MyRent.Interfaces;
using MyRent.Model;

namespace MyRent.Repository
{
    public class OwnerRepository:IOwner
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<OwnerRepository> _logger;
        public OwnerRepository(ApplicationDbContext context, UserManager<AppUser> userManager, ILogger<OwnerRepository> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<Apartment> AddApartment(Apartment model)
        {

            var result = await _context.apartments.AddAsync(model);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save apartment: " + ex.Message);
            }
            return result.Entity;

        }
        public async Task<List<Apartment>> GetAllApartments(string username)
        {
            var owner = await _context.owners.FirstOrDefaultAsync(o => o.UserName == username);
            if (owner == null) { return new List<Apartment>(); }
            var apartment = await _context.apartments.Where(e => e.OwnerId == owner.Id).Include(e=>e.images).ToListAsync();
            return apartment;
        }

        public async Task<Owner> GetAllInfo(string username)
        {
            
            var info = await _context.owners.FirstOrDefaultAsync(o => o.UserName== username);
            return info;
        }

        public async Task<Apartment> DeleteApartmentById(string username,string id)
        {
            try { 
            var apartment = await _context.apartments.FirstOrDefaultAsync(e=>e.Id==id);
            if (apartment == null) { return  null; }
            var OwnerUserName = (await _context.owners.FirstOrDefaultAsync(o => o.Id== apartment.OwnerId))?.UserName;
            if (OwnerUserName != username) return null;
            
                _context.apartments.Remove(apartment);
                await _context.SaveChangesAsync();
                return apartment;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "An error occurred while deleting the apartment.");
                return null;
            }
            
        }

        public async Task<Apartment> GetApartmentById(string id)
        {
            return await _context.apartments.Where(e => e.Id == id).Include(e => e.images).FirstOrDefaultAsync();
        }

        public async Task<Apartment> updateApartment(UpdateApartmentDto dto,string id)
        {
            var model = await _context.apartments.FindAsync(id);
            if (model == null) return null;
            model.Size = dto.Size;
            model.noRomms = dto.noRomms;
            model.noToilets = dto.noToilets;
            model.totalCost = dto.totalCost;
            model.Advance = dto.Advance;
            model.availableDate = dto.AvailableDate;

            await _context.SaveChangesAsync();
            return model;

        }
    }
}
