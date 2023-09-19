using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Persona, GetPersonaDto>();
      CreateMap<AddPersonaDto, Persona>();
      CreateMap<UpdatePersonaDto, Persona>();
    }
  }
}

