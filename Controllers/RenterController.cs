using Microsoft.AspNetCore.Mvc;
using HomeRenterService.Interfaces;
using MyRent.DbContext;
using MyRent.Dtos.Apartment;
using HomeRenterService.Dtos.Apartment;
using MyRent.Model;
using Microsoft.AspNetCore.Authorization;
using MyRent.Interfaces;
using AutoMapper;
namespace HomeRenterService.Controllers
{
    [ApiController]
    [Route("Renter")]
    public class RenterController : Controller
    {
        private readonly IRenter _renter;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RenterController(IRenter renter, ApplicationDbContext context, IMapper mapper) {
            _renter = renter;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Apartments/:id")]
        public async Task<IActionResult> GetApartment(string id)
        {
            var apartment = await _renter.GetApartmentById(id);
            if (apartment == null) { return NotFound(id); }
            return Ok(apartment);
        }

        [HttpGet("ViewAllApartment")]
        public async Task<IActionResult> ViewAllApartments([FromQuery] ApartmentSearch apartmentSearch, int PageSize = 3, int PageNumber = 1)
        {
            if (PageSize <= 0 || PageNumber <= 0)
            {
                return BadRequest("PageSize and PageNumber must be greater than 0.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _renter.GetAllApartments(apartmentSearch, PageSize, PageNumber);

                var dto = result.Select(r => _mapper.Map<AllApartmentDto>(r));

                return Ok(dto);
            }
            catch (Exception ex) { 

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

    }
}
