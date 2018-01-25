using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Program
    {
        static Dictionary<int, Character> CreateCharacterDictionary()
        {
            var dict = new Dictionary<int, Character>();
            Character cha1 = new Character("十鬼蛇王马", 2500, 5, 01);




            Character cha2 = new Character("桐生刹那", 1900, 4, 02);







            return dict;
        }

        //static Character GetCharacter(Dictionary<int,Character> dict)
        //{

        //}
        static void Main(string[] args)
        {
            Console.WindowWidth = 115;
            Console.WindowHeight = 40;
            Character text1 = new Character("开发者测试", 10, 10, 10);
            text1.type = CharaType.Player;
            Character text2 = new Character("电脑测试", 9, 9, 9);
            text2.type = CharaType.Computer;
            Draw.DrawFrame(text1);
            Draw.DrawFrame(text2);
            int[] n = { 0 };
            State textstate = new State()
            {
                stateEffectType = StateEffectType.HitDamage,
                StateType = StateType.Buff,
                Name="测试攻击buff"
                
            
            };
            State textstate2 = new State()
            {
                stateEffectType = StateEffectType.HitDamage,
                StateType = StateType.Debuff,
                Name="测试攻击debuff"
                
            };

            while (true)
            {
                Draw.DrawState(text2);
                Draw.DrawHP_and_STA(text1);
                Draw.DrawHP_and_STA(text2);
                Draw.CharacterValueInfo(text1);
                Draw.CharacterValueInfo(text2);
                text1.GetDamage(50,n);
                text1.STA -= 100;
                text2.AddState(textstate,n);
                text2.GetDamage(100, n);
                text2.STA -= 200;
                text1.GetHeal(100, n);


                Console.ReadKey(true);
            }

            Console.ReadKey();
        }
    }
}
