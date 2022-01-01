using System;
using System.Text;
using AutoMapper;
using home.Data;
using home.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace home
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()));

			services.AddControllers();

			var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						// Clock skew compensates for server time drift.
						// We recommend 5 minutes or less:
						ClockSkew = TimeSpan.FromMinutes(0),

						// Specify the key used to sign the token:
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
						RequireSignedTokens = true,
						ValidateIssuerSigningKey = true,

						// Ensure the token hasn't expired:
						RequireExpirationTime = true,
						ValidateLifetime = true,

						// Ensure the token audience matches our audience value (default true):
						ValidateAudience = true,
						ValidAudience = Configuration["Jwt:Issuer"],

						// Ensure the token was issued by a trusted authorization server (default true):
						ValidateIssuer = true,
						ValidIssuer = Configuration["Jwt:Issuer"]
					};
				});

			services.AddScoped<LinkRepo>();
			services.AddScoped<UserRepo>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDbContextPool<HomeContext>(
				dbContextOptions => dbContextOptions
					.UseMySql(
						Configuration.GetConnectionString("home"),
						new MariaDbServerVersion(new Version(10, 6, 5))
					)
					.EnableSensitiveDataLogging()
					.EnableDetailedErrors()
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				scope.ServiceProvider.GetRequiredService<HomeContext>().Database.Migrate();
			}

			app.UseCors("AllowAll");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
