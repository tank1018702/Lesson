using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_9
{
    enum DiscountType
    {
        普通 = 1,
        双11 = 2,
        黑五 = 3
    }


    class Book
    {
        public float TotalPrice;

        public List<Order> books = new List<Order>();

       
        public void AddToBook(Order order)
        {
            books.Add(order);
        }
        public void GetBook_Info(List<Order> books)
        {
            foreach (Order order in books)

            {
                Console.WriteLine("名称:{0} 价格:{1} 数量:{2} 类型:{3} 总价:{4}", order.Name, order.Price, order.Number, order.Type, order.GetTotalPrice_Order());
                Console.WriteLine("-------------------------------------------------------");
            }
        }
        public float GetTotalPrice_Book(List<Order> books)
        {

            foreach (Order order in books)
            {
                TotalPrice += order.GetTotalPrice_Order();
            }
            return TotalPrice;
        }


    }
    class Order
    {
        public string Name;
        public float Price;
        public int Number;
        public float TotalPrice;
        public DiscountType Type;
        public Order(string name, float price, int number, DiscountType type)
        {
            Name = name;
            Price = price;
            Number = number;
            Type = type;
        }


        virtual public float GetTotalPrice_Order()
        {

            TotalPrice = Price * Number;
            return TotalPrice;
        }
    }
    class Order11_11 : Order
    {
        public float Discount;
        public Order11_11(string name, float price, int number, DiscountType type, float discount) : base(name, price, number, type)
        {
            Discount = discount;
        }
        override public float GetTotalPrice_Order()
        {

            TotalPrice = Price * Number * Discount;
            return TotalPrice;
        }
    }
    class Order_BlackWeek5 : Order
    {
        public int FullPrice;
        public Order_BlackWeek5(string name, float price, int number, DiscountType type, int fullprice) : base(name, price, number, type)
        {
            FullPrice = fullprice;
        }
        public override float GetTotalPrice_Order()
        {

            if (Price * Number >= FullPrice)
            {
                TotalPrice = (Price * (Number - 1));
            }
            else
            {
                TotalPrice = Price * Number;
            }
            return TotalPrice;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order11_11 order1 = new Order11_11("番茄", 4.0f, 2, DiscountType.双11, 0.8f);
            Order order2 = new Order("西蓝花", 2.0f, 1, DiscountType.普通);
            Order order3 = new Order("大白菜", 1.5f, 4, DiscountType.普通);
            Order_BlackWeek5 order4 = new Order_BlackWeek5("葱", 1.1f, 6, DiscountType.黑五, 6);
            Book book1 = new Book();
            book1.AddToBook(order1);
            book1.AddToBook(order2);
            book1.AddToBook(order3);
            book1.AddToBook(order4);
            book1.GetBook_Info(book1.books);
            Console.WriteLine("全部总价:{0}", book1.GetTotalPrice_Book(book1.books));
            Console.ReadKey();

        }
    }
}
