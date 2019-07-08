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
        [Authorize]
        public HttpResponseMessage getUsuarios()
        {
            // Inicializando menssagem.
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
                //Criando mesagem de erro 
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //Retornando mensagem. 
            return _response;
        }

        // Get - Lista um usuário. 
        [HttpGet]
        [Authorize]
        [Route("api/usuario")]
        public HttpResponseMessage getUsuario()
        {
            // Inicializando mensagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            try
            {
                //Obtendo idUsuario
                int idUsuario = (new SessaoDAO().SelectIdUsuario());

                // Obtendo usuário pelo o id.
                UsuariosDTO _usuario = (new UsuariosDAO().SelectUsuario(idUsuario));

                // Criando response de sucesso com o usuário.
                _response = Request.CreateResponse(HttpStatusCode.OK, _usuario);
            }
            //Pegando erro. 
            catch (Exception ex)
            {
                //Criando mensagem de erro 
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //Retornando mensagem. 
            return _response;
        }

        // Post - Inserindo um novo usuário. 
        [HttpPost]
        public HttpResponseMessage postUsuario([FromBody] UsuariosDTO Usuario)
        {
            // Inicializando mensagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            // Validando modelo de dados
            if (!ModelState.IsValid)
            {
                //Criando error response se o modelo estiver inválido. 
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return _response;
            }

            try
            {
                //Inserindo usuário no banco de dados 
                string msg = (new UsuariosDAO().InsertUsuario(Usuario));

                //Criando mensagem de sucesso!
                _response = Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            //Pegando error 
            catch (Exception ex)
            {
                // Criando mensagem de erro!
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //Retornando mensagem de sucesso!
            return _response;
        }

        // Put - Alterando usuário. 
        [HttpPut]
        [Authorize]
        public HttpResponseMessage putUsuario([FromBody] UsuariosDTO Usuario)
        {
            // Inicializando mensagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            // Validando modelo de dados
            if (!ModelState.IsValid)
            {
                //Criando mensagem de error!
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return _response;
            }

            try
            {
                //Alterando usuário no banco de dados 
                string msg = (new UsuariosDAO().UpdateUsuario(Usuario));
                //Criando mensagem de sucesso!
                _response = Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                //Criando mensagem de error!
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //Retornando mensagem.
            return _response;
        }

        //Delete - Deletando um usuário
        [HttpDelete]
        [Authorize]
        public HttpResponseMessage deleteUsuario([FromUri] int idUsuario)
        {
            // Inicializando mensagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            try
            {
                //Deletando usuário do banco de dados 
                string msg = (new UsuariosDAO().DeleteUsuario(idUsuario));
                //Criando mensagem de sucesso!
                _response = Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            //Pegando erro
            catch (Exception ex)
            {
                //Criando mensagem de erro
                _response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            //Retornando mensagem. 
            return _response;
        }
    }
}
