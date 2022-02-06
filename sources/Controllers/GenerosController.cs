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
    public class GenerosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<tGenero>> oRespuesta = new Respuesta<List<tGenero>>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    var lst = db.tGenero.ToList();
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
            Respuesta<tGenero> oRespuesta = new Respuesta<tGenero>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    var lst = db.tGenero.Find(Id);
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
        public IActionResult Add(tGenero model)
        {
            tGenero oRespuesta = new tGenero();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tGenero otGenero = new tGenero();
                    otGenero.txt_desc = model.txt_desc;

                    db.tGenero.Add(otGenero);
                    db.SaveChanges();
                    oRespuesta = otGenero;
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
        public IActionResult Edit(tGenero model)
        {
            Respuesta<tGenero> oRespuesta = new Respuesta<tGenero>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tGenero otGenero = db.tGenero.Find(model.cod_genero);
                    otGenero.txt_desc = model.txt_desc;
                    db.Entry(otGenero);
                    db.tGenero.Add(otGenero).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<tGenero> oRespuesta = new Respuesta<tGenero>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tGenero otGenero = db.tGenero.Find(Id);
                    db.Remove(otGenero);
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
