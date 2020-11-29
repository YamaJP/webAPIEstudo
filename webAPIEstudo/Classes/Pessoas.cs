using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace webAPIEstudo.Classes
{
    public class Pessoas
    {

        public static string Lista()
        {
            List<Pessoa> p = new List<Pessoa>();
            p.Add(new Pessoa() { chave = "9", nome = "Luciana", endereco = "Av Jurema, 120", telefone = "5511981818282" });
            p.Add(new Pessoa() { chave = "13", nome = "Kalyne", endereco = "Av Paulista, 900", telefone = "5511984848787" });
            p.Add(new Pessoa() { chave = "30", nome = "Jasmyne", endereco = "Rua Pelotas, 99", telefone = "" });

            return JsonConvert.SerializeObject(p);
        }

        public static string Procurar(string chave)
        {
            var p = JsonConvert.DeserializeObject<List<Pessoa>>(Lista()).FirstOrDefault(c => c.chave == chave);
            return JsonConvert.SerializeObject(p);
        }

    }

    public class Pessoa
    {
        public string chave { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }

    }
}