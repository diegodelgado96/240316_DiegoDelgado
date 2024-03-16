using System;
using System.Collections.Generic;

namespace PhotoExpress.Model;

public partial class ModificacionEvento
{
    public Guid ModificacionId { get; set; }

    public DateTime FechaModificacion { get; set; }

    public string DetalleAnterior { get; set; } = null!;

    public string DetalleActual { get; set; } = null!;

    public Guid EventoId { get; set; }

    public virtual Evento Evento { get; set; } = null!;
}
