using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PhotoExpress.BLL.Services.Contratos;
using PhotoExpress.DTO;
using PhotoExpress.API.Utility;

namespace PhotoExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService eventoService;

        public EventoController(IEventoService eventoService)
        {
            this.eventoService = eventoService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<EventoDTO>>();

            try
            {
                response.Success = true;
                response.Value = await eventoService.Lista();

            }catch (Exception ex)
            {
                response.Success=false;
                response.msg = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] EventoDTO eventoDTO)
        {
            var response = new Response<EventoDTO>();

            try
            {
                response.Success = true;
                response.Value = await eventoService.create(eventoDTO);
            }catch (Exception ex)
            {
                response.Success = false;
                response.msg = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] EventoDTO eventoDTO)
        {
            var response = new Response<bool>();

            try
            {
                response.Success = true;
                response.Value = await eventoService.update(eventoDTO);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.msg = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = new Response<bool>();

            try
            {
                response.Success = true;
                response.Value = await eventoService.delete(id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.msg = ex.Message;
            }

            return Ok(response);
        }
    }
}
