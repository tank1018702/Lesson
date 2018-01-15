using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 事件
namespace EventCarDealer
{
    class CarInfoEventArgs : EventArgs
    {
        public string Car;
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }
    }

    class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine($"New car! {car}");
            //NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
            if (NewCarInfo != null)
            {
                NewCarInfo.Invoke(this, new CarInfoEventArgs(car));
            }
        }
    }


    // -------------------------------------------------------

    class Consumer
    {
        public string name;
        public Consumer(string name)
        {
            this.name = name;
        }
        public void NewCar(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine($"{name} received new car {e.Car}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var dealer = new CarDealer();

            // 订阅事件
            var consumer1 = new Consumer("小明");
            dealer.NewCarInfo += consumer1.NewCar;
            dealer.NewCarInfo += consumer1.NewCar;

            var consumer2 = new Consumer("小红");
            dealer.NewCarInfo += consumer2.NewCar;

            // 发生事件
            dealer.NewCar("Honda Fit");

            Console.ReadKey();


            dealer.NewCarInfo -= consumer1.NewCar;

            dealer.NewCar("Mazda");

            Console.ReadKey();
        }
    }
}
