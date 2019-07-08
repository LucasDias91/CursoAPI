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
    public class ProdutosController : ApiController
    {

        // Get - Lista todos os produtos. 
        [HttpGet]
        [Authorize]
        public HttpResponseMessage getProdutos()
        {
            // Inicializando menssagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            //Tentando
            try
            {
                //Obtendo idUsuario
                int idusuario = (new SessaoDAO().SelectIdUsuario());

                // Obtendo todos os produtos.
                List<ProdutosDTO> _produtos = (new ProdutosDAO().SelectProdutos(idusuario));

                // Criando response de sucesso da requisição com a lista de produtos.
                _response = Request.CreateResponse(HttpStatusCode.OK, _produtos);
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
        public HttpResponseMessage getProduto([FromUri] int idProduto)
        {
            // Inicializando mensagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            try
            {
                //Obtendo idUsuario
                int idUsuario = (new SessaoDAO().SelectIdUsuario());

                // Obtendo produto pelo o id.
                ProdutosDTO _produto = (new ProdutosDAO().SelectProduto(idUsuario, idProduto));

                // Criando response de sucesso com o produto.
                _response = Request.CreateResponse(HttpStatusCode.OK, _produto);
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

        // Post - Inserindo um novo produto. 
        [HttpPost]
        [Authorize]
        public HttpResponseMessage postProduto([FromBody] ProdutosDTO Produto)
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
                //Obtendo idUsuario
                int idUsuario = (new SessaoDAO().SelectIdUsuario());

                //Inserindo produto no banco de dados 
                string msg = (new ProdutosDAO().InsertProduto(idUsuario, Produto.produto, Produto.descricao, Produto.quantidade));

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
        public HttpResponseMessage putProduto([FromBody] ProdutosDTO Produto)
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
                //Obtendo idUsuario
                int idUsuario = (new SessaoDAO().SelectIdUsuario());

                //Alterando usuário no banco de dados 
                string msg = (new ProdutosDAO().UpdateProduto(idUsuario, Produto.idproduto, Produto.produto, Produto.descricao, Produto.quantidade));
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

        //Delete - Deletando um produto
        [HttpDelete]
        [Authorize]
        public HttpResponseMessage deleteProduto([FromUri] int idProduto)
        {
            // Inicializando mensagem.
            HttpResponseMessage _response = new HttpResponseMessage();

            try
            {

                //Obtendo idUsuario
                int idUsuario = (new SessaoDAO().SelectIdUsuario());

                //Deletando usuário do banco de dados 
                string msg = (new ProdutosDAO().DeleteProduto(idUsuario, idProduto));
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


