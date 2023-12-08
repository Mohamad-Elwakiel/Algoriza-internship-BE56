using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IAccountRepo _account;
        private readonly IbaseRepository<Requests> _baseRequest;
        public DoctorController(IAccountRepo account, IbaseRepository<Requests> baseRequest)
        {
            _account = account;
            _baseRequest = baseRequest;

        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> signIn([FromBody] SignInModel signIn)
        {
            var result = await _account.LoginAsync(signIn);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);

        }
        [HttpPost("Create Booking")]
        public IActionResult createBooking([FromForm] Requests request)
        {
            _baseRequest.Add(request);

            return Ok();
        }
    
    }
}
