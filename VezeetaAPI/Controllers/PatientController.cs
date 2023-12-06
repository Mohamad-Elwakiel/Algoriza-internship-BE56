using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IAccountRepo _account;
        public PatientController(IAccountRepo account ) 
        {
            _account = account;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> signUp([FromForm] SignUpModel signUp)
        {   
            var result = await _account.SignUpAsync(signUp);    
            if(result.Succeeded) 
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();

        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> signIn([FromForm] SignInModel signIn)
        {
            var result = await _account.LoginAsync(signIn);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);

        }


    }
}
