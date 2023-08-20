using BlazorAppLogin.Dtos;
using BlazorAppLogin.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorAppLogin.Services
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;
		private readonly NavigationManager _nav;
		public UserService(HttpClient httpClient, NavigationManager nav)
		{
			_httpClient = httpClient;
			_nav = nav;
		}
		public List<UserDto> Users { get; set; } = new List<UserDto>();
		public LoginDto Login { get; set; } = new LoginDto();
		public async Task CreateUser(UserDto user)
		{
			try
			{
				var result = await _httpClient.PostAsJsonAsync("api/user/createuser", user);
				await result.Content.ReadAsStringAsync();
				Users.Add(user);
			}
			catch (Exception)
			{
				throw;
			}
		}
		// to confirm the user
		public async Task<bool> GetSingleUser(LoginDto logn)
		{
			try
			{
			var result = await _httpClient.PostAsJsonAsync("api/user/login", logn);
			bool response = await result.Content.ReadFromJsonAsync<bool>();
			if (response == true)
			{
				_nav.NavigateTo("/User", true); return true;
			}
			return false;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task GetUsers()
		{
			try
			{
				var result = await _httpClient.GetFromJsonAsync<List<UserDto>>("api/user/getusers");
				if (result != null)
				{
					Users = result;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}