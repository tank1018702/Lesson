using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battle
{
    class Character//角色
    {
        public int HP;
        public int MaxHP;
        public int Attack;
        public int Defence;
        public string Name;
        public Character()
        {
            
        }

        public void Battle( int Attack, int Defence)//战斗模块
        {
            HP = HP - (Attack - Defence);
            if (HP < 0)
            {
                HP = 0;
            }
        }            
    }
    class SpecificAbility : Character//特殊人物
    {
        public string SkillName;
     
        public void chuenge(int HPIn)
        {
            HP = HPIn + 80;
        }
        public void DoubleAttack(int AttackIn)
        {
            Attack=AttackIn*2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SpecificAbility Player1 = new SpecificAbility
            {
                Name = "十鬼蛇王马",
                SkillName = "分解持家蛋白",
                Attack = 17,
                Defence = 10,
                HP = 175,
            };
            SpecificAbility Player2 = new SpecificAbility
            {
                Name = "桐生刹那",
                SkillName="修罗模式",
                Attack = 14,
                Defence = 8,
                HP = 190,
            };
            bool Trigger1 = true;
            bool Trigger2 = true;
            while (Player1.HP>0&&Player2.HP>0)
            {
                Player1.Battle(Player2.Attack, Player1.Defence);
                Console.WriteLine(Player2.Name + "对" + Player1.Name + "造成了" + (Player2.Attack - Player1.Defence) + "的伤害," + Player1.Name + "剩余" + Player1.HP + "点HP");
                if (Player2.HP<190/2&&Trigger1==true)
                {
                    Player2.DoubleAttack(Player2.Attack);
                    Console.WriteLine(Player2.Name + "使用" + Player2.SkillName + ",伤害提高!");
                    Trigger1 = false;
                }
                Player2.Battle(Player1.Attack, Player2.Defence);
                Console.WriteLine(Player1.Name + "对" + Player2.Name + "造成了" + (Player1.Attack - Player2.Defence) + "的伤害," + Player2.Name + "剩余" + Player2.HP + "点HP");
                if (Player1.HP == 0 && Trigger2 == true)
                {
                    Player1.chuenge(Player1.HP);
                    Console.WriteLine(Player1.Name + "使用" + Player1.SkillName + "血量提高!");
                    Trigger2 = false;
                }
            }
            if(Player1.HP==0)
            {
                Console.WriteLine(Player2.Name + "胜利");
            }
            else
            {
                Console.WriteLine(Player1.Name + "胜利");
            }
            Console.ReadKey();
        }
        
    }
}
