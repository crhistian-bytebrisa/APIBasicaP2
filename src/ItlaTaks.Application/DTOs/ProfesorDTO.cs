using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.DTOs
{
    public class ProfesorDTO 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<int> MateriasId { get; set; } = new();
        public List<MateriaDTO> Materias { get; set; } = new();
    }
}
