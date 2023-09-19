using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas.Services.PersonaService
{
  public interface IPersonaService
  {
    Task<List<Persona>> GetAllPersonas();
    Task<Persona> GetPersonaById(int id);
    Task<List<Persona>> AddPersona(Persona newPersona);
  }
}

