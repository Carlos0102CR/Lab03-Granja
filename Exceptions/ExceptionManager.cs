using Entities_POJO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ExceptionManager
    {
    
        public string PATH = @"C:\_temp\logs\";

        private static ExceptionManager instance;

        private static string Component { get; set; }

        private static Dictionary<int, AppMessage> messages = new Dictionary<int, AppMessage>();

        private ExceptionManager(string component)
        {
            Component = component;
            LoadMessages();
        }

        public static ExceptionManager GetInstance(string component)
        {
            if (instance == null)
                instance = new ExceptionManager(component);

            return instance;
        }

        public void Process(Exception ex)
        {

            var bex = new BussinessException();

            if (ex.GetType() == typeof(BussinessException))
            {
                bex = (BussinessException)ex;
            }
            else
            {
                bex = new BussinessException(000, ex);
            }

            ProcessBussinesException(bex);

        }

        private void ProcessBussinesException(BussinessException bex)
        {
            var today = DateTime.Now;
            var logName = PATH + today + "_" + Component + "_" + "log.txt";

            var message = bex.Message + "\n" + bex.StackTrace + "\n" + bex.InnerException.Message + "\n" + bex.InnerException.StackTrace;

            using (StreamWriter w = File.AppendText(logName))
            {
                Log(bex.Message, w);
            }
    
        }

        public AppMessage GetMessage(BussinessException bex)
        {

            var appMessage = new AppMessage();
            appMessage.Message = "Message not found!";

            if (messages.ContainsKey(bex.ExceptionId))
                appMessage = messages[bex.ExceptionId];

            return appMessage;

        }

        private void LoadMessages()
        {
            var appMessage = new AppMessage();
            appMessage.Id = 1;
            appMessage.Message = "Houston we have a problem to connect with the database";
        
            //TODO: RetriveAll de los mensajes de la base 
            // de datos y un ciclo para guardarlos en el dic
            //Como? Por medio del crud correspondiente.

            messages.Add(appMessage.Id, appMessage);

        }

        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

    }
}
