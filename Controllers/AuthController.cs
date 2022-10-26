using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swiggy.Dto;
using Swiggy.Interfaces;
using Swiggy.Models;
using Swiggy.Response_Model;

namespace Swiggy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepo = authRepository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            try
            {
                ServiceResponse<int> response = await _authRepo.Register(
                    new User { Username = request.Username }, request.Password);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            try
            {
                ServiceResponse<string> response = await _authRepo.Login(
                    request.Username, request.Password);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return (IActionResult)ex;
            }
        }
    }
}
