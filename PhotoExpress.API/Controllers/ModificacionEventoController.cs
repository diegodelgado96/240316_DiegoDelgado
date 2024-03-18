using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PhotoExpress.BLL.Services.Contratos;
using PhotoExpress.DTO;
using PhotoExpress.API.Utility;
using PhotoExpress.BLL.Services;

namespace PhotoExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModificacionEventoController : ControllerBase
    {
        private readonly IModificacionEventoService modificacionEventoService;

        public ModificacionEventoController(IModificacionEventoService modificacionEventoService)
        {
            this.modificacionEventoService = modificacionEventoService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<ModificacionEventoDTO>>();

            try
            {
                response.Success = true;
                response.Value = await modificacionEventoService.Lista();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.msg = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ModificacionEventoDTO modificacionEventoDTO)
        {
            var response = new Response<ModificacionEventoDTO>();

            try
            {
                response.Success = true;
                response.Value = await modificacionEventoService.create(modificacionEventoDTO);
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
