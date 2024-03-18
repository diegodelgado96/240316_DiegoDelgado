using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;
using PhotoExpress.BLL;
using PhotoExpress.BLL.Services.Contratos;
using PhotoExpress.DAL.Repositorios;
using PhotoExpress.DAL.Repositorios.Contrato;
using PhotoExpress.DTO;
using PhotoExpress.Model;

namespace PhotoExpress.BLL.Services
{
    public class ModificacionEventoService: IModificacionEventoService
    {
        private readonly IGenericRepository<ModificacionEvento> _modificacionEventoRepository;
        public readonly IMapper _mapper;

        public ModificacionEventoService(IGenericRepository<ModificacionEvento> modificacionEventoRepository, IMapper mapper)
        {
            _modificacionEventoRepository = modificacionEventoRepository;
            _mapper = mapper;
        }

        public async Task<List<ModificacionEventoDTO>> Lista()
        {
            try
            {
                var eventos = await _modificacionEventoRepository.Search();
                return _mapper.Map<List<ModificacionEventoDTO>>(eventos.ToList());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModificacionEventoDTO> create(ModificacionEventoDTO modificacionEventoDTO)
        {
            try
            {
                modificacionEventoDTO.ModificacionId = Guid.NewGuid();
                var modificacionEvento = await _modificacionEventoRepository.Create(_mapper.Map<ModificacionEvento>(modificacionEventoDTO));

                if (modificacionEvento.ModificacionId == Guid.Empty)
                    throw new TaskCanceledException("No fue posible crear la modificación del evento");

                var query = await _modificacionEventoRepository.Get(e => e.ModificacionId == modificacionEvento.ModificacionId);

                return _mapper.Map<ModificacionEventoDTO>(query);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
