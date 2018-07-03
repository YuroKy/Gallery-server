using Gallery.Server.Data;
using Gallery.Server.Data.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Gallery.Server.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.RequireHttpsMetadata = false;
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidIssuer = AuthOptions.ISSUER,
							ValidateAudience = true,
							ValidAudience = AuthOptions.AUDIENCE,
							ValidateLifetime = true,
							IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
							ValidateIssuerSigningKey = true,
						};
					});

			services.AddCors();
			services.AddMvc();
		}
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials());
			app.UseMvc();
		}
	}
}
