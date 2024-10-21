using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/Edad.cs
namespace ProyeccionPoblacionalINEC.Models
{
    public class Edad
    {
        public int ValorEdad { get; set; }
        public int CantidadHombres { get; set; }
        public int CantidadMujeres { get; set; }
        public int PrimariaIncompleta { get; set; }
        public int PrimariaCompleta { get; set; }
        public int SecundariaCompleta { get; set; }
        public int SecundariaIncompleta { get; set; }
        public int UniversitariaCompleta { get; set; }
        public int UniversitariaIncompleta { get; set; }
        public int SinEstudios { get; set; }
        public int TotalPoblacion { get; set; }
    }
}
