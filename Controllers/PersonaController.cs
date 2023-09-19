using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace personas.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class PersonaController : ControllerBase
  {
    private readonly IPersonaService _personaService;

    public PersonaController(IPersonaService personaService) {
      _personaService = personaService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetPersonaDto>>>> Get()
    {
      return Ok(await _personaService.GetAllPersonas());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetPersonaDto>>> GetSingle(int id)
    {
      return Ok(await _personaService.GetPersonaById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetPersonaDto>>>> AddPersona(AddPersonaDto newPersona)
    {
      return Ok(await _personaService.AddPersona(newPersona));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetPersonaDto>>>> UpdatePersona(UpdatePersonaDto updatedPersona)
    {
      var response = await _personaService.UpdatePersona(updatedPersona);
      if (response.Data is null) {
        return NotFound(response);
      }

      return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetPersonaDto>>> DeletePersona(int id)
    {
      var response = await _personaService.DeletePersona(id);
      if (response.Data is null) {
        return NotFound(response);
      }

      return Ok(response);
    }
  }
}

