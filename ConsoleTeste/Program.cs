using MCBSchedule.Provider;
using SchoolCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            //ForumVM teste = new ForumVM();

            //foreach (var pergunta in teste._listaPerguntasRecentes)
            //{
            //Console.WriteLine(pergunta.Pergunta.TituloPergunta);
            //}
            
            SendNotification();

            Console.WriteLine("TESTE SUBINDO NOVA ATUALIZAÇÃO | REPOSITÓRIO GITHUB");

            Console.ReadKey();
        }
        
        public static void SendNotification()
        {
            try
            {
                if (true) //IsDirectoryNotEmpty(Path)
                {
                    MailProvider mail = new MailProvider();

                    string AssuntoEmail = "Envio de E-mail School Community"; // Popula Assunto do E-mail => _info.Context.Get().Assunto;
                    string ToEmail = "gabriel.ferreira.sousa123@gmail.com";

                    // Capturar todos os destinatários var lDestino = _info.Context.Get().Destinatario.Split(';');
                    List<string> listaDestino = new List<string>();

                    listaDestino.Add("gabriel.ferreira.sousa123@gmail.com");
                    listaDestino.Add("joseivis2017@gmail.com");
                    listaDestino.Add("tenrodrigo@yahoo.com.br");

                    //foreach (string s in lDestino)
                    //{
                        //if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
                        //{
                            //listaDestino.Add(s);
                        //}
                    //}
                    
                    //  List<string> listaDestino = _info.Context.Get().Destinatario.Split(';').ToList();
                    
                    //======================================================

                    List<string> listDestinoCC = new List<string>();

                    //if (_info.Context.Get().Destinatario_CC != null)
                    //{
                        //var lDestinoCC = _info.Context.Get().Destinatario_CC.Split(';');

                        //foreach (string s in lDestinoCC)
                        //{
                            //if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
                            //{
                                //listDestinoCC.Add(s);
                            //}
                        //}
                    //}


                    //======================================================


                    List<string> listDestinoBCC = new List<string>();

                    //if (_info.Context.Get().Destinatario_CO != null)
                    //{
                        //var lDestinoBCC = _info.Context.Get().Destinatario_CO.Split(';');

                        //foreach (string s in lDestinoBCC)
                        //{
                            //if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
                            //{
                                //listDestinoBCC.Add(s);
                            //}
                        //}
                    //}

                    var body = "Esté é um e-mail Automatico de Teste, Enviado da Plataforma de Gerenciamento Escolar School Community"; //CarregaAssinatura();
                    mail.SendEmail(ToEmail, "projetointegrador18@gmail.com", AssuntoEmail, "Esté é um e-mail Automatico de Teste, Enviado da Plataforma de Gerenciamento Escolar School Community", "");
                    //mail.SendEmail(listaDestino, "projetointegradorads18@gmail.com"/*_info.Context.Get().Remetente*/, listDestinoBCC, listDestinoCC, AssuntoEmail, body, ""/*Path*/);
                    //log.Info("Notificação Enviada: " + _info.Context.Get().NM_Processo);
                }
                else
                {
                    //log.Info("Confirmação sem relatórios: " + _info.Context.Get().NM_Processo);
                }

            }
            catch (System.Exception ex)
            {
                //log.Error(ex.ToString() + "============" + _info.Context.Get().NM_Processo);

            }
        }
    }
}
