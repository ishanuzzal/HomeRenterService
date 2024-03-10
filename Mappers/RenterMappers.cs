using MyRent.Dtos.Account;
using MyRent.Model;

namespace MyRent.Mappers
{
    public static class RenterMappers
    {
        public static AccountDetailsDto ToRenterAccountDetailsDto(this Renter renter)
        {
            return new AccountDetailsDto
            {
                UserName = renter.UserName,
                FullName = renter.FullName,
                EmailAddress = renter.EmailAddress,
                Address = renter.Address,
                PhoneNumber = renter.PhoneNo

            };
        }

        public static Renter ToRenterModel(this RegisterDto RegisterDto, string Id)
        {
            return new Renter
            {
                UserName = RegisterDto.UserName,
                FullName = RegisterDto.FullName,
                EmailAddress = RegisterDto.EmailAddress,
                Address = RegisterDto.Address,
                PhoneNo = RegisterDto.PhoneNumber,
                AppUserId = Id

            };
        }
    }
}
