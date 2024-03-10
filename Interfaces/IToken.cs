using MyRent.Model;

namespace MyRent.Interfaces
{
    public interface IToken
    {
        public string CreateToken(AppUser user,string role);
    }
}
