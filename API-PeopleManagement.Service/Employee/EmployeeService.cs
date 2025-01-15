using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API_PeopleManagement.Service.Employee;

public class EmployeeService(IBaseRepository<Employees> employeeRepository, 
    IMapper mapper, IValidator<Employees> employeeValidator, 
    IChangeRecordsService changeRecordsService) : IEmployeeService
{
    public EmployeeDto CreateEmployee(CreateEmployeesDto createEmployee)
    {
        var employee = mapper.Map<Employees>(createEmployee);
        Validate(employee);
        var createdEmployee = employeeRepository.Create(employee);
        return mapper.Map<EmployeeDto>(createdEmployee);
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
            { "Name", (employee.Name, employeeDto.Name) },
            { "Position", (employee.Position, employeeDto.Position) },
            { "Wage", (employee.Wage.ToString(), employeeDto.Wage?.ToString()) },
        };

        var historyEntries = new List<ChangeRecordDto>();
        var changedBy = employee.Name;
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
                case "Name":
                    employee.Name = employeeDto.Name!;
                    break;
                case "Position":
                    employee.Position = employeeDto.Position!;
                    break;
                case "Wage":
                    employee.Wage = employeeDto.Wage ?? employee.Wage;
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
        var employeeExist = employeeRepository.Get(employeeId);
        if (employeeExist is null)
        {
            throw new KeyNotFoundException("Employee not found");
        }
        employeeRepository.Delete(employeeId);
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
                    .Include(x => x.VacationRecords)
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
                .Include(x => x.VacationRecords)
                .AsNoTracking()
                .ToList();
        
        if (employees is null)
        {
            throw new Exception("employees not found");
        }
        return mapper.Map<ICollection<EmployeeDto>>(employees);
    }

    public double GetAverageSalary()
    {
        return employeeRepository.GetAll()
            .AsNoTracking()
            .Where(x=> x.IsActive)
            .Select(x => x.Wage)
            .Average();
    }

    private void Validate(Employees employees)
    {
        var validationResult = employeeValidator.Validate(employees);

        if (validationResult.IsValid) return;
        var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
        throw new ValidationException($"Validation failed: {errors}");
    }
}