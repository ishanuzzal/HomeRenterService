using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRent.DbContext;
using MyRent.Dtos.Apartment;
using MyRent.Interfaces;
using MyRent.Mappers;
using MyRent.Model;

namespace MyRent.Repository
{
    public class OwnerRepository:IOwner
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public OwnerRepository(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            var apartment = await _context.apartments.Where(e => e.OwnerId == owner.Id).ToListAsync();
            return apartment;
        }

        public async Task<Owner> GetAllInfo(string username)
        {
            
            var info = await _context.owners.FirstOrDefaultAsync(o => o.UserName== username);
            return info;
        }
    }
}
