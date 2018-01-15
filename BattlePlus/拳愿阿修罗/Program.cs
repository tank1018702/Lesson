using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Program
    {
        static List<Character> CreateCharacterList(List<Character> list)
        {
            Character cha1 = new Character("十鬼蛇王马", 2500, 27, 105);
            cha1.AddSkill()

            list.Add(cha1);

            Character cha2 = new Character("桐生刹那", 1900, 15, 157);


            list.Add(cha2);


            


            return list;
        }
        
        static Character GetCharacter(List<Character> list)
        {
            int r = Utils.random.Next(list.Count);
            Character randomcharacter = list[r];
            list.Remove(list[r]);
            return randomcharacter;
        }
        static void Main(string[] args)
        {
            int Victory_times = 0;
            List<Character> characters = new List<Character>();
            CreateCharacterList(characters);
            Character player = GetCharacter(characters);
            Character enemy = GetCharacter(characters);
            
            Console.ReadKey();
        }
    }
}
