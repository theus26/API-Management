using API_PeopleManagement.Extensions;
using API_PeopleManagement.Service.AutoMapper;

namespace API_PeopleManagement
{
    public class Startup(IConfiguration configuration)
    {
        private readonly string OpenCors = "_openCors";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructure(configuration);
            services.AddApplication();
            services.AddAuth();
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.AddEndpointsApiExplorer();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
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
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
