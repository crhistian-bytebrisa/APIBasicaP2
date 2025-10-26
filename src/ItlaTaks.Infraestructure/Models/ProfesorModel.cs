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

        [Required, MaxLength(100), MinLength(3)]
        public string Nombre { get; set; }

        [Required, MaxLength(150), MinLength(5)]
        public string Apellido { get; set; }

        //Navegacion de la relacion muchos a muchos
        public List<ProfesorMateriaModel> ProfesorMaterias { get; set; }

        //Navegacion de la relacion uno a muchos
        public List<TareaModel> Tareas { get; set; }    

        public ProfesorModel()
        {
                
        }
    }
}
