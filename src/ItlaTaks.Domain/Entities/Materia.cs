using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Domain.Entities
{
    public class Materia : Entity
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }

        public List<Profesor> Profesores { get; set; }
        public Materia()
        {
                
        }
    }
}
