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

        public AdminContorller(IAccountRepo accountRepo, IbaseRepository<Doctors> basedoctor, IbaseRepository<Patient> basepatient)
        {
            _accountRepo = accountRepo;
            _basedoctor = basedoctor;
            _basepatient = basepatient;
        }

        [HttpPost("CreateDoctorAccount")]
        public async Task<IActionResult> signUp([FromBody] SignUpModel signUp)
        {
            var result = await _accountRepo.SignUpAsync(signUp);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }


            return Unauthorized();

        }
        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors()
        {
            return Ok(_basedoctor.GetAll());
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
        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            return Ok(_basepatient.GetAll());
        }
        [HttpGet("GetPatientByID/{id}")]
        public IActionResult GetPatientById([FromRoute] int id)
        {
            return Ok(_basepatient.GetByID(id));    
        }
        [HttpDelete("RemovePatient /{id}")]
        public IActionResult DeleteByPatientId(int id)
        {
            _basepatient.DeleteById(id);
            return Ok();
        }

    }
    
}
