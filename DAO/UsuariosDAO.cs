using CursoAPI.DB_Context;
using CursoAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CursoAPI.DAO
{
    public class UsuariosDAO
    {
        //Inicializando o banco de dados 
        CursoConnectionString dbCurso = new CursoConnectionString();

        //Query para retornar todos usuários.
        public List<UsuariosDTO> SelectUsuarios()
        {
            //Selecinando todos os usuários e colocando em uma lista.
            List<UsuariosDTO> _usuarios = dbCurso.Usuarios
                                                 .ToList();
            //Retornando lista de usuários.
            return _usuarios;
        }

        //Query para retornar um usuário
        public UsuariosDTO SelectUsuario(int idusuario)
        {
            //Selecinando o usuário e colocando em um array.
            UsuariosDTO _usuario = dbCurso.Usuarios
                                           .Where((x => x.idusuario == idusuario))
                                           .FirstOrDefault();

            //Retornando array de usuário.
            return _usuario;
        }

        //Query para inserir um novo usuário
        public string InsertUsuario(UsuariosDTO Usuario)
        {
            //Inserindo um novo usuário.
            dbCurso.Usuarios.Add(Usuario);

            //Efetivando no banco de dados.
            dbCurso.SaveChanges();

            //Retornando menssagem.
            return "Usuário salvo com sucesso!";
        }

        //Query para alterar um usuário existente
        public string UpdateUsuario(UsuariosDTO Usuario)
        {
            // Fazendo o update.
            dbCurso.Entry(Usuario).State = EntityState.Modified;

            // Efetivando no banco de dados.
            dbCurso.SaveChanges();

            //Retornando uma mensagem..
            return "Usuário alterado com sucesso!";
        }

        //Query para excluir um usuário existente do banco de dados
        public string DeleteUsuario(int idusuario)
        {
            var _usuarioToRemove = SelectUsuario(idusuario);

            // Fazendo o exclusão...
            dbCurso.Entry(_usuarioToRemove).State= EntityState.Deleted;

            // Efetivando no banco de dados...
            dbCurso.SaveChanges();

            //Retornando uma mensagem... 
            return "Usuário deletado com sucesso!";
        }

        //Query para retornar todos usuários.
        public UsuariosDTO SelectUsuarioPorCredenciais(string usuario, string senha)
        {
            //Selecinando o usuário e colocando em um array.
            UsuariosDTO _usuario = dbCurso.Usuarios
                                           .Where((x => x.usuario == usuario && x.senha == senha))
                                           .FirstOrDefault();

            //Retornando array de usuário.
            return _usuario;
        }

    }
}