using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_12
{
    class Tool
    {
        public static Random random = new Random();
    }
    class Pokemon
    {
        public int ID;
        public int Serial;
        public string Name;
        public int Level;
        public int ATK;
        public int HP;
        public double GrowthValue;
        public Pokemon(string name, int ID, int growthvalue)
        {
            Name = name;
            this.ID = ID;
            GrowthValue = growthvalue / 1000.000000 + 1;
            Level = Tool.random.Next(1, 100);
            ATK = (int)(Math.Log(Level+1, GrowthValue));
            HP = (int)(Math.Log(Level+1, GrowthValue) * 10 + ATK);
        }
    }
    class PokemonManager
    {
        private int Serial;
        public Dictionary<int, Pokemon> dictionary;
        public PokemonManager()
        {
            Serial = 1;
            dictionary = new Dictionary<int, Pokemon>();

        }
        public static void AddPokemon(PokemonManager manager, Pokemon pokemon)
        {
            while (manager.dictionary.ContainsKey(manager.Serial))
            {
                manager.Serial++;
            }
            pokemon.Serial = manager.Serial;
            manager.dictionary.Add(manager.Serial, pokemon);
            manager.Serial = 1;
        }
        public static void RemovePokemon(Dictionary<int, Pokemon> dictionary, int serial)
        {

            dictionary.Remove(serial);
        }
        public static void PrintAllPokemon(Dictionary<int, Pokemon> dictionary)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var dict in dictionary)
            {
                Console.WriteLine("序号:{0}  ID{1}  名字:{2}  等级{3}  血量{4}  攻击{5}", dict.Value.Serial, dict.Value.ID, dict.Value.Name, dict.Value.Level, dict.Value.HP, dict.Value.ATK);
            }
            Console.WriteLine("-----------------------------------------------------------------");

        }
        public static void CheckPokemon_FromKey(Dictionary<int, Pokemon> dictionary, int serial)
        {
            if (dictionary.ContainsKey(serial))
            {
                Console.WriteLine("你要查找的小精灵是:");
                Console.WriteLine("序号:{0}  ID{1}  名字:{2}  等级{3}  血量{4}  攻击{5}", dictionary[serial].Serial, dictionary[serial].ID, dictionary[serial].Name, dictionary[serial].Level, dictionary[serial].HP, dictionary[serial].ATK);
            }
            else
            {
                Console.WriteLine("没有你所查找的小精灵");
            }
        }

        public static void CheckPokemon_FromValue(Dictionary<int, Pokemon> dictionary, string name)
        {
            var lists = new List<Pokemon>();
            foreach (var dict in dictionary)
            {
                if (dict.Value.Name == name)
                {
                    lists.Add(dict.Value);
                }
            }
            if (lists.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("你要查找的小精灵是:");
                foreach (var list in lists)
                {                   
                    Console.WriteLine("序号:{0}  ID{1}  名字:{2}  等级{3}  血量{4}  攻击{5}", list.Serial, list.ID, list.Name, list.Level, list.HP, list.ATK);
                }
                Console.WriteLine("-----------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("没有你所查找的小精灵");
            }
        }
        public static void CheckPokemon_FromValue(Dictionary<int, Pokemon> dictionary, int level)
        {
            var lists = new List<Pokemon>();
            foreach (var dict in dictionary)
            {
                if (dict.Value.Level == level)
                {
                    lists.Add(dict.Value);
                }
            }
            if (lists.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                foreach (var list in lists)
                {
                    Console.WriteLine("你要查找的小精灵是:");
                    Console.WriteLine("序号:{0}  ID{1}  名字:{2}  等级{3}  血量{4}  攻击{5}", list.Serial, list.ID, list.Name, list.Level, list.HP, list.ATK);
                }
                Console.WriteLine("-----------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("没有你所查找的小精灵");
            }
        }
        //public bool PokemonBattle(Pokemon pokemon1,Pokemon pokemon2)
        //{
        //}
    }
    class Program
    {
        static Pokemon CreateRandomPokemon()
        {
            Pokemon RandomPokemon;
            int r = Tool.random.Next(1, 11);
            switch (r)
            {
                case 1:
                    var v1 = new Pokemon("皮卡丘", 01, 13);
                    RandomPokemon = v1;
                    break;
                case 2:
                    var v2 = new Pokemon("鲤鱼王", 02, 31);
                    RandomPokemon = v2;
                    break;
                case 3:
                    var v3 = new Pokemon("宝石海星", 03, 21);
                    RandomPokemon = v3;
                    break;
                case 4:
                    var v4 = new Pokemon("耿鬼", 04, 11);
                    RandomPokemon = v4;
                    break;
                case 5:
                    var v5 = new Pokemon("勇吉拉", 05, 8);
                    RandomPokemon = v5;
                    break;
                case 6:
                    var v6 = new Pokemon("卡比兽", 06, 14);
                    RandomPokemon = v6;
                    break;
                case 7:
                    var v7 = new Pokemon("妙蛙种子", 07, 19);
                    RandomPokemon = v7;
                    break;
                case 8:
                    var v8 = new Pokemon("雷龙", 08, 7);
                    RandomPokemon = v8;
                    break;
                case 9:
                    var v9 = new Pokemon("可达鸭", 09, 30);
                    RandomPokemon = v9;
                    break;
                default:
                    var v10 = new Pokemon("梦幻", 010, 1);
                    RandomPokemon = v10;
                    break;
            }
            return RandomPokemon;
        }
        public static int InputKeyInfo_ToInt(ConsoleKeyInfo keyInfo)
        {
            int n;
            while (!int.TryParse(keyInfo.KeyChar.ToString(), out n))
            {
                keyInfo = Console.ReadKey();
            }
            return n;
        }
        public static void Action_1(PokemonManager manager)
        {           
            while(true)
            {
                Console.WriteLine("你选择:1.探索 2.查看图鉴");
                int n = InputKeyInfo_ToInt(Console.ReadKey());
                if (!(n == 1 || n == 2))
                {
                    continue;
                }
                switch (n)
                {
                    case 1:
                        int r = Tool.random.Next(1, 3);
                        if (r == 1)
                        {
                            var pokemon = CreateRandomPokemon();
                            Console.WriteLine("你遇到了:等级{0} {1}", pokemon.Level, pokemon.Name);
                            Action_2(manager,pokemon);
                            continue;
                        }
                        Console.WriteLine("你什么都没遇到");
                        continue;
                    case 2:

                        PokemonManager.PrintAllPokemon(manager.dictionary);
                        Action_3(manager);
                        continue;
                }
            }
        }
        public static void Action_2(PokemonManager manager,Pokemon pokemon)
        {
            while(true)
            {
                Console.WriteLine("你选择:1.收服 2.离开");
                int n = InputKeyInfo_ToInt(Console.ReadKey());
                if (!(n == 1 || n == 2))
                {
                    continue;
                }
                if(n==1)
                {
                    PokemonManager.AddPokemon(manager, pokemon);
                    Console.WriteLine("你成功收服了:等级{0} {1}", pokemon.Level, pokemon.Name);
                    return;
                }
                Console.WriteLine("你嫌它太丑,离开了...");
                return;
            }

        }
        public static void Action_3(PokemonManager manager)
        {
            while(true)
            {
                Console.WriteLine("你选择:1.按序号查找小精灵 2.按名字查找小精灵 3.按等级查找小精灵");
                int n = InputKeyInfo_ToInt(Console.ReadKey());
                if (!(n == 1 || n == 2 || n == 3))
                {
                    continue;
                }
                if(n==1)
                {
                    Console.WriteLine("请输入小精灵的序号:");
                    int input;
                    if( int.TryParse(Console.ReadLine(),out input))
                    {
                        PokemonManager.CheckPokemon_FromKey(manager.dictionary, input);
                        Action_4(manager);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("输入错误");
                        continue;
                    }
                }
                else if(n==3)
                {
                    Console.WriteLine("请输入小精灵的等级:");
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        PokemonManager.CheckPokemon_FromValue(manager.dictionary, input);
                        Action_4(manager);
                        return;
                    }
                    Console.WriteLine("输入错误");
                    continue;
                }
                else
                {
                    Console.WriteLine("请输入小精灵的名字:");
                    PokemonManager.CheckPokemon_FromValue(manager.dictionary, Console.ReadLine());
                    Action_4(manager);
                    return;
                }
            }        
        }
        public static void Action_4(PokemonManager manager)
        {
            while(true)
            {
                Console.WriteLine("你选择:1.放生小精灵 2.离开");
                int n = InputKeyInfo_ToInt(Console.ReadKey());
                if (n == 1)
                {
                    Console.WriteLine("请输入小精灵的序号:");
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        Console.WriteLine("你放生了:等级{0} {1}", manager.dictionary[input].Level, manager.dictionary[input].Name);
                        PokemonManager.RemovePokemon(manager.dictionary, input);                      
                        return;
                    }
                    Console.WriteLine("输入错误");
                    continue;
                }
                return;
                
            }
            
        }
        static void Main(string[] args)
        {
            var Initial_Pokemon = CreateRandomPokemon();
            var manager = new PokemonManager();
            PokemonManager.AddPokemon(manager, Initial_Pokemon);
            Console.WriteLine("欢迎来到宠物小精灵世界,获得你的初始小精灵");
            Console.WriteLine("恭喜你获得了:等级{0} {1}", Initial_Pokemon.Level, Initial_Pokemon.Name);
            Console.WriteLine("-------------------------------------------------");
            Action_1(manager);


            //PokemonManager.PrintAllPokemon(manager.dictionary);


            Console.ReadKey();
        }
    }
}
