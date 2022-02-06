using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMedia.Data;
using AMedia.Data.Response;

namespace AMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<tPelicula>> oRespuesta = new Respuesta<List<tPelicula>>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    var lst = db.tPelicula.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<tPelicula> oRespuesta = new Respuesta<tPelicula>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    var lst = db.tPelicula.Find(Id);
                    oRespuesta.Data = lst;
                    if (oRespuesta.Data == null)
                    {
                        oRespuesta.Exito = 0;
                    }
                    else
                    {
                        oRespuesta.Exito = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(tPelicula model)
        {
            tPelicula oRespuesta = new tPelicula();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tPelicula otPelicula = new tPelicula();
                    otPelicula.txt_desc = model.txt_desc;
                    otPelicula.cant_disponibles_alquiler= model.cant_disponibles_alquiler;
                    otPelicula.cant_disponibles_venta = model.cant_disponibles_venta;
                    otPelicula.precio_alquiler = model.precio_alquiler;
                    otPelicula.precio_venta = model.precio_venta;

                    db.tPelicula.Add(otPelicula);
                    db.SaveChanges();
                    oRespuesta = otPelicula;
                }

            }
            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                oRespuesta = null;

            }

            return Ok(oRespuesta);
        }
        [HttpPut]
        public IActionResult Edit(tPelicula model)
        {
            Respuesta<tPelicula> oRespuesta = new Respuesta<tPelicula>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tPelicula otPelicula = db.tPelicula.Find(model.cod_pelicula);
                    otPelicula.txt_desc = model.txt_desc;
                    otPelicula.cant_disponibles_alquiler = model.cant_disponibles_alquiler;
                    otPelicula.cant_disponibles_venta = model.cant_disponibles_venta;
                    otPelicula.precio_alquiler = model.precio_alquiler;
                    otPelicula.precio_venta = model.precio_venta;
                    db.Entry(otPelicula);
                    db.tPelicula.Add(otPelicula).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<tPelicula> oRespuesta = new Respuesta<tPelicula>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tPelicula otPelicula = db.tPelicula.Find(Id);
                    db.Remove(otPelicula);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
