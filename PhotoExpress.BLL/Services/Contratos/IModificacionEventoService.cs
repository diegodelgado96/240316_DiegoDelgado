using PhotoExpress.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhotoExpress.BLL.Services.Contratos
{
    public interface IModificacionEventoService
    {
        Task<List<ModificacionEventoDTO>> Lista();

        Task<ModificacionEventoDTO> create(ModificacionEventoDTO modificarEventoDTO);
    }
}
