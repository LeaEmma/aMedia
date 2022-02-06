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
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<tUsers>> oRespuesta = new Respuesta<List<tUsers>>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    var lst = db.tUsers.ToList();
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
            Respuesta<tUsers> oRespuesta = new Respuesta<tUsers>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    var lst = db.tUsers.Find(Id);
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
        public IActionResult Add(tUsers model)
        {
            tUsers oRespuesta = new tUsers();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tUsers otUsers = new tUsers();
                    otUsers.txt_user = model.txt_user;
                    otUsers.txt_password = model.txt_password;
                    otUsers.txt_nombre = model.txt_nombre;
                    otUsers.txt_apellido = model.txt_apellido;
                    otUsers.nro_doc = model.nro_doc;
                    otUsers.cod_rol = model.cod_rol;
                    otUsers.sn_activo = model.sn_activo;                    

                    db.tUsers.Add(otUsers);
                    db.SaveChanges();
                    oRespuesta = otUsers;
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
        public IActionResult Edit(tUsers model)
        {
            Respuesta<tUsers> oRespuesta = new Respuesta<tUsers>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tUsers otUsers = db.tUsers.Find(model.cod_usuario);
                    otUsers.txt_user = model.txt_user;
                    otUsers.txt_password = model.txt_password;
                    otUsers.txt_nombre = model.txt_nombre;
                    otUsers.txt_apellido = model.txt_apellido;
                    otUsers.nro_doc = model.nro_doc;
                    otUsers.cod_rol = model.cod_rol;
                    otUsers.sn_activo = model.sn_activo;
                    db.Entry(otUsers);
                    db.tUsers.Add(otUsers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<tUsers> oRespuesta = new Respuesta<tUsers>();

            try
            {
                using (TestCrudContext db = new TestCrudContext())
                {
                    tUsers otUsers = db.tUsers.Find(Id);
                    db.Remove(otUsers);
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
