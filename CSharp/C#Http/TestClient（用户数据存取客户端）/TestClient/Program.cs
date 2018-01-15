using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    /// <summary>
    /// 连接自建HttpServer存储user&data的演示客户端
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------测试客户端------------");
            while (true)
            {
                Console.WriteLine("请输入要执行的操作：");
                Console.WriteLine("1.存储数据  2.读取数据");
                string cmd = Console.ReadLine();
                if (cmd == "1")
                {
                    Console.WriteLine("请输入要存储的用户名：");
                    string username = Console.ReadLine();
                    Console.WriteLine("请输入要存储的数据内容:");
                    string data = Console.ReadLine();
                    string backmsg = Save(username, data);//存储数据
                    Console.WriteLine(backmsg);//输出存储返回信息
                    Console.WriteLine("-------------------------");
                    
                }
                else if (cmd == "2")
                {
                    Console.WriteLine("请输入要读取信息的所属用户名：");
                    string username = Console.ReadLine();
                    string backmsg = Load(username);//读取数据
                    Console.WriteLine(backmsg);//输出读取返回信息
                    Console.WriteLine("-------------------------");


                }
                else
                {
                    Console.WriteLine("请输入正确的命令！");
                    Console.WriteLine("-------------------------");
                }
                //Console.ReadKey();
            }
          
        }
       
        //向服务器存储数据，返回提示信息
        public static string Save (string user,string data)
        {
            string sendData = "user="+user+"&"+"data="+data;//发送的数据
            string url = "http://127.0.0.1:8080/save/?" + sendData;//请求路径
            string backMsg = "";//接收服务端返回数据
            try
            {
                System.Net.WebRequest httpRquest = System.Net.HttpWebRequest.Create(url);
                httpRquest.Method = "GET";
                // 下面注释的这段，一般用来上传复杂数据或文件用的。很多情况下都可以不要
                /*byte[] dataArray = System.Text.Encoding.UTF8.GetBytes(sendData);               
                System.IO.Stream requestStream = null;
                if (string.IsNullOrWhiteSpace(sendData) == false)
                {
                    requestStream = httpRquest.GetRequestStream();
                    requestStream.Write(dataArray, 0, dataArray.Length);
                    requestStream.Close();
                }*/
                System.Net.WebResponse response = httpRquest.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
                backMsg = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                //requestStream.Dispose();
                responseStream.Close();
                responseStream.Dispose();

            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            return backMsg;
        }


        //从服务器读取数据，返回该user之前存储的data
        public static string Load(string user)
        {
            string sendData = "user="+ user;//发送的数据
            string url = "http://127.0.0.1:8080/load?" + sendData;
            //string url = "http://192.168.199.107:8080/load?" + sendData;
            string backMsg = "";//接收服务端返回数据
            try
            {

                System.Net.WebRequest httpRquest = System.Net.HttpWebRequest.Create(url);
                httpRquest.Method = "GET";
                /*下面这段代码一般用于POST请求，传输文件使用*/
                //byte[] dataArray = System.Text.Encoding.UTF8.GetBytes(sendData);
                //httpRquest.ContentLength = dataArray.Length;  
                //System.IO.Stream requestStream = null;
                //if (string.IsNullOrWhiteSpace(sendData) == false)
                //{
                    //requestStream = httpRquest.GetRequestStream();
                    //requestStream.Write(dataArray, 0, dataArray.Length);
                    //requestStream.Close();
                //}
                
                System.Net.WebResponse response = httpRquest.GetResponse();//获取服务器的返回，存在等待可能
                System.IO.Stream responseStream = response.GetResponseStream();//获取服务器返回的字符流
                System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);//将返回的字符流以UTF8格式赋给StreamReader
                backMsg = reader.ReadToEnd();//将StreamReader全部数据赋给字符串
                //关闭连接与释放资源
                reader.Close();
                reader.Dispose();
                //requestStream.Dispose();
                responseStream.Close();
                responseStream.Dispose();

            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            return backMsg;//返回信息
        }

    }
}
