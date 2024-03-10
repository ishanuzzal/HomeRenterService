using MyRent.Dtos.Account;
using MyRent.Model;
namespace MyRent.Mappers
{
    public static class OwnerMappers
    {
        public static AccountDetailsDto ToAccountDetailsDto(this Owner owner)
        {
            return new AccountDetailsDto
            {
                UserName = owner.UserName,
                FullName = owner.FullName,
                EmailAddress = owner.EmailAddress,
                Address = owner.Address,
                PhoneNumber = owner.PhoneNo

            };
        }

        public static Owner ToOwnerModel(this RegisterDto RegisterDto,string Id)
        {
            return new Owner
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
