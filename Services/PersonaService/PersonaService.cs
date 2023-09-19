using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas.Services.PersonaService
{
  public class PersonaService : IPersonaService
  {
    private static List<Persona> personas = new List<Persona> {
      new Persona { Nombres = "Cmauricio" },
      new Persona { Id = 1, Nombres = "Carlos" }
    };

    public async Task<ServiceResponse<List<Persona>>> AddPersona(Persona newPersona)
    {
      var serviceResponse = new ServiceResponse<List<Persona>>();
      personas.Add(newPersona);
      serviceResponse.Data = personas;
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<Persona>>> GetAllPersonas()
    {
      var serviceResponse = new ServiceResponse<List<Persona>>();
      serviceResponse.Data = personas;
      return serviceResponse;
    }

    public async Task<ServiceResponse<Persona>> GetPersonaById(int id)
    {
      var serviceResponse = new ServiceResponse<Persona>();
      var persona = personas.FirstOrDefault(p => p.Id == id);
      serviceResponse.Data = persona;
      return serviceResponse;
    }
  }
}
