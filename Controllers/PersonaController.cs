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
    public async Task<ActionResult<ServiceResponse<List<Persona>>>> Get()
    {
      return Ok(await _personaService.GetAllPersonas());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Persona>>> GetSingle(int id)
    {
      return Ok(await _personaService.GetPersonaById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Persona>>>> AddPersona(Persona newPersona)
    {
      return Ok(await _personaService.AddPersona(newPersona));
    }
  }
}

