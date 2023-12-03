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
        public async Task<IActionResult> signUp([FromBody] SignUpModel signUp)
        {   
            var result = await _account.SignUpAsync(signUp);    
            if(result.Succeeded) 
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();

        }

        
    }
}
