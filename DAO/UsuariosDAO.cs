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
        //Inicializando a instância do banco de dados
        CursoConnectionString dbCurso = new CursoConnectionString();

        //Retorna todas os usuários.
        public List<UsuariosDTO> SelectUsuarios()
        {
            List<UsuariosDTO> _usuarios = dbCurso.Usuarios
                                                 .ToList();

            return _usuarios;
        }

        //Retorna um usuário.
        public UsuariosDTO SelectUsuario(int idusuario)
        {
            UsuariosDTO _usuario = dbCurso.Usuarios
                                           .Where((x => x.idusuario == idusuario))
                                           .FirstOrDefault();

            return _usuario;
        }

        //Insere um novo usuário.
        public string InsertUsuario(UsuariosDTO Usuario)
        {
            dbCurso.Usuarios.Add(Usuario);
            dbCurso.SaveChanges();

            return "Usuário salvo com sucesso!";
        }

        //Altera um usuário existente.
        public string UpdateUsuario(UsuariosDTO Usuario)
        {
            dbCurso.Entry(Usuario).State = EntityState.Modified;
            dbCurso.SaveChanges();

            return "Usuário alterado com sucesso!";
        }

        //Delete um usuário existente.
        public string DeleteUsuario(int idusuario)
        {
            var _usuarioToRemove = SelectUsuario(idusuario);

            dbCurso.Entry(_usuarioToRemove).State= EntityState.Deleted;
            dbCurso.SaveChanges();
            return "Usuário deletado com sucesso!";
        }

    }
}