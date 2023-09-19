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

    public async Task<List<Persona>> AddPersona(Persona newPersona)
    {
      personas.Add(newPersona);
      return personas;
    }

    public async Task<List<Persona>> GetAllPersonas()
    {
      return personas;
    }

    public async Task<Persona> GetPersonaById(int id)
    {
      var persona = personas.FirstOrDefault(p => p.Id == id);

      if (persona is not null)
        return persona;

      throw new Exception("Persona not found");
    }
  }
}
