using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoAPI.DTO
{
    public class ProdutosDTO
    {
        public int idProduto { get; set; }


        public int idUsuario { get; set; }

        [Required
        (ErrorMessage = "Produto é obrigatório", AllowEmptyStrings = false)]
        public string Produto { get; set; }

        [Required
        (ErrorMessage = "Descricao é obrigatório", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Required
         (ErrorMessage = "Quantidade é obrigatório", AllowEmptyStrings = false)]
        public int Quantidade { get; set; }
    }
}