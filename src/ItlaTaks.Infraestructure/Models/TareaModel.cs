using ItlaTaks.Domain.Core;
using ItlaTaks.Domain.Entities;
using ItlaTaks.Infraestructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Models
{
    [Table("Tareas")]
    public class TareaModel 
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100), MinLength(10)]
        public string Titulo { get; set; }

        [Required, MaxLength(200), MinLength(20)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaEntrega { get; set; }

        [Required]
        public int Puntos { get; set; }

        [Required]
        public bool EsGrupal { get; set; } = false;

        [Required, ForeignKey("Profesor")]
        public int ProfesorId { get; set; }
        public ProfesorModel Profesor { get; set; }

        [Required, ForeignKey("Materia")]
        public int MateriaId { get; set; }
        public MateriaModel Materia { get; set; }

        [Required]
        public TareaEstado Estado { get; set; } = TareaEstado.PENDIENTE;
        public TareaModel()
        {
                
        }
    }
}
