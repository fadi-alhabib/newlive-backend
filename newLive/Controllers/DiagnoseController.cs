using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnoseController : ControllerBase
    {
        private readonly IDiagnoseRepository _diagnouseRepo;

        public DiagnoseController(IDiagnoseRepository diagnouseRepository)
        {
            _diagnouseRepo = diagnouseRepository;
        }

        [HttpPost, Authorize(Roles = "doctor")]
        public async Task<IActionResult> AddDiagnouse(DiagnouseDto diagnouseDto)
        {
            Dignose diagnouse = await _diagnouseRepo.AddDiagnouseByDoctor(diagnouseDto);
            return Ok(diagnouse);
        }

        [HttpGet, Route("{pid}")]
        public async Task<IActionResult> GetDiagnouse(int pid)
        {
            Dignose? diagnouse = await _diagnouseRepo.GetDiagnouseByPID(pid);
            if (diagnouse == null)
            {
                return NotFound();
            }
            return Ok(diagnouse);
        }
    }
}
