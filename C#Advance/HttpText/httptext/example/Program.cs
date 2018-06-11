using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
namespace ConsoleApplication1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost/");
            //添加需要监听的url范围            
            listener.Start();
            //开始监听端口，接收客户端请求            
            Console.WriteLine("Listening...");
            //阻塞主函数至接收到一个客户端请求为止            
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string responseString = string.Format("<HTML><BODY> {0}</BODY></HTML>", DateTime.Now);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            //对客户端输出相应信息.             
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            //关闭输出流，释放相应资源            
            output.Close();
            listener.Stop();
            //关闭HttpListener         

            
        }
    }
}