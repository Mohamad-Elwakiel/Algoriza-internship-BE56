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
        private readonly IBookingRepo _bookingRepo; 
        public DoctorController(IAccountRepo account, IbaseRepository<Requests> baseRequest, IBookingRepo bookingRepo)
        {
            _account = account;
            _baseRequest = baseRequest;
            _bookingRepo = bookingRepo; 
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
        [HttpPost("Confirm Booking/{id}")]
        public IActionResult confirmBooking([FromRoute] int id, [FromForm] Requests req)
        {
            _bookingRepo.ConfirmBooking(id, req);
            return Ok();

        }
        [HttpPost("Update Booking")]
        public IActionResult updateBooking([FromForm] Requests req)
        {
            _baseRequest.Update(req);
            return Ok();    
        }
        [HttpDelete("Delete booking/{id}")]
        public IActionResult delteBooking(int id)
        {
            _bookingRepo.DeleteBooking(id);
            return Ok();    
        }
        [HttpGet("Get All Bookings")]
        public IActionResult getAllBooking([FromForm] int page, [FromForm] int pageSize) 
        {
            return Ok(_baseRequest.GetAllByPage(page, pageSize));  

        }
    }
}
