using InnovativeSoftware.Entities;

namespace InnovativeSoftware.Services
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}