
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using T1.Data;
using T1.Repositories;
using T1.Repositories.IRepositories;

namespace T1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// ------------------------------ Database Connection -------------------------------------
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


			// Automapper
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

			// Repository
			builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

			var app = builder.Build();

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
	}
}
