using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Program
    {
        static void ChaAct(Character cha1, Character cha2)
        {
            cha2.BeHit(cha1.attack);
            Console.WriteLine("{0}收到伤害{1}点, 当前生命{2}", cha2.name, cha1.attack, cha2.hp);
        }

        static Character cha1;
        static Character cha2;

        static Character CheckWin()
        {
            if (cha1.IsDead())
            {
                Console.WriteLine("{0}死亡", cha1.name);
                return cha2;
            }
            if (cha2.IsDead())
            {
                Console.WriteLine("{0}死亡", cha2.name);
                return cha1;
            }
            return null;
        }

        static Character StageBattle()
        {

            Character cha_win;
            while (true)
            {
                cha_win = CheckWin();
                if (cha_win != null) { break; }

                ChaAct(cha1, cha2);

                cha_win = CheckWin();
                if (cha_win != null) { break; }

                ChaAct(cha2, cha1);
            }

            return cha_win;
        }

        static void Main(string[] args)
        {
            cha1 = new Character("乌龟", 10, 1);
            cha2 = new Character("毒蘑菇", 5, 2);

            StageBattle();

            Console.ReadKey();
        }
    }
}
