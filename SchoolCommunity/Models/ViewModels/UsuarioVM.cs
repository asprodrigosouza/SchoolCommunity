using MongoDB.Bson;
using MongoDB.Driver;
using SchoolCommunity.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class UsuarioVM
    {
        
        public ObjectId _id { get; set; }
        public string NomeUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string PerfilUsuario { get; set; }
        public bool StatusUsuario { get; set; }



        public bool ObterUsuario(UsuarioVM usuario)
        {
           
            Console.WriteLine("Obtendo Coleção('Tabela') de Usuarios...");
            IMongoCollection<UsuarioVM> usuarios = MongoDBDataBase.GetConnect.GetCollection<UsuarioVM>("UsuariosLogin");

            var result = usuarios.Find(x => x.LoginUsuario == usuario.LoginUsuario && x.SenhaUsuario == usuario.SenhaUsuario);

            // Validação: Usuário + Senha Existe:
            if (result.CountDocuments() > 0)
            {
            
                var usr = result.FirstOrDefault();

                _id = usr._id;
                NomeUsuario = usr.NomeUsuario;
                PerfilUsuario = usr.PerfilUsuario;
                StatusUsuario = usr.StatusUsuario;

                //PopulaUsuario(usr);

                return true;
            }
            else
                return false;
        }

        public void PopulaUsuario(UsuarioVM usr)
        {
            UsuarioLogin usuario = new UsuarioLogin();

            usuario._id = usr._id.ToString();
            usuario.NomeUsuario = usr.NomeUsuario;
            usuario.LoginUsuario = usr.LoginUsuario;
            usuario.SenhaUsuario = usr.SenhaUsuario;
            usuario.PerfilUsuario = usr.PerfilUsuario;
            usuario.StatusUsuario = usr.StatusUsuario;
        }


    }
}
