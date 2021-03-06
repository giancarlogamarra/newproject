﻿using DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Usuario
{
    public interface IUsuarioCommandsHandler
    {
        Task<UsuarioItem> VALIDAR_ACCESO(string usuario,string password);
        Task<IEnumerable<UsuarioItem>> GET(string search);
        int UPDATE(UsuarioItem product);
        int ADD(UsuarioItem product);
        int DELETE(Guid ID);
    }
}
