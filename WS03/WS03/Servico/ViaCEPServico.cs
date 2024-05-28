using System;
using System.Collections.Generic;
using System.Text;

using WS03.Servico.Modelo; //adicionei
using Newtonsoft.Json; //adicionei
using System.Net;

namespace WS03.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/"; // esse cara so usa nessa classe

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL); //vai baixar aquele array
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if (end.cep == null) return null;
            return end;
        }
    }
}
