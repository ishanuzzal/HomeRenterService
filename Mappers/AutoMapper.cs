using AutoMapper;
using HomeRenterService.Dtos.Apartment;
using HomeRenterService.Dtos;
using MyRent.Model;
using MyRent.Dtos.Apartment;
using MyRent.Dtos.Account;
using HomeRenterService.Dtos.Image;
using System.IO;
namespace HomeRenterService.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() {

            CreateMap<Images, ImageDto>();

            CreateMap<Apartment, AllApartmentDto>();
                /*.ForMember(dest => dest.Images, src => src.MapFrom(e => e.images.Select(image => new ImageDto
                {
                    path = image.path,
                    uploadDate = image.uploadDate,

                }).ToList()));*/

            CreateMap<FormApartmentDto, Apartment>()
                .ForMember(dest => dest.images, opt => opt.Ignore());

            CreateMap<Apartment, AllApartmentDto>().ReverseMap();
            CreateMap<Apartment, UpdateApartmentDto>().ReverseMap();
            CreateMap<Apartment, CreatedApartmentDto>();
            CreateMap<AccountDetailsDto, Owner>().ReverseMap();
            CreateMap<AccountDetailsDto, Renter>();
            CreateMap<RegisterDto, Owner>()
                .ForMember(Dest => Dest.UserName, src => src.MapFrom(x => x.UserName))
                .ForMember(Dest => Dest.FullName, src => src.MapFrom(x => x.FullName))
                .ForMember(Dest => Dest.EmailAddress, src => src.MapFrom(x => x.EmailAddress))
                .ForMember(Dest => Dest.Address, src => src.MapFrom(x => x.Address))
                .ForMember(Dest => Dest.PhoneNo, src => src.MapFrom(x => x.PhoneNumber));

            CreateMap<RegisterDto, Renter>()
                .ForMember(Dest => Dest.UserName, src => src.MapFrom(x => x.UserName))
                .ForMember(Dest => Dest.FullName, src => src.MapFrom(x => x.FullName))
                .ForMember(Dest => Dest.EmailAddress, src => src.MapFrom(x => x.EmailAddress))
                .ForMember(Dest => Dest.Address, src => src.MapFrom(x => x.Address))
                .ForMember(Dest => Dest.PhoneNo, src => src.MapFrom(x => x.PhoneNumber));


        }
    }
}
