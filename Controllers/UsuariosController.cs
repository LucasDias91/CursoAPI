using CursoAPI.DAO;
using CursoAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CursoAPI.Controllers
{
    public class UsuariosController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage getUsuario()
        {
            HttpResponseMessage _response = new HttpResponseMessage();

            try
            {
                List<UsuariosDTO> _usuarios = (new UsuariosDAO().SelectUsuarios());
                _response = Request.CreateResponse(HttpStatusCode.OK, _usuarios);
            }
            catch (Exception ex)
            {
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return _response;
        }

        [HttpGet]
        public HttpResponseMessage getUsuario([FromUri] int idUsuario)
        {
            HttpResponseMessage _response = new HttpResponseMessage();

            try
            {
                UsuariosDTO _usuario = (new UsuariosDAO().SelectUsuario(idUsuario));
                _response = Request.CreateResponse(HttpStatusCode.OK, _usuario);
            }
            catch(Exception ex)
            {
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return _response;
        }

        [HttpPost]
        public HttpResponseMessage postUsuario([FromBody] UsuariosDTO Usuario)
        {
            HttpResponseMessage _response = new HttpResponseMessage();
            if (!ModelState.IsValid)
            {
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return _response;
            }

            try
            {
                string msg = (new UsuariosDAO().InsertUsuario(Usuario));
                _response = Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return _response;
        }

        [HttpPut]
        public HttpResponseMessage putUsuario([FromBody] UsuariosDTO Usuario)
        {
            HttpResponseMessage _response = new HttpResponseMessage();

            if (!ModelState.IsValid)
            {
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return _response;
            }

            try
            {
                string msg = (new UsuariosDAO().UpdateUsuario(Usuario));
                _response = Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return _response;
        }

        [HttpDelete]
        public HttpResponseMessage deleteUsuario([FromUri] int idUsuario)
        {
            HttpResponseMessage _response = new HttpResponseMessage();

            try
            {
                string msg = (new UsuariosDAO().DeleteUsuario(idUsuario));
                _response = Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return _response;
        }
    }
}
