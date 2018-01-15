using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 演示基本的异常处理的方法
namespace ExceptionTest
{
    class Program
    {
        static int Input()
        {
            return int.Parse(Console.ReadLine());
        }

        static float Divide(int a, int b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            try
            {
                int a = Input();
                int b = Input();
                
                float c = Divide(a, b);
                Console.WriteLine("成功，结果："+ c);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("=====" + e.Message);
            }
            finally
            {
                Console.WriteLine("无论是否有异常，总是会执行finally代码块，以防止文件没有关闭等重要问题。");
            }
            Console.ReadKey();
        }
    }
}
