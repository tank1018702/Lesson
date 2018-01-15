using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 回合制对战游戏。
// 用面向对象方式实现，数据与逻辑分离，具有一定的扩展性


// 练习：
// 1、理解战斗的过程。试着改变主角和NPC，改变他们的技能。（只需要修改关卡初始化就可以实现），
// 2、本程序中，技能可以增加新的类型，比如无敌N回合的技能。试着实现这个技能。
//    思考一下：持续掉血、持续加血、持续无敌，这类加状态的技能，能否用一种技能类型代替？
// 3、扩展性是相对的。本程序增加怪物、主角非常容易，增加技能和效果也不是很麻烦。
//    但是如果回血类技能有次数限制，应该如何做呢？

namespace RoundBattle
{
    class RoundBattle
    {
        static Random random = new Random();

        static Character player;
        static Character monster;

        // ------关卡设置------
        static void InitStage()
        {
            monster = CreateSkeleton();//设置怪物
        }

        static Character CreateSimon()
        {
            Character simon = new Character();
            simon.name = "西蒙";
            simon.hp = 100;
            simon.AddSkill(Skill.CreateDamageSkill("出拳", 100));//创建技能,然后添加进技能列表
            simon.AddSkill(Skill.CreateDOTSkill("圣水A", 10, 2));
            simon.AddSkill(Skill.CreateDOTSkill("圣水B", 9, 3));
            simon.AddSkill(Skill.CreateDOTSkill("圣水C", 8, 4));
            simon.AddSkill(Skill.CreateExecuteSkill("处决", 30));
            simon.AddSkill(Skill.CreateHealSkill("吃鸡腿", 50));
            return simon;
        }

        static Character CreateSkeleton()//创建怪物
        {
            Character monster = new Character();
            monster.name = "骷髅兵";
            monster.hp = 50;
            monster.AddSkill(Skill.CreateDOTSkill("白骨风暴", 3,10));
            //monster.AddSkill(Skill.CreateHealSkill("死亡之舞", 30));
            return monster;
        }
        // -------------------

        // -------回合内函数-----
        static void ShowSkills(Character cha) //打印技能列表到控制台
        {
            for (int i=0; i<cha.skills.Count; ++i)
            {
                Console.WriteLine("{0}. {1}", i+1, cha.skills[i].name);
            }
        }

        static Skill InputSkill(List<Skill> skills)  // 选择技能
        {
            int n = -1;
            // 用户输入的是从1开始
            while (n <= 0 || n > skills.Count)//控制用户输入1-技能个数之间的整数
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                int.TryParse(keyinfo.KeyChar.ToString(), out n);
            }

            return skills[n-1];//返回选择的技能
        }

        static void ShowInfo(Character cha)
        {
            Console.WriteLine("{0}的信息：", cha.name);
            Console.Write("    HP:{0}  ", cha.hp);
            for (int i=0; i<cha.states.Count; ++i)
            {
                Console.Write("状态:{0} ", cha.states[i]);
            }
            Console.WriteLine();
        }

        static bool AllChasAlive(List<Character> l)//所有角色是否全部存活的判定
        {
            foreach (Character cha in l)
            {
                if (cha.hp<= 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void ChaAct(Character cur_cha, Character other_cha)//战斗模块
        {
            if (cur_cha == player)//玩家回合
            {
                Console.ForegroundColor = ConsoleColor.Green;//玩家的战斗信息用绿色输出
            }
            else                 //怪物回合
            {
                Console.ForegroundColor = ConsoleColor.Red;//怪物的战斗信息用红色输出
            }
            var effect_states = cur_cha.StateTakeEffect(cur_cha);//状态效果
            for (int i= effect_states.Count-1;  i>=0; i--)
            {
                if(effect_states[i].time==0)
                {
                    effect_states.Remove(effect_states[i]);
                }
                //Console.WriteLine("{0}的{1}状态生效，当前HP:{2}", cur_cha.name, effect_states[i].name, cur_cha.hp);
            }

            Skill skill = null;//单回合结束 技能重置为NULL
            // 选择技能的方式不同
            if (cur_cha == player)//如果使用技能的是玩家
            {
                while (true)
                {
                    Console.WriteLine("====请选择{0}的技能：", cur_cha.name);
                    ShowSkills(cur_cha);//调用角色技能的函数
                    skill = InputSkill(player.skills);//加载玩家选择的技能
                    if (!cur_cha.UseSkill(skill, other_cha))//判断技能使用条件是否满足(此处判定斩杀线)
                    {
                        Console.WriteLine("技能使用条件不满足, 重新选择");
                        continue;
                    }
                    break;
                }
            }
            else//使用技能的是怪物
            {
                skill = monster.RandSkill();//怪物随机选择一个技能
                Console.WriteLine("{0}使用了'{1}'技能", monster.name, skill.name);
            }

            if (skill.type == SkillType.Heal || skill.type == SkillType.Invincible)//技能类型是治疗类型或者无敌类型
            {
                if (cur_cha.BeHit(skill))
                {
                    if (skill.type == SkillType.Heal)
                    {
                        Console.WriteLine("{0}成功受到治疗，当前HP:{1}", cur_cha.name, cur_cha.hp);
                    }
                    else if (skill.type == SkillType.Invincible)
                    {
                        Console.WriteLine("{0}成功加上了无敌状态", skill.name);
                    }
                }
            }
            else
            {
                if (other_cha.BeHit(skill))//作用于怪物或玩家的伤害技能
                {
                    if (skill.type == SkillType.Damage)//直接伤害类型技能
                    {
                        Console.WriteLine("{0}受到伤害{1}点，当前HP:{2}", other_cha.name, skill.damage, other_cha.hp);

                    }
                    else if (skill.type == SkillType.DamageOverTime)//DOT类型
                    {
                        Console.WriteLine("{0}中了状态", other_cha.name);
                    }
                    else if (skill.type == SkillType.Execute)//斩杀类型
                    {
                        Console.WriteLine("{0}被处决了！", other_cha.name);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static Character StageBattle()//战斗回合
        {
            int round = 1;
            Character victory_cha;

            while(player.hp>0 && monster.hp>0)
            {
                Console.WriteLine("--------第{0}回合开始--------------", round);

                ChaAct(player, monster);
                if (monster.hp <= 0)
                {
                    break;
                }
                ChaAct(monster, player);

                ShowInfo(player);//输出玩家的信息
                ShowInfo(monster);//输出怪物的信息
                Console.WriteLine();
                round += 1;
            }

            if (player.hp > 0)
            {
                victory_cha = player;
            }
            else
            {
                victory_cha = monster;
            }
            return victory_cha;
        }
        // -------------------

        static void Main(string[] args)
        {
            Character.random = random;//生成随机种子
            player = CreateSimon();//玩家创建函数

            int victory_times = 0;//胜利次数初始化为0
            while (true)
            {
                InitStage();//设置怪物
                Character victory_cha = StageBattle();//判定胜利的角色
                if (victory_cha == player)
                {
                    Console.WriteLine("{0}战胜了敌人{1}，进入下一关", player.name, monster.name);
                    victory_times += 1;
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("{0}失败了", player.name);
            Console.WriteLine("这次冒险一共前进了{0}关", victory_times);
            Console.WriteLine("GAME OVER");

            Console.ReadLine();
        }
    }
}
