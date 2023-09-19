using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace personas.Models {
  public class Persona
  {
    public int Id { get; set; }
    public string Nombres { get; set; } = "Anonimo";
    public string Apellidos { get; set; } = "";
    public string Cedula { get; set; } = "999999";
  }
}

