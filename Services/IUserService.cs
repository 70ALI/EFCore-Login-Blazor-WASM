using BlazorAppLogin.Dtos;
using BlazorAppLogin.Entities;

namespace BlazorAppLogin.Services
{
    public interface IUserService
	{
		List<UserDto> Users { get; set; }
		LoginDto Login { get; set; }
		Task GetUsers();
		Task<bool> GetSingleUser(LoginDto log);
		Task CreateUser(UserDto user);
	}
}