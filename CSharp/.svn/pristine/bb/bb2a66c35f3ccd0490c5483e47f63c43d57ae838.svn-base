using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public class MyException : Exception
    {
        public int par;
        public MyException(int n)
        : base("MyException")
        {
            par = n;
        }
    }

    class MyClass
    {
        public int n;
        public void Set(int _n)
        {
            if (_n<0)
            {
                throw new MyException(_n);
            }
            n = _n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass();
            c.Set(100);

            try
            {
                c.Set(-100);
            }
            catch (MyException e)
            {
                Console.WriteLine("Set失败 " + e.par);
            }
            finally
            {

            }

            Console.ReadLine();
        }
    }
}
