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
        public Manager()
        {
            DishesList = new Dictionary<string, Dishes>();
        }
        public static void PrintALLDishes(Dictionary<string, Dishes> dict)
        {
            foreach(var pair in dict)
            {
                Console.Write(pair.Key+" ");
                foreach( var ability in  pair.Value.Ability_List)
                {
                    Console.Write("{0}:{1}", ability.Key, ability.Value);
                }
                Console.WriteLine();
                foreach(var ingrendient in pair.Value.Ingredients_List)
                {
                    Console.Write("<{0}:{1}>", ingrendient.Key, ingrendient.Value.Number+" ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------");
            }
        }
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
       public string Name;
        int Level;
        string AbilityName;
        int Price;

      public  Dictionary<string, Ingredients> Ingredients_List;   //食材列表
     public   Dictionary<string, int> Ability_List;               //能力列表


        public Dishes() /*CreateDishes()*/
        {
            Console.WriteLine("输入名字:");
            Name = Console.ReadLine();

            Console.WriteLine("输入等级");
            Level = Program.InputToInt();

            Console.WriteLine("输入价格");
            Price = Program.InputToInt();


            Ability_List = CreateAbility_List();


            Ingredients_List = CreateIngredients_List();


        }
        public Dictionary<string, Ingredients> CreateIngredients_List()
        {
            var dict = new Dictionary<string, Ingredients>();
            int n;

            do
            {
                var ingredients = new Ingredients();
                Console.WriteLine("输入需求食材:");
                ingredients.Name = Console.ReadLine();
                Console.WriteLine("输入需求个数:");
                ingredients.Number = Program.InputToInt();
                dict.Add(ingredients.Name, ingredients);
                Console.WriteLine("1.继续输入 2.完毕退出");
                n = Program.InputToInt();


            } while (n==1);
            return dict;
        }
        public Dictionary<string, int> CreateAbility_List()
        {
            var dict = new Dictionary<string, int>();

            Console.WriteLine("输入需求能力1:");
            string ability1 = Console.ReadLine();
            Console.WriteLine("输入能力1的值:");
            int abi_var1 = Program.InputToInt();
            Console.WriteLine("输入需求的能力2:");
            string ability2 = Console.ReadLine();
            Console.WriteLine("输入能力2的值:");
            int abi_var2 = Program.InputToInt();
            dict.Add(ability1, abi_var1);
            dict.Add(ability2, abi_var2);
            return dict;
        }
    }
    class Ingredients
    {
        public string Name;
        public int Number;
        public double price=0.00;


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
            var dish = new Dishes();
            var manager = new Manager();
            manager.DishesList.Add(dish.Name, dish);
            Manager.PrintALLDishes(manager.DishesList);
            Console.ReadKey();
        }
    }
}
