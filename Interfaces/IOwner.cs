using HomeRenterService.Dtos.Apartment;
using Microsoft.EntityFrameworkCore.Update.Internal;
using MyRent.Dtos.Apartment;
using MyRent.Model;

namespace MyRent.Interfaces
{
    public interface IOwner
    {
        public Task<Owner> GetAllInfo(string username);
        public Task<List<Apartment>> GetAllApartments(string username);
        public Task<Apartment> AddApartment(Apartment model);

        public Task<Apartment> DeleteApartmentById(string username,string id);

        public Task<Apartment> GetApartmentById(string id);

        public Task<Apartment> updateApartment(UpdateApartmentDto dto, string id);
    }
}
