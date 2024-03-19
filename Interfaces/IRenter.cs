using HomeRenterService.Dtos.Apartment;
using MyRent.Model;

namespace HomeRenterService.Interfaces
{
    public interface IRenter
    {
        public Task<List<Apartment>> GetAllApartments(ApartmentFilter apartmentFilter);
    }
}
