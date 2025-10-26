using ItlaTaks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Models
{
    public class MateriaModel
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(60),MinLength(10)]
        public string Nombre { get; set; }
        [Required]
        public int Creditos { get; set; }

        //Navegacion de la relacion muchos a muchos
        public List<ProfesorMateriaModel> ProfesorMaterias { get; set; }
        public List<TareaModel> Tareas { get; set; }

        public MateriaModel()
        {
                
        }
    }
}
