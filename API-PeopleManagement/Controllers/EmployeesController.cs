using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_PeopleManagement.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class EmployeesController(IEmployeeService employeeService, IVacationService vacationService): ControllerBase
{
    [HttpGet]
    public IActionResult HeathCheck()
    {
        return Ok("I´am alive");
    }
    
    [HttpGet]
    public IActionResult GetAverageSalary()
    {
        try
        {
            var averageSalary = employeeService.GetAverageSalary();
            return Ok(averageSalary);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto()
            {
                Status = StatusCodes.Status400BadRequest,
                Error = ex.Message,
            });
        }
    }
    
    [HttpGet]
    public IActionResult GetEmployeeById(Guid employeeId)
    {
        try
        {
            var employee = employeeService.GetEmployeeById(employeeId);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto()
            {
                Status = StatusCodes.Status400BadRequest,
                Error = ex.Message,
            });
        }
    }
    
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        try
        {
            var employees = employeeService.GetAllEmployees();
            return Ok(employees);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto()
            {
                Status = StatusCodes.Status400BadRequest,
                Error = ex.Message,
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeesDto employeesDto)
    {
        try
        {
            var employee = await employeeService.CreateEmployee(employeesDto);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto()
            {
                Status = StatusCodes.Status400BadRequest,
                Error = ex.Message,
            });
        }
    }
    
    [HttpPost]
    public IActionResult CreateVacationRecords([FromBody] CreateVacationRecordDto vacationRecordDto)
    {
        try
        {
            var vacationRecord = vacationService.CreateVacation(vacationRecordDto);
            return Ok(vacationRecord);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto()
            {
                Status = StatusCodes.Status400BadRequest,
                Error = ex.Message,
            });
        }
    }

    [HttpPut]
    public IActionResult UpdateEmployee([FromQuery] Guid employeeId, [FromBody] UpdateEmployeeDto employeeDto)
    {
        try
        {
            var employeeUpdated = employeeService.UpdateEmployee(employeeId, employeeDto);
            return Ok(employeeUpdated);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto()
            {
                Status = StatusCodes.Status400BadRequest,
                Error = ex.Message,
            });
        }
    }
    
    [HttpDelete]
    public IActionResult DeleteEmployee([FromQuery] Guid employeeId)
    {
        try
        {
            employeeService.DeleteEmployee(employeeId);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto()
            {
                Status = StatusCodes.Status400BadRequest,
                Error = ex.Message,
            });
        }
    }
}