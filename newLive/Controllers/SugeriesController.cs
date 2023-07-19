using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugeriesController : ControllerBase
    {
        private readonly ISurgeriesRepository _surgeryRepo;

        public SugeriesController(ISurgeriesRepository surgeriesRepository)
        {
            _surgeryRepo = surgeriesRepository;
        }

        [HttpPost, Authorize(Roles = "IT admin")]
        public async Task<IActionResult> AddSurgery([FromBody] SurgeryDto surgeryDto)
        {
            Surgerytblinfo surgery = await _surgeryRepo.AddSurgery(surgeryDto);
            return Ok(surgery);
        }


        [HttpGet, Authorize(Roles = "IT admin")]
        public async Task<IActionResult> GetAllSurgeries()
        {
            IEnumerable<Surgerytblinfo> surgeries = await _surgeryRepo.GetAllSurgeries();
            return Ok(surgeries);
        }

        [HttpGet, Route("doctor/{doctorName}"), Authorize(Roles = "doctor, IT admin")]
        public async Task<IActionResult> GetSurgeriesByDoctorName(string doctorName)
        {
            IEnumerable<Surgerytblinfo> surgeries = await _surgeryRepo.GetSurgeriesByDoctorName(doctorName);
            return Ok(surgeries);
        }
        [HttpGet, Route("{PID}"), AllowAnonymous]
        public async Task<IActionResult> GetSurgeryByPID(int PID)
        {
            Surgerytblinfo surgery = await _surgeryRepo.GetSurgeryByPID(PID);
            if (surgery == null)
            {
                return NotFound();
            }
            return Ok(surgery);
        }
    }
}
