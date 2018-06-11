using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serializable_text
{
    public class Utils
    {
        public static byte[] BinaryDataReader(Stream stream)
        {
            List<byte> buffer = new List<byte>();
            using (BinaryReader reader = new BinaryReader(stream))
            {
                while (true)
                {
                    byte[] temp = reader.ReadBytes(1024);
                    if (temp.Length == 0)//如果读不到数据时，说明流中数据读完了
                    {
                        break;
                    }
                    buffer.AddRange(temp);
                }
            }
            return buffer.ToArray();
        }
        public static byte[] SerializeToBinary(object msg)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, msg);
            byte[] data = ms.ToArray();
            ms.Close();
            return data;
        }
        public static T DeserializeWithBinary<T>(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(data, 0, data.Length);
            ms.Position = 0;
            T msg = (T)bf.Deserialize(ms);
            ms.Close();
            return msg;
        }
    }
}
