using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Models
{
    public class ProfesorMateriaModel
    {
        [ForeignKey("Profesor")]
        public int IdProfesor { get; set; }
        public ProfesorModel Profesor { get; set; }

        public int MateriaId { get; set; }  
        public MateriaModel Materia { get; set; }

        public ProfesorMateriaModel()
        {
                
        }
    }
}
