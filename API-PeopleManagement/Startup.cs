using API_PeopleManagement.Extensions;

namespace API_PeopleManagement
{
    public class Startup(IConfiguration configuration)
    {
        private readonly string OpenCors = "_openCors";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructure(configuration);
            //services.AddApplication();
            //services.AddAuth();
            //services.AddHostedService<EvaluateCampaign>();
            //services.AddHostedService<EvaluatePendingCampaign>();
            //services.AddAutoMapper(typeof(Mappers));
            //services.AddHttpClient("EvolutionAPI", client =>
            //{
            //    client.BaseAddress = new Uri("http://api:8080");
            //});
            //services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(30);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});
            services.AddEndpointsApiExplorer();
            services.AddCors(options =>
            {
                options.AddPolicy(name: OpenCors,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.WithMethods("PUT", "DELETE", "GET", "POST");
                        builder.AllowAnyHeader();
                    });
            });
            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(OpenCors);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
