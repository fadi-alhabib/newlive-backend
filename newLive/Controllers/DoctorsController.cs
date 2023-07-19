
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "IT admin")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _doctorsRepo;

        public DoctorsController(IDoctorsRepository doctorsRepo)
        {
            _doctorsRepo = doctorsRepo;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllDoctors()
        {
            IEnumerable<DoctorsWithSectionsDto> doctors = await _doctorsRepo.GetAllDoctorsWithSections();
            return Ok(doctors);
        }
        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorsDto doctorsDto)
        {
            Doctorsinfo doctor = await _doctorsRepo.AddDoctor(doctorsDto);
            return Ok(doctor);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            bool deleteResult = await _doctorsRepo.DeleteDoctorById(id);
            if (deleteResult == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
