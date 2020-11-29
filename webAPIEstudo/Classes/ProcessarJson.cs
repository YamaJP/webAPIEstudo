using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPIEstudo.Classes
{
    public static class ProcessarJson
    {

        public static string Retorno(string json)
        {

            try
            {
                string retorno = "";

                Acoes a = JsonConvert.DeserializeObject<Acoes>(json);

                if (a.action.ToLower() == "pessoas")
                {
                    if (String.IsNullOrEmpty(a.chave))
                        retorno = Pessoas.Lista();
                    else
                        retorno = Pessoas.Procurar(a.chave);
                }

                return retorno;

            }
            catch (Exception ex)
            {
                Log.Write(ex.StackTrace, Log.ELogLevel.Error);
                return ex.StackTrace;
            }

        }

    }

    public class Acoes
    {
        public string action { get; set; }
        public string chave { get; set; }
    }
}