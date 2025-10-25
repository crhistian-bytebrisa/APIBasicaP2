using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Domain.Entities
{
    public class Profesor : Entity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public List<Materia> Materia { get; set; }
    }
}
