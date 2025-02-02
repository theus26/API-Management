using API_PeopleManagement.Authenticate;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.position;
using API_PeopleManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_PeopleManagement.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class PositionsController(IPositionService positionService) : ControllerBase
{
    [HttpGet]
    public IActionResult HeathCheck()
    {
        return Ok("I´am alive");
    }
    
    [HttpGet]
    [ManagementAuthenticate(Roles = "Exe, Adm")]
    public IActionResult GetAllPositions()
    {
        try
        {
            var employees = positionService.GetAllPositions();
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
    [ManagementAuthenticate(Roles = "Exe")]
    public async Task<IActionResult> CreatePosition([FromBody] CreatePositionDto positionDto)
    {
        try
        {
            var employee = await positionService.CreatePosition(positionDto);
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
    

    [HttpPut]
    [ManagementAuthenticate(Roles = "Exe")]
    public IActionResult UpdatePosition([FromBody] UpdatePositionDto positionDto)
    {
        try
        {
            positionService.UpdatePosition(positionDto);
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
    
    [HttpDelete]
    [ManagementAuthenticate(Roles = "Exe")]
    public IActionResult DeletePosition([FromQuery] Guid positionId)
    {
        try
        {
            positionService.DeletePosition(positionId);
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