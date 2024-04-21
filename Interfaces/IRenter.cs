using HomeRenterService.Dtos.Apartment;
using MyRent.Model;

namespace HomeRenterService.Interfaces
{
    public interface IRenter
    {
        public Task<List<Apartment>> GetAllApartments(ApartmentSearch apartmentSearch, int PageSize, int PageNumber);
        public Task<Apartment> GetApartmentById(string id);
    }
}
