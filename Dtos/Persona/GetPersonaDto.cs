using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas.Dtos.Persona
{
  public class GetPersonaDto
  {
    public int Id { get; set; }
    public string Nombres { get; set; } = "Anonimo";
    public string Apellidos { get; set; } = "";
    public string Cedula { get; set; } = "999999";
  }
}

