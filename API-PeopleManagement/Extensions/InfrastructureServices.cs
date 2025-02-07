using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Interfaces;
using API_PeopleManagement.Infra.Data.Context;
using API_PeopleManagement.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_PeopleManagement.Extensions
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContextPool<PeopleManagementContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBaseRepository<Employees>, BaseRepository<Employees>>();
            services.AddScoped<IBaseRepository<ChangeRecord>, BaseRepository<ChangeRecord>>();
            services.AddScoped<IBaseRepository<VacationRecord>, BaseRepository<VacationRecord>>();
            services.AddScoped<IBaseRepository<Users>, BaseRepository<Users>>();
            services.AddScoped<IBaseRepository<Unit>, BaseRepository<Unit>>();
            services.AddScoped<IBaseRepository<Positions>, BaseRepository<Positions>>();
            services.AddScoped<IBaseRepository<EmployeePosition>, BaseRepository<EmployeePosition>>();
     
            return services;
        }
    }
}
