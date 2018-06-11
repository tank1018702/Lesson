using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Serializable_text
{
    class Utils
    {
        public static byte[] SerializeToBinary(TestMessage msg)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, msg);
            byte[] data = ms.ToArray();
            ms.Close();
            return data;
        }

        public static TestMessage DeserializeWithBinary(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(data, 0, data.Length);
            ms.Position = 0;
            TestMessage msg = (TestMessage)bf.Deserialize(ms);
            ms.Close();
            return msg;
        }

        public static byte[] BinaryDataReader(Stream stream)
        {
            List<byte> buffer = new List<byte>();
            using (BinaryReader reader = new BinaryReader(stream))
            {
                while (true)
                {
                    byte[] temp = reader.ReadBytes(1024);
                    if (temp.Length == 0)
                    {
                        break;
                    }
                    buffer.AddRange(temp);
                }
            }
            return buffer.ToArray();
        }

    }
}
