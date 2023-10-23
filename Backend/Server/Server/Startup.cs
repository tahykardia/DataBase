using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Database.Repositories.ComputerInfoRepository;
using Database.Repositories.CPURepository;
using Database.Repositories.GPURepository;
using Database.Repositories.RAMRepository;
using Database.Repositories.SSDRepository;
using Database;

namespace Server
{
	public class Startup
	{
		private readonly string _corsPolicy = "AskBmstuFm";
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			//Кофигурация
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEntityFrameworkNpgsql().AddDbContext<LabDbContext>(options =>
				options.UseNpgsql(Configuration.GetConnectionString("Laba"))
			);

			services.AddScoped<IComputerInfoRepository, ComputerInfoRepository>();
			services.AddTransient<ICPURepository, CPURepository>();
			services.AddTransient<IGPURepository, GPURepository>();
			services.AddTransient<IRAMRepository, RAMRepository>();
			services.AddTransient<ISSDRepository, SSDRepository>();

			services.AddControllers();
			services.AddHealthChecks();
			services.AddCors(o => o.AddPolicy(_corsPolicy, builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			UpdateDatabase(app);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(_corsPolicy);
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		private void UpdateDatabase(IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
			using var context = serviceScope.ServiceProvider.GetService<LabDbContext>();
			context.Database.EnsureCreated();
		}
	}
}
