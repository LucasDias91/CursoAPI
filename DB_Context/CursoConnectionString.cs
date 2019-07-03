using CursoAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CursoAPI.DB_Context
{
    public class CursoConnectionString: DbContext
    {
        public CursoConnectionString() : base("CursoConnectionString") { }

        public virtual DbSet<UsuariosDTO> Usuarios { get; set; }
    }
}