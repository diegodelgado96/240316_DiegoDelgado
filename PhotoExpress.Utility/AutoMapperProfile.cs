using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using PhotoExpress.DTO;
using PhotoExpress.Model;

namespace PhotoExpress.Utility
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            #region Evento
            CreateMap<Evento, EventoDTO>().ReverseMap();
            #endregion

            #region ModificacionEvento
            CreateMap<ModificacionEvento, ModificacionEventoDTO>().ReverseMap();
            #endregion
        }
    }
}
