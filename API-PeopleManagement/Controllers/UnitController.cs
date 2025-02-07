using API_PeopleManagement.Authenticate;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_PeopleManagement.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class UnitController(IUnitService unitService) : ControllerBase
{
    [HttpGet]
    public IActionResult HeathCheck()
    {
        return Ok("I´am alive");
    }
    
    [HttpGet]
    [ManagementAuthenticate(Roles = "Adm")]
    public IActionResult GetAllUnits()
    {
        try
        {
            var employees = unitService.GetAllUnits();
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
    public async Task<IActionResult> CreateUnit([FromBody] CreateUnitDto unitDto)
    {
        try
        {
            var unit = await unitService.CreateUnit(unitDto);
            return Ok(unit);
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
    public IActionResult UpdateUnit(UnitDto unitDto)
    {
        try
        {
            var unit = unitService.UpdateUnit(unitDto);
            return Ok(unit);
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
    public IActionResult DeleteUnit([FromQuery] Guid unitId)
    {
        try
        {
            unitService.DeleteUnit(unitId);
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