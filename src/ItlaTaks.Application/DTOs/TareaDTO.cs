using ItlaTaks.Application.DTOs.Enums;
using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.DTOs
{
    public class TareaDTO 
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int Puntos { get; set; }
        public bool EsGrupal { get; set; }
        public int ProfesorId { get; set; }
        public ProfesorDTO Profesor { get; set; } = new();
        public int MateriaId { get; set; }
        public MateriaDTO Materia { get; set; } = new();
        public TareaEstado Estado { get; set; } = new();

        public TareaDTO()
        {
                
        }


    }
}
