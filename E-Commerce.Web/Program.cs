
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;

namespace E_Commerce.Web
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IDbInitializer, DbInitializer>();
			builder.Services.AddDbContext<StoreDbContext>(options =>
			{
				var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
				options.UseSqlServer(connectionString);
			});
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			await InitializeDbAsync(app);
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
		public static async Task InitializeDbAsync(WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var dbInitializer=scope.ServiceProvider.GetRequiredService<IDbInitializer>();
			await dbInitializer.InitializeAsync();
		}
	}
}
