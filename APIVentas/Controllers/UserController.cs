using APIVentas.Models.Response;
using APIVentas.Models.ViewModels;
using APIVentas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;
        Respuesta respuesta = new Respuesta();

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AutRequest model)
        {
            var userRespons = _userServices.Auth(model);

            if (userRespons == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrectos";
                return BadRequest(respuesta);
            }

            respuesta.Exito = 1;
            respuesta.Data = userRespons;

            return Ok(respuesta);
        }
    }
}
