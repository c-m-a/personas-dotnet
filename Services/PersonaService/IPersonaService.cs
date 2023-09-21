using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas.Services.PersonaService
{
  public interface IPersonaService
  {
    Task<ServiceResponse<List<GetPersonaDto>>> GetAllPersonas();
    Task<ServiceResponse<GetPersonaDto>> GetPersonaById(int id);
    Task<ServiceResponse<GetPersonaDto>> AddPersona(AddPersonaDto newPersona);
    Task<ServiceResponse<GetPersonaDto>> UpdatePersona(UpdatePersonaDto updatedPersona);
    Task<ServiceResponse<List<GetPersonaDto>>> DeletePersona(int id);
  }
}

