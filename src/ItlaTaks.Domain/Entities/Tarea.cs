using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Domain.Entities
{
    public class Tarea : Entity
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int Puntos { get; set; }
        public bool EsGrupal { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        public Tarea()
        {
                
        }
    }
}
