using CursoAPI.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CursoAPI.DTO
{
    [Table("Usuarios")]
    public class UsuariosDTO
    {
        [Key]
        public int idusuario { get; set; }

        [Required(ErrorMessage = "usuario é obrigatório", AllowEmptyStrings = false)]
        public string usuario { get; set; }

        [Required(ErrorMessage = "senha é obrigatória", AllowEmptyStrings = false)]
        public string senha { get; set; }

        [Required(ErrorMessage = "nome é obrigatório", AllowEmptyStrings = false)]
        public string nome { get; set; }

        public string telefone { get; set; }

        public string email { get; set; }

    }
}