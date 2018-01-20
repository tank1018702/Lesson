using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_14
{
    enum DishesLevelType
    {
        可,
        优,
        神,
        特

    }
    enum DishesAbilityType
    {
        炒,
        烤,
        煮,
        蒸,
        切,
        炸

    }
    class Manager
    {
        public Dictionary<string, Dishes> DishesList;
    }
    class Ability
    {
        int Stir_Fry;  //炒
        int Roast;     //烤
        int Boil;      //煮
        int Steam;     //蒸
        int Cut;       //切
        int Fry;       //炸
    }
    class Dishes  //菜肴
    {
        string Name;
        int Level;
        string AbilityName;
        int Price;

        Dictionary<string, Ingredients> Ingredients_List;   //食材列表
        Dictionary<string, int> Ability_List;               //能力列表


        public Dishes() /*CreateDishes()*/
        {
            Console.WriteLine("输入名字:");
            Name = Console.ReadLine();

            Console.WriteLine("输入等级");
            Level = Program.InputToInt();

            Console.WriteLine("输入价格");
            Price = Program.InputToInt();

            Console.WriteLine("输入需要能力:");
            Ability_List = CreateAbility_List();

            Console.WriteLine("输入需要食材:");
            Ingredients_List = CreateIngredients_List();


        }
        public Dictionary<string, Ingredients> CreateIngredients_List()
        {
            var dict = new Dictionary<string, Ingredients>();



            while (true)
            {

            }
        }
        public Dictionary<string, int> CreateAbility_List()
        {
            var dict = new Dictionary<string, int>();
            Console.WriteLine
            Console.WriteLine("输入能力:");
            dict.Add(Console.ReadLine(), Program.InputToInt());
            while (true)
            {

            }
        }
    }
    class Ingredients
    {
        string Name;

        int price;
        public Ingredients(string name)
        {
            Name = name;
        }

    }

    class Program
    {
        public static int InputToInt()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("输入错误,请输入整数");
            }
            return n;
        }
        static void Main(string[] args)
        {
        }
    }
}
