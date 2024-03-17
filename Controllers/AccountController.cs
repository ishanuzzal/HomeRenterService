using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyRent.Dtos.Account;
using MyRent.Model;
using MyRent.Services;
using MyRent.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyRent.DbContext;
using MyRent.Mappers;

namespace MyRent.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly ApplicationDbContext _context;
        private readonly IToken _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> usermanager, IToken tokenService, SignInManager<AppUser> appuser,ApplicationDbContext context)
        {
            _usermanager = usermanager;
            _tokenService = tokenService;
            _signInManager = appuser;
            _context = context;
        }
        [HttpPost("Owner/register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto rg)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appuser = new AppUser
                {
                    UserName = rg.UserName,
                    Email = rg.EmailAddress,
                    Role = "owner"
                };
                var createUser = await _usermanager.CreateAsync(appuser, rg.Password);
              
                if (createUser.Succeeded)
                {
                    var newOwner = rg.ToOwnerModel(appuser.Id);
                    var createOwner = await _context.owners.AddAsync(newOwner);
                    await _context.SaveChangesAsync();
                    string ownerId = createOwner.Entity.Id;
                    var roleResult = await _usermanager.AddToRoleAsync(appuser, "owner");
                    var roles = await _usermanager.GetRolesAsync(appuser);
                    string? role = roles.ToString();
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            UserName = appuser.UserName,
                            Token = _tokenService.CreateToken(appuser, role)
                        });
                    }
                    else return StatusCode(500, roleResult.Errors);
                }
                else return StatusCode(500, createUser.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("renter/register")]
        public async Task<IActionResult> RenterRegister([FromBody] RegisterDto rg)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appuser = new AppUser
                {
                    UserName = rg.UserName,
                    Email = rg.EmailAddress,
                    Role = "renter"
                };
                var createUser = await _usermanager.CreateAsync(appuser, rg.Password);
                if (createUser.Succeeded)
                {
                    var newRenter = rg.ToRenterModel(appuser.Id);
                    var createRenter = await _context.renters.AddAsync(newRenter);
                    await _context.SaveChangesAsync();
                    string id = createRenter.Entity.Id;
                    var roleResult = await _usermanager.AddToRoleAsync(appuser, "renter");
                    if (roleResult.Succeeded)
                    {
                        var roles = await _usermanager.GetRolesAsync(appuser);
                        string? role = roles.ToString();
                        return Ok(new NewUserDto
                        {
                            UserName = appuser.UserName,
                            Token = _tokenService.CreateToken(appuser, role)
                        }); 
                    }
                    else return StatusCode(500, roleResult.Errors);
                }
                else return StatusCode(500, createUser.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _usermanager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null) return Unauthorized("invalid username");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("username of password is incorrect");
            var roles = await _usermanager.GetRolesAsync(user);
            string? role = roles[0].ToString();

            return Ok(new NewUserDto
            {
                UserName = loginDto.UserName,
                Token = _tokenService.CreateToken(user, role)
            }) ;
        }
    }
}
