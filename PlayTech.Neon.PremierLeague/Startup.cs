using Microsoft.OpenApi.Models;
using PlayTech.Neon.PremierLeague.Domain.Services;
using PlayTech.Neon.PremierLeague.Domain.Validation;
using PlayTech.Neon.PremierLeague.Repository;

namespace PlayTech.Neon.PremierLeague
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "PlayTech.Neon.PremierLeague", Version = "v1" });
            });
            services.AddTransient<IPlayerSelectionService, PlayerSelectionService>();
            services.AddTransient<IPlayerSelectionValidationRule, MaximumBudgetPlayerSelectionValidationRule>();
            services.AddTransient<IPlayerSelectionValidationRule, SameClubPlayerSelectionValidationRule>();
            services.AddTransient<IPlayerSelectionValidationRule, TotalNumberPlayerSelectionValidationRule>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlayTech.Neon.PremierLeague v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
