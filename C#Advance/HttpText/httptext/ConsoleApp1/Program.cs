using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using Serializable_text;
using System.IO;
using System.Web;



namespace HttpText
{
    class Program
    {
        static HttpListener httpListener = null;

        int LinkCount;
        


        static void Main(string[] args)
        {

            httpListener = new HttpListener();

            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

            httpListener.Prefixes.Add("http://+:9000/");
            httpListener.Start();
            Console.WriteLine("服务器启动");
            Thread thread = new Thread(new ThreadStart(Handler));
            thread.Start();
            //Handler();

            


        }
        static void Handler()
        {
            DeliveryTestMessage msg = new DeliveryTestMessage();

            while(true)
            {
                HttpListenerContext context = httpListener.GetContext();

                HttpListenerResponse response = context.Response;

                string s1 = context.Request.Url.ToString();
                string s = context.Request.QueryString["msg"];
                

                msg.message = HttpUtility.UrlDecode(s);
                msg.name = context.Request.RemoteEndPoint.Address.ToString();
                msg.time = DateTime.Now.ToString();
                byte[] buffer = Utils.SerializeToBinary(msg);
                using (Stream output = response.OutputStream)
                {
                    output.Write(buffer, 0, buffer.Length);
                }


                Console.WriteLine(context.Request.QueryString["msg"]);
            }
        }
    }
}
