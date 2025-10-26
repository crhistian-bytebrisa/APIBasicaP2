using ItlaTaks.Application.DTOs.Enums;
using ItlaTaks.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.DTOs.CreateDTO
{
    public class TareaCDTO 
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int Puntos { get; set; }
        public bool EsGrupal { get; set; }
        public int ProfesorId { get; set; }
        public int MateriaId { get; set; }
        public TareaEstado Estado { get; set; } = TareaEstado.PENDIENTE;
        public TareaCDTO()
        {
                
        }

        public TareaCDTO(string titulo, string descripcion, DateTime fecha, int puntos,bool grupal, int profesorid, int materiaid)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            FechaEntrega = fecha;
            Puntos = puntos;
            EsGrupal = grupal;
            ProfesorId = profesorid;
            MateriaId = materiaid;
        }
    }
}
