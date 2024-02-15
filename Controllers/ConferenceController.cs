using AutoMapper;
using log4net;
using Main_Assessment.DTOs;
using Main_Assessment.Entity;
using Main_Assessment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Main_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceService _conferenceService;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public ConferenceController(IConferenceService conferenceService, IMapper mapper, ILog logger)
        {
            _conferenceService = conferenceService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")] 
        public IActionResult GetAllConferences()
        {
            try
            {
                List<Conference> conferences = _conferenceService.GetAllConferences();
                List<ConferenceDto> conferenceDtos = _mapper.Map<List<ConferenceDto>>(conferences);
                return StatusCode(200, conferenceDtos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateConference([FromBody] ConferenceDto conferenceDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Conference conference = _mapper.Map<Conference>(conferenceDto);
                _conferenceService.CreateConference(conference);
                return StatusCode(200, conference);
            }
            catch (Exception ex)
            {
                // Include inner exception details in the response
                string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                _logger.Error(errorMessage);
                return StatusCode(500, errorMessage);
            }
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditConference(int id, [FromBody] ConferenceDto conferenceDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Conference existingConference = _conferenceService.GetConference(id);
                if (existingConference == null)
                {
                    return NotFound();
                }

                Conference conference = _mapper.Map<Conference>(conferenceDto);
                _conferenceService.EditConference(id, conference);
                return StatusCode(200, conference);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConference(int id)
        {
            try
            {
                Conference existingConference = _conferenceService.GetConference(id);
                if (existingConference == null)
                {
                    return NotFound();
                }

                _conferenceService.DeleteConference(id);
                return StatusCode(200, new JsonResult($"Conference with Id {id} has been deleted."));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("validate")]
        public IActionResult ValidateConference([FromBody] Conference conference)
        {
            try
            {
                if (!_conferenceService.ValidateConference(conference))
                {
                    return BadRequest("Invalid conference data.");
                }

                return Ok("Conference data is valid.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("GetConferenceByName/{title}")]
        public IActionResult GetConferenceByName(string title)
        {
            try
            {
                var conference = _conferenceService.GetConferenceByName(title);
                if (conference == null)
                {
                    return NotFound("Conference not found");
                }
                return Ok(conference);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetConferenceByID(int id)
        {
            try
            {
                Conference conference = _conferenceService.GetConference(id);
                if (conference == null)
                {
                    return NotFound();
                }
                return Ok(conference);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
