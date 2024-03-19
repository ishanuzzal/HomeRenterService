using Microsoft.AspNetCore.Mvc;
using HomeRenterService.Interfaces;
using MyRent.DbContext;
using MyRent.Dtos.Apartment;
using HomeRenterService.Dtos.Apartment;
using MyRent.Model;
namespace HomeRenterService.Controllers
{
    [ApiController]
    public class RenterController : Controller
    {
        private readonly IRenter _renter;
        private readonly ApplicationDbContext _context;
        public RenterController(IRenter renter, ApplicationDbContext context) {
            _renter = renter;
            _context = context;
        }
        [HttpGet]
        [Route("allApartments/{MinSize?}/{MaxSize?}/{MaxTotalCost?}/{MinTotalCost?}/{AvailableDate?}")]
        public async Task<IActionResult> ViewAllApartments(
                int? MinSize,
                int? MaxSize,
                int? MaxTotalCost,
                int? MinTotalCost,
                DateTime? AvailableDate
            ) {
            var apartmentFilter = new ApartmentFilter
            {
                MinSize = MinSize,
                MaxSize = MaxSize,
                MaxTotalCost = MaxTotalCost,
                MinTotalCost = MinTotalCost,
                AvailableDate = AvailableDate
            };
            List<Apartment> allApartment = await _renter.GetAllApartments(apartmentFilter);
            if(allApartment == null) { NotFound(); }
            return Ok(allApartment);
        }
    }
}
