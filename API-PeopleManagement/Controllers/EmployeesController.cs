using API_PeopleManagement.Authenticate;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.DTO.vacations;
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
    [ManagementAuthenticate(Roles = "Adm, Exe, Fin")]
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
    [ManagementAuthenticate(Roles = "Adm, Exe, Fin")]
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
    [ManagementAuthenticate(Roles = "Adm")]
    public async Task<IActionResult> CreateEmployee([FromQuery] Guid positionId, [FromBody] CreateEmployeesDto employeesDto)
    {
        try
        {
            var employee = await employeeService.CreateEmployee(positionId, employeesDto);
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
    public async Task<IActionResult> CreateVacationRecords([FromBody] CreateVacationRecordDto vacationRecordDto)
    {
        try
        {
            var vacationRecord = await vacationService.CreateVacation(vacationRecordDto);
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
    [ManagementAuthenticate(Roles = "Adm")]
    public IActionResult UpdateEmployee([FromQuery] Guid userId, [FromBody] UpdateEmployeeDto employeeDto)
    {
        try
        {
            var employeeUpdated = employeeService.UpdateEmployee(userId, employeeDto);
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
    [ManagementAuthenticate(Roles = "Adm")]
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