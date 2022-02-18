using SchoolCommunity.Models;
using SchoolCommunity.Models.ViewModels;
using SchoolCommunity.MongoDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Helpers
{
    public class ValidaAcessoUsuario
    {
        public bool UsuarioAtivo(UsuarioVM usuario)
        {
            if (usuario.StatusUsuario)
                return true;
            else
                return false;
        }

        public bool UsuarioBloqueado(UsuarioLogin usuario)
        {
            return false;
        }

        public bool UsuarioPrimeiroAcesso(UsuarioVM usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            var primeiroAcesso = usuarioDAO.FiltrarUsuarioPorId(usuario._id);

            return primeiroAcesso;
        }


    }
}
