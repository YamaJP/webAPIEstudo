using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.IO;
using webAPIEstudo.Classes;

namespace webAPIEstudo.Controllers
{
    public class EventsController : Controller
    {

        [HttpGet]
        public async Task<string> Processar()
        {            

            string json = "";

            try
            {                

                DateTime tempoInicio = DateTime.Now;

                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                json = new StreamReader(req).ReadToEnd();

                string retorno = "";

                //int x = Convert.ToInt32("a");

                if (String.IsNullOrEmpty(json))
                {
                    Versao ver = new Versao();
                    ver.versao = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    retorno = JsonConvert.SerializeObject(ver);
                }
                else
                    retorno = ProcessarJson.Retorno(json);

                return retorno;

            }
            catch (Exception ex)
            {
                ErrorLog erro = new ErrorLog();
                erro.processo = "Processar";
                erro.message = ex.Message;
                erro.stackTrace = ex.StackTrace;

                Log.Write(JsonConvert.SerializeObject(erro), Log.ELogLevel.Error);

                return JsonConvert.SerializeObject(erro);
            }

        }

    }


}