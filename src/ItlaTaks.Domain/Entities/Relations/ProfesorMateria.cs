using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Domain.Entities.Relations
{
    public class ProfesorMateria
    {
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public int MateriaId { get; set; }  
        public Materia Materia { get; set; }
    }
}
