using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "IT admin, doctor")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _patientsRepo;

        public PatientsController(IPatientsRepository patientsRepository)
        {
            _patientsRepo = patientsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients() => Ok(await _patientsRepo.GetAllPatients());

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientsDto patientsDto)
        {
            Patientinfo patient = await _patientsRepo.AddPatient(patientsDto);
            if (patient == null)
            {
                return BadRequest();
            }
            return Ok(patient);
        }
        [HttpGet, Route("{pid}"), Authorize("doctor")]
        public async Task<IActionResult> GetPatientByID(int pid)
        {
            Patientinfo? patient = await _patientsRepo.GetPatientByID(pid);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}
