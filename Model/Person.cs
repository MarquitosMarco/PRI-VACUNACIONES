using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tag1.Model
{
    public class Person
    {
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public int UserID { get; set; }
    }
}
