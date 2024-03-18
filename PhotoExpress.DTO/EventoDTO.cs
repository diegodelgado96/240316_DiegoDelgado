using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoExpress.DTO
{
    public class EventoDTO
    {
        public Guid EventoId { get; set; }

        public string NombreInstitucion { get; set; } = null!;

        public string DireccionInstitucion { get; set; } = null!;

        public int NumeroAlumnos { get; set; }

        public DateTime FechaInicio { get; set; }

        public double CostoServicio { get; set; }

        public bool TogaBirrete { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string NumeroReferencia { get; set; } = null!;

    }
}
