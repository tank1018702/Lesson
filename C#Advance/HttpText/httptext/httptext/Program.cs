using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Serializable_text;
using System.IO;



namespace HttpText
{


    class Program
    {
        const string url_root = "http://192.168.2.59:9000/?msg=" + "";

        static void Main(string[] args)
        {
            string url = url_root;

            Console.WriteLine("输入一个名字");


            DeliveryTestMessage msg = new DeliveryTestMessage();


            while (true)
            {



                //message.message= Console.ReadLine();
                //message.time = DateTime.Now.ToString();


                string s= System.Web.HttpUtility.UrlEncode(Console.ReadLine(),Encoding.GetEncoding(936));
                url = url_root + s;

                msg = Handler(url);
                Console.WriteLine(msg.time);
                Console.WriteLine(msg.name + ":" + msg.message);





            }
        }


        static DeliveryTestMessage Handler(string url)
        {
            DeliveryTestMessage data = null;
            try
            {
                #region 请求部分
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //此处要设定请求的方法的原因在于
                //Create方法得到的只是web的请求，而不一定是http协议的请求，
                //因此需要将http协议中对应的方法进行指定
                request.Method = "GET";
                #endregion
                #region 响应部分
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream input = response.GetResponseStream())
                {
                    byte[] binaryData = Utils.BinaryDataReader(input);
                    data = Utils.DeserializeWithBinary<DeliveryTestMessage>(binaryData);
                }
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

            return data;
        }
    }
}
