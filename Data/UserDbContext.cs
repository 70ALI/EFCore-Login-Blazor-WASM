using BlazorAppLogin.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppLogin.Data
{
	public class UserDbContext : DbContext
	{

		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 1,
				FullName = "Ali Abdullah",
				Email = "ali@ali.com",
				Password = 123456,
				PhoneNumber = 0533371201,
				Address = "Riyadh"

			});


		}

		public DbSet<User> Users { get; set; }
	}
}