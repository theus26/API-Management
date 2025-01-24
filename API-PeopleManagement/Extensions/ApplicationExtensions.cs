using API_PeopleManagement.Domain.Commands;
using API_PeopleManagement.Domain.Commands.Employee;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Interfaces;
using API_PeopleManagement.Service;
using API_PeopleManagement.Service.ChangeRecord;
using API_PeopleManagement.Service.Employee;
using API_PeopleManagement.Service.Vacation;
using API_PeopleManagement.Service.Validators;
using FluentValidation;

namespace API_PeopleManagement.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Service
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IVacationService, VacationService>();
        services.AddScoped<IChangeRecordsService, ChangeRecordService>();
        
        // Handler
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<EmployeeCommandHandler>();
        
        //Validate
        services.AddScoped<IValidator<Employees>, EmployeeValidator>();
        services.AddScoped<IValidator<VacationRecord>, VacationValidator>();
        
        return services;
    }
}