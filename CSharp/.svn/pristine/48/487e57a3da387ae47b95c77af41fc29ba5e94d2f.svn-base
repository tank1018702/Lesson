using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 关卡逻辑在本文件中自定义


namespace Rogue
{
    // 这部分是关卡自定义
    public class CustomLevels
    {
        // 利用Delegate，简化MapPos函数的使用。否则每次用MapPos都要写Rogue.MapPos
        delegate int DelegateMapPos(int x, int y);
        static DelegateMapPos MapPos = Rogue.MapPos;
        delegate void DelegateMapXY(int pos, out int x, out int y);
        static DelegateMapXY MapXY = Rogue.MapXY;

        // 自定义关卡流程，新加关卡可以再后面加，也可以删除关卡或者调整顺序
        public static void AddAllLevels()
        {
            Rogue.AddLevel(InitLevel1);
            Rogue.AddLevel(InitLevel2);
            Rogue.AddLevel(InitLevel3);
        }

        static void MonsterDropMoney(Monster monster)
        {
            if (monster.drop_money <= 0)
            {
                return;
            }

            Money money = new Money(monster.drop_money);
            int pos = MapPos(monster.x, monster.y);

            Rogue.moneys[pos] = money;
            MapXY(pos, out money.x, out money.y);
        }

        static void InitLevel1()
        {
            Rogue.level_target = "目标：消灭所有怪物。";

            Rogue.AddMonster(1, 1, 1);
            Rogue.AddMonster(10, 5, 2);
            Rogue.AddMonster(15, 14, 3);

            Rogue.AddMonster(0, 10, 9);

            OldMan oldman = new OldMan("戴黑框眼镜的老者", 100);
            oldman.SetPos(Rogue.map_width - 1, Rogue.map_height - 1);
            Rogue.npcs[MapPos(oldman.x, oldman.y)] = oldman;

            Rogue.onMonsterDead = (Monster monster) =>
            {
                if (Rogue.monsters.Count() <= 1)
                {
                    Rogue.OnStageClear();
                }
                return true;
            };

            //// 匿名函数还可以像下面这样写：

            //Rogue.onMonsterDead = delegate (Monster monster)
            //{
            //    if (Rogue.monsters.Count() <= 1)
            //    {
            //        Rogue.OnStageClear();
            //    }
            //    return true;
            //};
        }

        static void InitLevel2()
        {
            Rogue.level_target = "目标：升到9级。";
            Rogue.AddMonster(3, 3, 1);

            Rogue.onMonsterDead = (Monster monster) =>
            {
                if (Rogue.player.level == 8)
                {
                    Rogue.OnStageClear();
                    return true;
                }

                int pos = Rogue.RandPos();
                int x, y;
                MapXY(pos, out x, out y);
                Rogue.AddMonster(x, y, 1);

                Rogue.level_target = string.Format("目标：升到9级。({0}/9)", Rogue.player.level + 1);
                return true;
            };
        }

        static void InitLevel3()
        {
            Rogue.level_target = "目标：消灭Boss!";
            Rogue.AddMonster(3, 3, Rogue.random.Next(1, 3), 10);
            Rogue.AddMonster(15, 20, Rogue.random.Next(1, 3), 10);
            Rogue.AddMonster(20, 1, Rogue.random.Next(2, 4), 10);
            Monster boss1 = Rogue.AddMonster(Rogue.map_width / 2, Rogue.map_height - 1, 90);
            boss1.attack = 8;

            Merchant merchant = new Merchant("尖嘴猴腮的胖子", 200);
            merchant.SetPos(Rogue.map_width - 1, Rogue.map_height - 1);
            Rogue.npcs[MapPos(merchant.x, merchant.y)] = merchant;

            Rogue.onMonsterDead = (Monster monster) =>
            {
                if (monster.id == 202)
                {
                    Rogue.OnStageClear();
                    return true;
                }

                if (monster == boss1)
                {
                    merchant.SetState(2);
                    return true;
                }

                MonsterDropMoney(monster);

                int pos = Rogue.RandPos();
                int x, y;
                MapXY(pos, out x, out y);
                if (Rogue.player.level < 9 && Rogue.player.money < 100)
                {
                    Rogue.AddMonster(x, y, Rogue.player.level + 2, (Rogue.player.level + 1) * 10);
                }

                return true;
            };
        }

        static void InitLevel4()
        {

        }
    }
}

namespace Rogue
{
    // 这部分可以自定义NPC、怪物等
    public class OldMan : NPC
    {
        public OldMan(string _name, int _id) : base(_name, _id)
        {
        }

        public override bool OnTalk(Player player, out string text)
        {
            if (player.level <= 3)
            {
                text = name + "：" + "勇者，你还没有掌握面向对象的技术，等你3级以后再来找我吧。";
                return false;
            }
            text = name + "：" + "我将把我平生所学全部传授给你。";
            for (int i = 0; i < 5; ++i)
            {
                player.AddExp(1);
            }
            return true;
        }
    }

    public class Merchant : NPC
    {
        public Merchant(string _name, int _id) : base(_name, _id)
        {
        }

        int state = 0;

        public void SetState(int s)
        {
            state = s;
        }

        public override bool OnTalk(Player player, out string text)
        {
            if (state == 0)
            {
                if (player.money < 100)
                {
                    text = name + "：" + "勇者，虽然我很尊敬您。但是这把龙渊剑成本价要100块，我也是要吃饭的啊。";
                    return false;
                }
                text = name + "：" + "这把剑就交给你了，一定要为民除害！";
                player.attack += 65;
                player.money -= 100;
                state = 1;
                return false;
            }
            else if (state == 1)
            {
                text = name + "：" + "这把剑就交给你了，一定要为民除害！";
                return false;
            }

            // state == 2
            text = name + "：" + "哈哈哈，你帮助我把讨厌的企鹅爸爸干掉了，非常好。现在让我来送你下地狱吧……";
            return true;
        }

        override public object AfterDisappear()
        {
            Monster m = new Monster(91);
            m.x = x;
            m.y = y;
            m.id = 202;
            m.attack = 1;
            return m;
        }
    }
}

