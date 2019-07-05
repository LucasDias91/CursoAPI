using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CursoAPI.DAO
{
    public class SessaoDAO
    {
        public int SelectIdUsuario()
        {
            var _idusuario = 0;
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            if (claims.Count() > 0)
            {
                _idusuario = Convert.ToInt16(identity.FindFirst("idusuario").Value);
            }
            return _idusuario;
        }
    }
}