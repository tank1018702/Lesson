using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {

    class Dealer {
        public delegate void Func(string a);

        public Func events;

        public void NewCar(string name) {
            events(name);
        }
    }

    class Comsumer {
        public string name;
        public void OnNewCar(string car) {
            Console.WriteLine(name + "接收到"+car);
        }
    }
    class Program {
        static void Main(string[] args) {

            Dealer d = new Dealer();
            Comsumer c1 = new Comsumer();
            c1.name = "小明";
            d.events += c1.OnNewCar;

            Comsumer c2 = new Comsumer();
            c2.name = "小红";
            d.events += c2.OnNewCar;

            d.NewCar("马自达");

            Console.ReadKey();
        }
    }
}
