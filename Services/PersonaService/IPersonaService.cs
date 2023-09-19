using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas.Services.PersonaService
{
  public interface IPersonaService
  {
    Task<ServiceResponse<List<Persona>>> GetAllPersonas();
    Task<ServiceResponse<Persona>> GetPersonaById(int id);
    Task<ServiceResponse<List<Persona>>> AddPersona(Persona newPersona);
  }
}

