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
        private readonly IbaseRepository<Doctors> _basedoctor;
        private readonly IbaseRepository<Requests> _baserequest;
        private readonly IBookingRepo _booking;
        public PatientController(IAccountRepo account, IbaseRepository<Doctors> basedoctor, IbaseRepository<Requests> baserequest
            ,IBookingRepo booking) 
        {
            _account = account;
            _basedoctor = basedoctor;  
            _baserequest = baserequest; 
            _booking = booking;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> signUp([FromForm] SignUpModel signUp, [FromForm]List<Specalization> specs)
        {   
            var result = await _account.SignUpAsync(signUp, specs);    
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
        [HttpGet("Get All Doctors")]
        public IActionResult GetAllDoctors(int page, int pageSize) 
        {
            return Ok(_basedoctor.GetAllByPage(page, pageSize));    
        }
        [HttpGet("Get All Bookings")]
        public IActionResult getAllBooking([FromForm] int page, [FromForm] int pageSize)
        {
            return Ok(_baserequest.GetAllByPage(page, pageSize));

        }
        [HttpDelete("Cancel Booking")]
        public IActionResult DeleteBooking (int id) 
        {
            _booking.DeleteBooking(id);
            return Ok();
            
        }


    }
}
