using API_PeopleManagement.Authenticate;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.user;
using API_PeopleManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_PeopleManagement.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUserService userService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult HeathCheck()
    {
        return Ok("I´am alive");
    }
    
    [HttpPost]
    [AllowAnonymous]
    public IActionResult SignIn(SignInDto signInDto)
    {
        try
        {
            var result = userService.SignIn(signInDto.Email, signInDto.Password);
            return Ok(result);
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
    public IActionResult GetDetailUser()
    {
        try
        {
            var subject = HttpContext.Session.GetString("Subject");
            var userId = Guid.Parse(subject);
            var detailUser = userService.GetUserInformationById(userId);
            return Ok(detailUser);

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

