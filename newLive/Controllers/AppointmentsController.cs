using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLive.Dtos;
using newLive.Interfaces;
using newLive.Models;

namespace newLive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }
        [HttpGet, Authorize(Roles = "IT admin")]
        public async Task<IActionResult> GetAllAppointments()
        {
            IEnumerable<Booktbl> appointments = await _appointmentsRepository.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpGet, Route("{name}")]
        public async Task<IActionResult> GetAppointmentByName(string name)
        {
            Booktbl appointment = await _appointmentsRepository.GetAppointmentByPName(name);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentsDto appointmentDto)
        {
            Booktbl appointment = await _appointmentsRepository.AddAppointment(appointmentDto);
            if (appointment == null)
            {
                return BadRequest();
            }
            return Ok(appointment);
        }
    }
}
