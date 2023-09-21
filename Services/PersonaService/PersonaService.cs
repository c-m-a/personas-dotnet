using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas.Services.PersonaService
{
  public class PersonaService : IPersonaService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    private static List<Persona> personas = new List<Persona> {
      new Persona { Nombres = "Cmauricio" },
      new Persona { Id = 1, Nombres = "Carlos" }
    };

    public PersonaService(IMapper mapper, DataContext context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ServiceResponse<GetPersonaDto>> AddPersona(AddPersonaDto newPersona)
    {
      var serviceResponse = new ServiceResponse<GetPersonaDto>();
      var persona = _mapper.Map<Persona>(newPersona);

      _context.Personas.Add(persona);
      await _context.SaveChangesAsync();

      serviceResponse.Data = _mapper.Map<GetPersonaDto>(persona);
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetPersonaDto>>> GetAllPersonas()
    {
      var serviceResponse = new ServiceResponse<List<GetPersonaDto>>();
      var dbPersonas = await _context.Personas.ToListAsync();
      serviceResponse.Data = dbPersonas.Select(p => _mapper.Map<GetPersonaDto>(p)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetPersonaDto>> GetPersonaById(int id)
    {
      var serviceResponse = new ServiceResponse<GetPersonaDto>();
      var dbPersona = await _context.Personas.FindAsync(id);
      serviceResponse.Data = _mapper.Map<GetPersonaDto>(dbPersona);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetPersonaDto>> UpdatePersona(UpdatePersonaDto updatedPersona)
    {
      var serviceResponse = new ServiceResponse<GetPersonaDto>();

      try {
        // var persona = personas.FirstOrDefault(p => p.Id == updatedPersona.Id);
        var persona = await _context.Personas.FindAsync(updatedPersona.Id);

        if (persona is null)
          throw new Exception($"Persona with Id '{updatedPersona.Id}' not found.");

        _mapper.Map(updatedPersona, persona);

        persona.Nombres = updatedPersona.Nombres;
        persona.Apellidos = updatedPersona.Apellidos;
        persona.Cedula = updatedPersona.Cedula;

        serviceResponse.Data = _mapper.Map<GetPersonaDto>(persona);
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetPersonaDto>>> DeletePersona(int id)
    {
      var serviceResponse = new ServiceResponse<List<GetPersonaDto>>();

      try {
        // var persona = personas.First(p => p.Id == id);
        var persona = await _context.Personas.FindAsync(id);

        if (persona is null)
          throw new Exception($"Persona with Id '{id}' not found.");

        _context.Personas.Remove(persona);
        await _context.SaveChangesAsync();

        serviceResponse.Data = personas.Select(p => _mapper.Map<GetPersonaDto>(p)).ToList();
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }
  }
}
