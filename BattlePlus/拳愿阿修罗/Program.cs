using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Program
    {
        public static List<int> IDlist = new List<int>();
        static Dictionary<int, Character> CreateCharacterDictionary()
        {
            var dict = new Dictionary<int, Character>();
            Character cha1 = new Character("十鬼蛇王马", 2500, 5,01);
          
            
            

            Character cha2 = new Character("桐生刹那", 1900, 4,02);
            
            


            


            return dict;
        }
        
        static Character GetCharacter(Dictionary<int,Character> dict)
        {
            int r = Utils.random.Next(IDlist.Count);
            Character randomcharacter = d[r];
            list.Remove(list[r]);
            return randomcharacter;
        }
        static void Main(string[] args)
        {
            int Victory_times = 0;          
           var Character_Dict =CreateCharacterDictionary();
            Character player = GetCharacter(Character_Dict);
            Character enemy = GetCharacter(Character_Dict);
            
            Console.ReadKey();
        }
    }
}
