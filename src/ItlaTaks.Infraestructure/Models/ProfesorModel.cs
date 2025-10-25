using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Models
{
    public class ProfesorModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(150)]
        public string Apellido { get; set; }

        //Navegacion de la relacion muchos a muchos
        public List<ProfesorMateriaModel> ProfesorMaterias { get; set; }

        public ProfesorModel()
        {
                
        }
    }
}
