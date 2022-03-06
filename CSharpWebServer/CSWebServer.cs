using System.Net;
using System.Text;

namespace CSharpWebServer
{
    public class CSWebServer
    {
        public string DocumentRoot { get; set; }
        public string index = "index.html";
        public string Address { get; set; }

        private HttpListener Server;

        public CSWebServer()
        {
            Server = new HttpListener();
        }

        public void Start()
        {
            if (string.IsNullOrEmpty(Address))
            {
                throw new Exception("Address cannot be empty.");
            }

            if (string.IsNullOrEmpty(DocumentRoot))
            {
                throw new Exception("DocumentRoot cannot be empty.");
            }

            if (!Directory.Exists(DocumentRoot))
            {
                Directory.CreateDirectory(DocumentRoot);
            }

            Server.Prefixes.Add(Address.Trim('/') + "/");

            Server.Start();
            Console.WriteLine("Server is starting: " + Address);
            while (Server.IsListening)
            {
                HttpListenerContext context = (HttpListenerContext)Server.GetContext();
                HttpListenerResponse response = context.Response;
                HttpListenerRequest request = context.Request;

                string content = "Welcome!";
                response.ContentLength64 = content.Length;
                byte[] buffer = Encoding.ASCII.GetBytes(content);
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}