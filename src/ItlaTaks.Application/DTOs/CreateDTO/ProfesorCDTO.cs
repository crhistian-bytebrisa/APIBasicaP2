using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.DTOs.CreateDTO
{
    public class ProfesorCDTO 
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<int> MateriaIds { get; set; }
        public ProfesorCDTO()
        {
            
        }
    }
}
