using Microsoft.EntityFrameworkCore;
using MyRent.DbContext;
using MyRent.Interfaces;

namespace MyRent.Helpers
{
    public class GetUsersId:IGettingIds
    {
        private readonly ApplicationDbContext _context;
        public GetUsersId(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<string> getOwnerId(string username)
        {
            var owner = await _context.owners.FirstOrDefaultAsync(e=>e.UserName==username);
            return owner.Id;
        }

        public Task<string> getRenterId(string username)
        {
            throw new NotImplementedException();
        }

        
    }
}
