using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SchoolCommunity.Models;
using SchoolCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCommunity.Services
{
    public class UserService
    {
        public const string REDIRECT_LOGIN = "/Portal";

        /// <summary>
        /// Metodo responsável por devolver uma string com a rota para tela de login
        /// utilizado para exibir a tela de login antes do index
        /// </summary>
        /// <returns> string </returns>
        public string GetRedirectLogin()
        {
            return REDIRECT_LOGIN;
        }

        public bool Autenticar(UsuarioVM dadosUsuario)
        {
            dadosUsuario.SenhaUsuario = CalculateMD5Hash(dadosUsuario.SenhaUsuario); // -> Criptrografia da Senha
            return dadosUsuario.ObterUsuario(dadosUsuario);
        }

        public void AtualizaDadosSessao(UsuarioVM dados, ISession sessao)
        {
            sessao.SetString(ChaveSessao(), JsonConvert.SerializeObject(dados));
        }

        public UsuarioLogin ObtemDadosSessao(ISession sessao)
        {
            var valor = sessao.GetString(ChaveSessao());

            return valor == null ? default(UsuarioLogin) : JsonConvert.DeserializeObject<UsuarioLogin>(valor);
        }

        public string ChaveSessaoTeste = "dados";

        //public bool ValidaSessaoUsuario(ISession sessao)
        //{
        //    UsuarioVM dados = this.GetDadosSessao<UsuarioVM>(ChaveSessaoTeste, sessao);

        //    if (dados != null && dados.SenhaUsuario != null)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public T GetDadosSessao<T>(string key, ISession sessao)
        //{
        //    var value = sessao.GetString(key);

        //    return value == null ? default(T) :
        //        JsonConvert.DeserializeObject<T>(value);
        //}

        public bool ValidaSessaoUsuario(ISession sessao)
        {
            var dados = ObtemDadosSessao(sessao);

            if (dados != null && dados.SenhaUsuario != null)
            {
                return true;
            }

            return false;
        }

        public string ChaveSessao()
        {
            return "PlataformaSchoolCommunity";
        }
        
        public string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        
    }
}
