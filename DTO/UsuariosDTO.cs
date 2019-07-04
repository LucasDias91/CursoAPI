using CursoAPI.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CursoAPI.DTO
{
    //Nome da tabela do banco de dados 
    [Table("Usuarios")]
    public class UsuariosDTO
    {
        [Key]
        public int idusuario { get; set; }

        //Campo usuario é obrigário  
        [Required
            (ErrorMessage = "usuario é obrigatório", AllowEmptyStrings = false)]
        public string usuario { get; set; }

        //Campo senha é obrigária
        [Required
            (ErrorMessage = "senha é obrigatória", AllowEmptyStrings = false)]
        public string senha { get; set; }

        //Campo nome é obrigária
        [Required
            (ErrorMessage = "nome é obrigatório", AllowEmptyStrings = false)]
        public string nome { get; set; }

        //Verificando se é uma telefone válido.
        [RegularExpression
            (@"^1\d\d(\d\d)?$|^0800 ?\d{3} ?\d{4}$|^(\(0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d\) ?|0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d[ .-]?)?(9|9[ .-])?[2-9]\d{3}[ .-]?\d{4}$",
              ErrorMessage = "Telefone em formato inválido.")]
        public string telefone { get; set; }

        //Verificando se é um email válido.
        [RegularExpression
            (@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", 
            ErrorMessage = "E-mail em formato inválido.")]
        public string email { get; set; }

    }
}