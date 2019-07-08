using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoAPI.DTO
{
    public class ProdutosDTO
    {
        public int idproduto { get; set; }


        public int idusuario { get; set; }

        [Required
        (ErrorMessage = "Produto é obrigatório", AllowEmptyStrings = false)]
        public string produto { get; set; }

        [Required
        (ErrorMessage = "Descricao é obrigatório", AllowEmptyStrings = false)]
        public string descricao { get; set; }

        [Required
         (ErrorMessage = "Quantidade é obrigatório", AllowEmptyStrings = false)]
        public int quantidade { get; set; }
    }
}