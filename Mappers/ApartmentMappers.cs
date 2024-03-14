using Microsoft.VisualBasic;
using MyRent.Dtos.Apartment;
using MyRent.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using MyRent.Mappers;
using HomeRenterService.Dtos.Image;

namespace MyRent.Mappers
{
    public static class ApartmentMappers
    {
        public static Apartment ToApartmentModel(this FormApartmentDto dto,string id)
        {
            return new Apartment
            {
                Area = dto.Area,
                Contact_No = dto.Contact_No,
                noRomms = dto.noRomms,
                noToilets = dto.noToilets,
                availableDate = DateOnly.FromDateTime(DateTime.Today),
                totalCost = dto.totalCost,
                Advance = dto.Advance,
                detials = dto.detials,
                OwnerId = id
            };
        }

        public static CreatedApartmentDto ToApartmentDto(this Apartment model)
        {
            return new CreatedApartmentDto
            {
                Area = model.Area,
                Contact_No = model.Contact_No,
                noRomms = model.noRomms,
                noToilets = model.noToilets,
                availableDate = model.availableDate,
                totalCost = model.totalCost,
                Advance = model.Advance,
                detials = model.detials,
                Images = model.images.Select(image => new ImageDto
                {
                    path = image.path,
                    uploadDate = image.uploadDate,

                }).ToList(),
            };

        }
    }
}
