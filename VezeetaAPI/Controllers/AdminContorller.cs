using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminContorller : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IbaseRepository<Doctors> _basedoctor;
        private readonly IbaseRepository<Patient> _basepatient;
        private readonly IbaseRepository<Discount> _discount;
        public AdminContorller(IAccountRepo accountRepo, IbaseRepository<Doctors> basedoctor, IbaseRepository<Patient> basepatient
            , IbaseRepository<Discount> discount)
        {
            _accountRepo = accountRepo;
            _basedoctor = basedoctor;
            _basepatient = basepatient;
            _discount = discount;
        }

        [HttpPost("CreateDoctorAccount")]
        public async Task<IActionResult> signUp([FromForm] SignUpModel signUp, [FromForm] List<Specalization> specs)
        {
            var result = await _accountRepo.SignUpAsync(signUp, specs);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }


            return Unauthorized();

        }
        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors([FromForm] int page, [FromForm] int pageSize)
        {
            return Ok(_basedoctor.GetAllByPage(page, pageSize));
        }

        [HttpGet("GetDoctorByID/{id}")]
        public IActionResult GetDoctorByID([FromRoute] int id)
        {
            return Ok(_basedoctor.GetByID(id));
        }
        [HttpDelete("RemoveDoctor /{id}")]
        public IActionResult DeleteDoctorById(int id)
        {
            _basedoctor.DeleteById(id);
            return Ok();
        }
        [HttpPost("Update Doctor")]
        public IActionResult UpdateDoctor([FromForm] Doctors doctors)
        {
            _basedoctor.Update(doctors);

            return Ok();
        }

        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients([FromForm] int page, [FromForm] int pageSize)
        {
            return Ok(_basepatient.GetAllByPage(page, pageSize));
        }

        [HttpGet("GetPatientByID/{id}")]
        public IActionResult GetPatientById([FromRoute] int id)
        {
            return Ok(_basepatient.GetByID(id));
        }
        [HttpGet("number of patients")]
        public IActionResult GetNumberOfPatients()
        {
            return Ok(_basepatient.GetAll().Count());
        }
        [HttpGet("number of doctors")]
        public IActionResult GetNumberOfDoctors()
        {
            return Ok(_basedoctor.GetAll().Count());
        }
        [HttpGet("top 10 doctors")]
        public IActionResult GetTopTenDoctors()
        {
            return Ok(_basedoctor.GetTopTenDoctors());
        }
        [HttpGet("Top 5 specialization")]
        public IActionResult GetTopFiveSpec()
        {
            return Ok(_basedoctor.GetTopFiveSpecalizations());
        }
        [HttpPost("Add Discount")]
        public IActionResult addDiscount([FromForm] Discount discount)
        {
            _discount.Add(discount);
            return Ok();
        }
        [HttpPost("Update Discount")]
        public IActionResult updateDiscount([FromForm] Discount discount)
        {
            _discount.Update(discount);
            return Ok();
        }
        [HttpDelete("Delete Discount")]
        public IActionResult DeleteDiscount(int id) 
        {
            _discount.DeleteById(id);   
            return Ok();    
        }

    }
    
}
