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

        
        // Get - Lista todos os usuários. 
        [HttpGet] 
        public HttpResponseMessage getUsuario()
        {
            // Criando menssagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            //Tentando
            try
            {
                // Obtendo todos os usuários.
                List<UsuariosDTO> _usuarios = (new UsuariosDAO().SelectUsuarios());

                // Criando response de sucesso da requisição com a lista de usuários.
                _response = Request.CreateResponse(HttpStatusCode.OK, _usuarios);
            }

            //Pegando erro. 
            catch (Exception ex)
            {
                //Criando response 
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //Retornando mensagem. 
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
