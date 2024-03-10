using MyRent.Dtos.Apartment;
using MyRent.Model;

namespace MyRent.Interfaces
{
    public interface IOwner
    {
        public Task<Owner> GetAllInfo(string username);
        public Task<List<Apartment>> GetAllApartments(string username);
        public Task<Apartment> AddApartment(Apartment model);
    }
}
