using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.API.Models
{
    public class TipoNotificacion
    {
        public int Id_tiponotificacion { get; set; }
        public int Id_notificacion { get; set; }
        public int Id_usuario { get; set; }
    }
}
