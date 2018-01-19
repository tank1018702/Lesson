using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Pokemon
    {
        // 小精灵的数据
        public long id = 0;
        public string name;

        public Pokemon(string name, int level)
        {
            this.name = name;
            this.level = level;
        }

        public int level = 0;
    }

    // 1 注意id的一致性
    // 2 保持dict 和 dictName的一致性

    class PokemonManager
    {
        Dictionary<long, Pokemon> dict = new Dictionary<long, Pokemon>();
        Dictionary<string, List<long>> dictName = new Dictionary<string, List<long>>();

        private long idCounter = 1;
        
        // id不是精灵自己的，而是管理器确定
        public void AddPokemon(Pokemon p)
        {
            p.id = idCounter;
            idCounter++;
            dict[p.id] = p;

            // 写法1
            //if (dictName.ContainsKey(p.name))
            //{
            //    var l = dictName[p.name];
            //    l.Add(p.id);
            //}
            //else
            //{
            //    var l = new List<int>();
            //    dictName[p.name] = l;
            //    l.Add(p.id);
            //}

            // 写法2
            List<long> l = null;
            if (!dictName.ContainsKey(p.name))
            {
                l = new List<long>();
                dictName[p.name] = l;
            }
            else
            {
                l = dictName[p.name];
            }
            l.Add(p.id);
        }

        public bool DelPokemon(long id)
        {
            if (!dict.ContainsKey(id))
            {
                return false;
            }
            Pokemon p = dict[id];

            var list = dictName[p.name];
            list.Remove(p.id);
            if (list.Count == 0)
            {
                dictName.Remove(p.name);
            }

            dict.Remove(id);
            
            return true;
        }

        public Pokemon FindByID(long id)
        {
            if (!dict.ContainsKey(id))
            {
                return null;
            }
            return dict[id];
        }

        public List<Pokemon> FindByName(string name)
        {
            List<Pokemon> list = new List<Pokemon>();
            if (!dictName.ContainsKey(name))
            {
                return list;
            }

            var listID = dictName[name];
            foreach (var id in listID)
            {
                list.Add(dict[id]);
            }
            return list;
        }

        // 如果找不到则返回长度为0的List
        public List<Pokemon> FindByLevel(int level)
        {
            var list = new List<Pokemon>();
            foreach (var pair in dict)
            {
                if (pair.Value.level == level)
                {
                    list.Add(pair.Value);
                }
            }
            return list;
        }

        private void PrintList(List<long> list)
        {
            Console.Write("[");
            foreach(var n in list)
            {
                Console.Write(n+", ");
            }
            Console.WriteLine("] ");
        }

        public void Print()
        {
            Console.WriteLine("----------------------------------");
            foreach(var pair in dict)
            {
                Console.WriteLine("{0}:{1} {2}", pair.Key, pair.Value.id, pair.Value.name);
            }
            Console.WriteLine("===============================");
            foreach(var pair in dictName)
            {
                Console.Write(pair.Key + " : ");
                PrintList(pair.Value);
            }
        }

    }

    class Program
    {
        static PokemonManager pokemonManager;
        static void Main(string[] args)
        {
            pokemonManager = new PokemonManager();

            Pokemon p1 = new Pokemon("皮卡丘", 3);
            Pokemon p2 = new Pokemon("小火龙", 4);
            Pokemon p3 = new Pokemon("水箭龟", 3);
            Pokemon p4 = new Pokemon("皮卡丘", 6);
            Pokemon p5 = new Pokemon("水箭龟", 1);

            pokemonManager.AddPokemon(p1);
            // pokemonManager.AddPokemon(p1);  这样会有严重BUG
            pokemonManager.AddPokemon(p2);
            pokemonManager.AddPokemon(p3);
            pokemonManager.AddPokemon(p4);
            pokemonManager.AddPokemon(p5);

            pokemonManager.Print();

            pokemonManager.DelPokemon(1);
            pokemonManager.DelPokemon(4);
            pokemonManager.Print();
            pokemonManager.AddPokemon(p1);
            pokemonManager.Print();

            var list = pokemonManager.FindByLevel(3);
            foreach(var p in list)
            {
                Console.WriteLine("{0}:{1}  {2}级", p.id, p.name, p.level);
            }

            Console.ReadKey();
        }
    }
}
