using CursoAPI.DB_Context;
using CursoAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CursoAPI.DAO
{
    public class ProdutosDAO
    {


        //Inicializando o banco de dados 
        CursoConnectionString dbCurso = new CursoConnectionString();

        //Query para retornar todos od produtos.
        public List<ProdutosDTO> SelectProdutos(int idUsuario)
        {
            //Selecinando todos os protudos e colocando em uma lista.
            List<ProdutosDTO> _produtos = dbCurso.Database.SqlQuery<ProdutosDTO>("exec spu_SelectProdutos @idusuario",
                new SqlParameter("@idusuario", idUsuario))
                .ToList();
            //Retornando lista de produtos.
            return _produtos;

        }

        //Query para retornar um produto
        public ProdutosDTO SelectProduto(int idusuario, int idproduto)
        {
            //Selecinando todos o produto e colocando em um array.
            ProdutosDTO _produto = dbCurso.Database.SqlQuery<ProdutosDTO>("exec spu_SelectProduto @idusuario, @idproduto",
                new SqlParameter("@idusuario", idusuario),
                new SqlParameter("@idproduto", idproduto))
                .FirstOrDefault();
            //Retornando produto.
            return _produto;
        }

        //Query para inserir um novo usuário
        public string InsertProduto(int idusuario, string produto,string descricao, int quantidade)
        {
            dbCurso.Database.SqlQuery<string>("exec spu_InsertProduto @idusuario, @produto ,@descricao, @quantidade",
                new SqlParameter("@idusuario", idusuario),
                new SqlParameter("@produto", produto),
                new SqlParameter("@descricao", descricao),
                new SqlParameter("@quantidade", quantidade))
                .FirstOrDefault();
            return "Inserido com sucesso!";
        }

        //Query para alterar um produto existente
        public string UpdateProduto(int idusuario, int idproduto, string produto,string descricao, int quantidade)
        {
            string _msg = dbCurso.Database.SqlQuery<string>("exec spu_UpdateProduto @idusuario, @idproduto, @produto , @descricao, @quantidade",
                          new SqlParameter("@idusuario", idusuario),
                          new SqlParameter("@idproduto", idproduto),
                           new SqlParameter("@produto", produto),
                            new SqlParameter("@descricao", descricao),
                             new SqlParameter("@quantidade", quantidade))
                         .FirstOrDefault();
            return _msg;
        }

        //Query para excluir um produto existente do banco de dados
        public string DeleteProduto(int idusuario, int idproduto)
        {
            string _msg = dbCurso.Database.SqlQuery<string>("exec spu_DeleteProduto @idusuario, @idproduto",
                                  new SqlParameter("@idusuario", idusuario),
                                     new SqlParameter("@idproduto", idproduto))
                                 .FirstOrDefault();
            return _msg;
        }
    }
}