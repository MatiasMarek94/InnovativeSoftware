using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using InnovativeSoftware.Data;
using InnovativeSoftware.DTOs;
using InnovativeSoftware.Entities;
using InnovativeSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InnovativeSoftware.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto
             registerDto)
        {

            if (await UserExist(registerDto.UserName))
            {
                return BadRequest("Username is taken");
            }
            
            using var hmac = new HMACSHA512();
            
            var user = new AppUser
            {
                User = registerDto.UserName.ToLower(),
                TokenIFTT = registerDto.IfttToken, 
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return new UserDto()
            {
                Username = user.User,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.User == loginDto.Username);
            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("invalid password");
                }
            }
            
            return new UserDto()
            {
                Username = user.User,
                Token = _tokenService.CreateToken(user)
            }; 

        }
        
        private async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.User == username.ToLower());
        }
    }
}