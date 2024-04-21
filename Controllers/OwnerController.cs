using AutoMapper;
using HomeRenterService.Dtos.Apartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using MyRent.DbContext;
using MyRent.Dtos.Account;
using MyRent.Dtos.Apartment;
using MyRent.Extention;
using MyRent.Interfaces;
using MyRent.Model;

namespace MyRent.Controllers
{
    [ApiController]
    [Route("Owner")]
    public class OwnerController : Controller
    {
        private readonly IOwner _owner;
        private readonly IGettingIds _ids;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public OwnerController(IOwner owner, IGettingIds ids, IFileService fileService, IMapper mapper) {
            _owner = owner;
            _ids = ids;
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpGet("userinfo")]
        [Authorize(Roles ="Owner")]
        public async Task<IActionResult> GetUserInfo() {
            string UserName = User.GetUsername();
            var OwnerModel = await _owner.GetAllInfo(UserName);
            if(OwnerModel == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<AccountDetailsDto>(OwnerModel); 
            return Ok(dto);
        
        }
        [HttpGet("showAllApartments")]
        [Authorize(Roles ="Owner")]
        public async Task<IActionResult> ShowApartmentList()
        {
            string UserName = User.GetUsername();
            var apartments = await _owner.GetAllApartments(UserName);
            if(apartments == null) { return Ok(); }
            var apartmentdtos = new List<CreatedApartmentDto>();
            foreach (var apt in apartments)
            {
                apartmentdtos.Add(_mapper.Map<CreatedApartmentDto>(apt));
            }
            return Ok(apartmentdtos);
        }

        [HttpPost("AddApartments")]
        [Authorize(Roles ="Owner")]
        public async Task<IActionResult> AddApartments([FromForm] FormApartmentDto formApartment)
        {
            string UserName = User.GetUsername();
            string ownerId = await _ids.getOwnerId(UserName);
            if (ownerId == null) { return BadRequest("authentication error"); }
            //var model = formApartment.ToApartmentModel(ownerId);
            
            var model = _mapper.Map<Apartment>(formApartment);
            model.OwnerId = ownerId;
            var images = formApartment.Images;

            var newModel = await  _owner.AddApartment(model);
            var succass = await _fileService.SaveImage(images, model.Id);
            if (succass == null) { return BadRequest("could not save"); }

            return Ok(_mapper.Map<CreatedApartmentDto>(newModel));
            
        }

        [HttpDelete("DeleteApartment/:id")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> DeleteApartment(string id)
        {
           bool ImageDeleSucc = _fileService.DeleteImage(id);
            if (!ImageDeleSucc) return BadRequest("image not found");
           var status = await _owner.DeleteApartmentById(User.GetUsername(), id);
           if(status==null) { return BadRequest("Apartment couldn't deleted"); }
            return Ok("Deleted succassfully");

        }
        [HttpGet("Apartment/:id")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> GetApartment(string id)
        {
            var apartment = await _owner.GetApartmentById(id);
            if (apartment==null) { return NotFound(id); }
            return Ok(apartment);   
        }

        [HttpPut("Apartment/:id")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> UpdateApartment([FromForm] UpdateApartmentDto dto,string id)
        {
            //var model = dto.ToApartmentModelUpdate(id);
            var apartment = await _owner.updateApartment(dto, id);
            if (apartment==null) { NotFound(); }

            var images = dto.Images;
            if (images != null)
            {
                _fileService.DeleteImage(id);
                var result = _fileService.SaveImage(images, id);
                if(result==null) { return BadRequest("something went wrong"); }
            } 
            return Ok(apartment);   
        }


    }
}
