using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoExpress.DTO;

namespace PhotoExpress.BLL.Services.Contratos
{
    public interface IEventoService
    {
        Task<List<EventoDTO>> Lista();
        Task<EventoDTO> create(EventoDTO eventoDTO);
        Task<bool> update(EventoDTO eventoDTO);
        Task<bool> delete(Guid id);

    }
}
