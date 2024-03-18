using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoExpress.DTO
{
    public class ModificacionEventoDTO
    {
        public Guid ModificacionId { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string DetalleAnterior { get; set; } = null!;

        public string DetalleActual { get; set; } = null!;

        public Guid EventoId { get; set; }
    }
}
