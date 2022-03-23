using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIVentas.Models;
using APIVentas.Models.Response;
using APIVentas.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace APIVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta mRespuesta = new Respuesta();
            mRespuesta.Exito = 0;

            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var lst = db.Clientes.OrderByDescending(d=>d.Id).ToList();
                    mRespuesta.Exito = 1;
                    mRespuesta.Data = lst;
                }
            }catch (Exception ex)
            {
                mRespuesta.Mensaje = ex.Message;
            }

            return Ok(mRespuesta);
                
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest cModel)
        {
            Respuesta mRespuesta = new Respuesta();
            //mRespuesta.Exito = 0; omito esta linea porq la incluyo desde el constructor de Respuesta

            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = cModel.Nombre;
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    mRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                mRespuesta.Mensaje = ex.Message;
            }

            return Ok(mRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest cModel)
        {
            Respuesta mRespuesta = new Respuesta();
            //mRespuesta.Exito = 0; omito esta linea porq la incluyo desde el constructor de Respuesta

            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Cliente cliente = db.Clientes.Find(cModel.Id);
                    cliente.Nombre = cModel.Nombre;
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                    db.SaveChanges();
                    mRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                mRespuesta.Mensaje = ex.Message;
            }

            return Ok(mRespuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta mRespuesta = new Respuesta();
            //mRespuesta.Exito = 0; omito esta linea porq la incluyo desde el constructor de Respuesta

            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Cliente cliente = db.Clientes.Find(id);
                    db.Remove(cliente);
                    db.SaveChanges();
                    mRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                mRespuesta.Mensaje = ex.Message;
            }

            return Ok(mRespuesta);
        }
        
    }
}
