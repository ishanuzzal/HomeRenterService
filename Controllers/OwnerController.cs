﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using MyRent.DbContext;
using MyRent.Dtos.Apartment;
using MyRent.Extention;
using MyRent.Interfaces;
using MyRent.Mappers;
using MyRent.Model;

namespace MyRent.Controllers
{
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwner _owner;
        private readonly IGettingIds _ids;
        private readonly IFileService _fileService;
        public OwnerController(IOwner owner, IGettingIds ids, IFileService fileService) {
            _owner = owner;
            _ids = ids;
            _fileService = fileService;
        }

        [HttpGet("userinfo")]
        [Authorize(Roles ="owner")]
        public async Task<IActionResult> GetUserInfo() {
            string UserName = User.GetUsername();
            var OwnerModel = await _owner.GetAllInfo(UserName);
            if(OwnerModel == null)
            {
                return NotFound();
            }
            var dto = OwnerModel.ToAccountDetailsDto();
            return Ok(dto);
        
        }
        [HttpGet("showAllApartments")]
        [Authorize(Roles ="owner")]
        public async Task<IActionResult> ShowApartmentList()
        {
            string UserName = User.GetUsername();
            var apartments = await _owner.GetAllApartments(UserName);
            if(apartments == null) { return Ok(); }
            var apartmentdtos = new List<CreatedApartmentDto>();
            foreach (var apt in apartments)
            {
                apartmentdtos.Add(apt.ToApartmentDto());
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
            var model = formApartment.ToApartmentModel(ownerId);
            var images = formApartment.Images;

            var newModel = await  _owner.AddApartment(model);
            var succass = await _fileService.SaveImage(images, model.Id);
            if (succass == null) { return BadRequest("could not save"); }

            return Ok(newModel.ToApartmentDto());
            
        }
    }
}
