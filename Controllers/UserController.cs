using BlazorAppLogin.Data;
using BlazorAppLogin.Dtos;
using BlazorAppLogin.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        public UserController(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        [HttpGet("getusers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                var Users = await _userDbContext.Users.ToListAsync();
                return Ok(Users);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<bool>> GetSingleUser([FromBody] LoginDto logn)
        {
            try
            {
                var user = await _userDbContext.Users.SingleOrDefaultAsync(l => l.Email == logn.Email && l.Password == logn.Password);

                if (user != null)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("createuser")]
        public async Task<ActionResult<bool>> CreateUser([FromBody] UserDto user)
        {
            try
            {
                var entityUser = new User
                {
                    Address = user.Address,
                    Email = user.Email,
                    FullName = user.FullName,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber
                };
                await _userDbContext.Users.AddAsync(entityUser);
                await _userDbContext.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}