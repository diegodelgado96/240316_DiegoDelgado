using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using PhotoExpress.BLL;
using PhotoExpress.BLL.Services.Contratos;
using PhotoExpress.DAL.Repositorios.Contrato;
using PhotoExpress.DTO;
using PhotoExpress.Model;

namespace PhotoExpress.BLL.Services
{
    public class EventoService: IEventoService
    {
        private readonly IGenericRepository<Evento> _eventoRepository;
        public readonly IMapper _mapper;

        public EventoService(IGenericRepository<Evento> eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<List<EventoDTO>> Lista()
        {
            try
            {
                var eventos = await _eventoRepository.Search();
                return _mapper.Map<List<EventoDTO>>(eventos.ToList());

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO> create(EventoDTO eventoDTO)
        {
            try
            {
                DateTime now = DateTime.Now;
                string uniqueCode = string.Format("{0:yyyyMMddHHmmss}", now);
                eventoDTO.NumeroReferencia = uniqueCode;
                eventoDTO.EventoId = Guid.NewGuid();

                var evento = await _eventoRepository.Create(_mapper.Map<Evento>(eventoDTO));

                if (evento.EventoId == Guid.Empty)
                    throw new TaskCanceledException("No fue posible crear el Evento");

                var query = await _eventoRepository.Get(e => e.EventoId == evento.EventoId);

                return _mapper.Map<EventoDTO>(query);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> update(EventoDTO eventoDTO)
        {
            try
            {
                var eventoModel = _mapper.Map<Evento>(eventoDTO);

                var evento = await _eventoRepository.Get(e => e.EventoId == eventoModel.EventoId);

                if(evento == null)
                    throw new TaskCanceledException("El evento no existe");

                evento.NombreInstitucion    = eventoModel.NombreInstitucion;
                evento.DireccionInstitucion = eventoModel.DireccionInstitucion;
                evento.NumeroAlumnos        = eventoModel.NumeroAlumnos;
                evento.FechaInicio          = eventoModel.FechaInicio ;
                evento.CostoServicio        = eventoModel.CostoServicio;
                evento.TogaBirrete          = eventoModel.TogaBirrete;

                bool respuesta = await _eventoRepository.Update(evento);

                if(!respuesta)
                    throw new TaskCanceledException("No fue posible editar el Evento");

                return respuesta;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> delete(Guid id)
        {
            try
            {

                var evento = await _eventoRepository.Get(e => e.EventoId == id);

                if (evento == null)
                    throw new TaskCanceledException("El evento no existe");

                bool respuesta = await _eventoRepository.Delete(evento);

                if(!respuesta)
                    throw new TaskCanceledException("No fue posible Eliminar el Evento");

                return respuesta;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
