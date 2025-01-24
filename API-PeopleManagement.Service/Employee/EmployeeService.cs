using API_PeopleManagement.Domain.Commands;
using API_PeopleManagement.Domain.Commands.Employee;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API_PeopleManagement.Service.Employee;

public class EmployeeService(IBaseRepository<Employees> employeeRepository, 
    IMapper mapper, IValidator<Employees> employeeValidator, 
    IChangeRecordsService changeRecordsService, EmployeeCommandHandler commandHandler) : IEmployeeService
{
    public async Task<EventInserted> CreateEmployee(CreateEmployeesDto createEmployee)
    {
        var employeeCommand = mapper.Map<InsertEmployeeCommand>(createEmployee);
        return await commandHandler.HandleCommand(employeeCommand);
    }

    public EmployeeDto UpdateEmployee(Guid employeeId, UpdateEmployeeDto employeeDto)
    { 
        var employee = employeeRepository.Get(employeeId);
        if (employee is null)
        {
            throw new KeyNotFoundException("Employee not found");
        }

        var changes = new Dictionary<string, (string OldValue, string? NewValue)>
        {
            { "NameEmployee", (employee.NameEmployee, employeeDto.NameEmployee) },
            { "CTPS", (employee.CTPS, employeeDto.CTPS)! },
            { "PisPasep", (employee.PisPasep, employeeDto.PisPasep)! },
            { "DateOfBirth", (employee.DateOfBirth?.ToString("yyyy-MM-dd"), employeeDto.DateOfBirth?.ToString("yyyy-MM-dd"))! },
            { "Rg", (employee.Rg, employeeDto.Rg)! },
            { "Cpf", (employee.Cpf, employeeDto.Cpf)! },
            { "EmailEmployee", (employee.EmailEmployee, employeeDto.EmailEmployee)! },
            { "PhoneNumber", (employee.PhoneNumber, employeeDto.PhoneNumber)! },
            { "Observations", (employee.Observations, employeeDto.Observations)! },
            { "BankDetails", (employee.BankDetails, employeeDto.BankDetails)! },
            { "UnitId", (employee.UnitId?.ToString(), employeeDto.UnitId?.ToString())! }
        };

        var historyEntries = new List<ChangeRecordDto>();
        var changedBy = employee.NameEmployee;
        foreach (var change in changes.Where(change => 
                     !string.IsNullOrEmpty(change.Value.NewValue) && change.Value.OldValue != change.Value.NewValue))
        {
            historyEntries.Add(new ChangeRecordDto
            {
                EmployeesId = employeeId,
                DateAndTimeOfChange = DateTime.UtcNow,
                ChangedField = change.Key,
                OldValue = change.Value.OldValue,
                NewValue = change.Value.NewValue!,
                ChangedBy = changedBy
            });
            
            switch (change.Key)
            {
                case "NameEmployee":
                    employee.NameEmployee = employeeDto.NameEmployee!;
                    break;
                case "CTPS":
                    employee.CTPS = employeeDto.CTPS;
                    break;
                case "PisPasep":
                    employee.PisPasep = employeeDto.PisPasep;
                    break;
                case "DateOfBirth":
                    employee.DateOfBirth = employeeDto.DateOfBirth;
                    break;
                case "Rg":
                    employee.Rg = employeeDto.Rg;
                    break;
                case "Cpf":
                    employee.Cpf = employeeDto.Cpf;
                    break;
                case "EmailEmployee":
                    employee.EmailEmployee = employeeDto.EmailEmployee;
                    break;
                case "PhoneNumber":
                    employee.PhoneNumber = employeeDto.PhoneNumber;
                    break;
                case "Observations":
                    employee.Observations = employeeDto.Observations;
                    break;
                case "BankDetails":
                    employee.BankDetails = employeeDto.BankDetails;
                    break;
                case "IsActive":
                    employee.IsActive = employeeDto.IsActive;
                    break;
                case "UnitId":
                    employee.UnitId = employeeDto.UnitId;
                    break;
            }
        }

        foreach (var history in historyEntries)
        {
            changeRecordsService.AddChangeRecord(history);
        }

        var updatedEmployee = employeeRepository.Update(employee);
        return mapper.Map<EmployeeDto>(updatedEmployee);
    }

    public void DeleteEmployee(Guid employeeId)
    {
        if (employeeId == Guid.Empty)
        {
            throw new KeyNotFoundException("Please, enter a valid employeeId ID");
        }
        var deleteCommand = new DeleteEmployeeCommand(employeeId);
        commandHandler.HandleCommand(deleteCommand);
    }

    public EmployeeDto GetEmployeeById(Guid employeeId)
    {
        if (employeeId == Guid.Empty)
        {
            throw new KeyNotFoundException("Please, enter a valid employeeId ID");
        }

        var employees = employeeRepository
                    .GetAll()
                    .AsNoTracking()
                    .Where(x => x.Id == employeeId)
                    .Include(x => x.VacationRecord)
                    .FirstOrDefault();
        
        if (employees is null)
        {
            throw new KeyNotFoundException("employee not found");
        }
        return mapper.Map<EmployeeDto>(employees);
    }

    public ICollection<EmployeeDto> GetAllEmployees()
    {
        var employees = employeeRepository.GetAll()
                .Where(x => x.IsActive)
                .Include(x => x.VacationRecord)
                .AsNoTracking()
                .ToList();
        
        if (employees is null)
        {
            throw new Exception("employees not found");
        }
        return mapper.Map<ICollection<EmployeeDto>>(employees);
    }

    // public double GetAverageSalary()
    // {
    //     return employeeRepository.GetAll()
    //         .AsNoTracking()
    //         .Where(x=> x.IsActive)
    //         //.Select(x => x.Wage)
    //         //.Average();
    // }

    private void Validate(Employees employees)
    {
        var validationResult = employeeValidator.Validate(employees);

        if (validationResult.IsValid) return;
        var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
        throw new ValidationException($"Validation failed: {errors}");
    }
}