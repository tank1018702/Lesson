using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePlus
{
    class Battle
    {
        static Random random = new Random();
        static Character player;
        static Character enemy;

        static void GetEnemy()
        {
            enemy = CreateEnemy();
        }
        static Character CreatePlayer()//创建玩家角色
        {
            Character Player1 = new Character(1600,11,5,"十鬼蛇王马");
            Player1.AddSkill(Skill.CreateActiveSkills("直拳", Player1.Attack, 1));
            Player1.AddSkill(Skill.CreateActiveSkills("二虎流,金刚型,瞬铁,爆", Player1.Attack,3));
            return Player1;
        }
        static Character CreateEnemy()//创建敌对角色
        {
            Character Player2 = new Character(1150,12,5,"桐生刹那");
            Player2.AddSkill(Skill.CreateActiveSkills("鞭腿", Player2.Attack, 1));
            Player2.AddSkill(Skill.CreateActiveSkills("狐影流,罗刹掌", Player2.Attack, 4));
            return Player2;
        }
        static Skill InputSkill(List<Skill> Skills)
        {    
            int n = random.Next(Skills.Count);
            return Skills[n];
        }
        static void ShowInfo(Character cha)
        {
            Console.WriteLine("{0}的信息：", cha.Name);
            Console.Write("    HP:{0}/{1}  ", cha.HP,cha.MaxHP);
            
            /*for (int i = 0; i < cha.states.Count; ++i)
            {
                Console.Write("状态:{0} ", cha.states[i]);
            }*/
            Console.WriteLine();
        }
        static Character RoundBattle()
        {
            int round = 1;
            Character victory_cha;

            while (player.HP > 0 && enemy.HP> 0)
            {
                Console.WriteLine("------------第{0}回合--------------", round);

                ChaAct(player, enemy);
                if (enemy.HP <= 0)
                {
                    break;
                }
                ChaAct(enemy, player);

                ShowInfo(player);//输出玩家的信息
                ShowInfo(enemy);//输出怪物的信息
                Console.WriteLine();
                round += 1;
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }

            if (player.HP > 0)
            {
                victory_cha = player;
            }
            else
            {
                victory_cha = enemy;
            }
            return victory_cha;

        }
        static void ChaAct(Character character1, Character character2)
        {
            if (character1 == player)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else                 
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Skill skill = null;
            if(character1==player)
            {
                skill = player.RandomSkill();
                Console.WriteLine("{0}使用了'{1}'技能", player.Name, skill.Name);
            }
            else
            {
                skill = enemy.RandomSkill();
                Console.WriteLine("{0}使用了'{1}'技能", enemy.Name, skill.Name);
            }
            if(skill.type==SkillType.Active||skill.type==SkillType.NegativeState)
            {
                if(character2.BeHit(skill))
                {
                    if (skill.type == SkillType.Active)
                    {
                        Console.WriteLine("{0}受到伤害{1}点，当前HP:{2}", character2.Name, skill.Damage, character2.HP);
                    }
                    else if(skill.type==SkillType.NegativeState)
                    {
                        Console.WriteLine("{0}中了状态", character2.Name );
                    }
                }
            }
            else
            {
                if(character1.BeHit(skill))
                {
                    if(skill.type==SkillType.State)
                    {
                        Console.WriteLine("{0}成功加上了无敌状态", skill.Name);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Main(string[] args)
        {
            Character.Random = random;
            player = CreatePlayer();            
            int Victory_Times = 0;
            while(true)
            {
                GetEnemy();
                Character Victory_Character = RoundBattle();
                if (Victory_Character == player)
                {
                    Console.WriteLine("{0}战胜了{1}", player.Name, enemy.Name);
                    Victory_Times += 1;
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("{1}战胜了{0}", player.Name, enemy.Name);
                    break;
                }
                


            }
            Console.ReadKey();

        }
    }
}
