using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.DTOs.CreateDTO
{
    public class MateriaCDTO 
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }

        public MateriaCDTO()
        {
                
        }
    }
}
