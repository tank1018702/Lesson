using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Character
    {
        public int ID;
        /// <summary>
        /// 角色名字
        /// </summary>
        public string Name;
        /// <summary>
        /// 角色的身份信息介绍
        /// </summary>
        public string Info = "略";
        /// <summary>
        /// 力量值,与伤害相关
        /// </summary>
        public int Strength;
        /// <summary>
        /// 体格值,与抗击打能力相关
        /// </summary>
        public int Frame;
        /// <summary>
        /// 敏捷值,与暴击和命中相关
        /// </summary>
        public int Agile;
        /// <summary>
        /// 当前血量
        /// </summary>
        public int HP;
        /// <summary>
        /// 当前体力值(或者耐力值),类似MP,技能需要消耗体力值才能释放,否则只能普攻
        /// </summary>
        public int STA;
        /// <summary>
        /// 角色预设技能列表(所有技能)
        /// </summary>
        public List<Skill> Skills = new List<Skill>();
        /// <summary>
        /// 当前加载技能
        /// </summary>
        public List<Skill> CurrentSkills = new List<Skill>();
        /// <summary>
        /// 角色状态列表
        /// </summary>
        public List<State> states = new List<State>();
        public Character(string name,int strength,int frame,int agile)
        {
            Name = name;
            Strength = strength;
            Frame = frame;
            Agile = agile;
      
        }
        /// <summary>
        /// 伤害计算函数,伤害随力量呈对数曲线增长
        /// </summary>
        /// <param name="strength"></param>
        /// <returns></returns>
        public  int Damage(int strength)
        {
            int damage = (int)Math.Log((strength/10.0+1), 1.003);
            return damage;
        }
        /// <summary>
        /// 最大生命值计算函数,随体格呈对数曲线增长
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public  int MaxHP(int frame)
        {
            int maxhp = (int)Math.Log((frame / 10.0 + 1), 1.0002772);
            return maxhp;
        }
        /// <summary>
        /// 减免伤害计算函数,即抗击打能力,随体格呈对数曲线增长
        /// </summary>
        /// <param name="frame">体格</param>
        /// <returns></returns>
        public  int DamageModifier(int frame)
        {
            int damagemodifier = (int)Math.Log((frame / 10.0 + 1), 1.010);
            return damagemodifier;
        }
        /// <summary>
        /// 最大体力(或者叫耐力)计算函数,随体格呈对数曲线增长,使用技能的主要消耗
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public  int MaxSTA(int frame)
        {
            int stamina = (int)Math.Log((frame / 10.0 + 1), 1.000693);
            return stamina;
        }
        /// <summary>
        /// 暴击率计算函数,随敏捷呈指数增涨
        /// </summary>
        /// <param name="agile"></param>
        /// <returns></returns>
        public  int CritRate(int agile)
        {
            int critrate = (int)Math.Pow((agile + 10) / 10.0 + 1, 3.163);
            return critrate;
        }
        /// <summary>
        /// 闪避率计算函数,随敏捷呈指数增涨
        /// </summary>
        /// <param name="agile"></param>
        /// <returns></returns>
        public  int DodgeRate(int agile)
        {
            int dodgerate = (int)Math.Pow(agile / 10.0 + 1, 4.65);
            return dodgerate;
        }
        /// <summary>
        /// 把角色的技能添加到角色技能列表里
        /// </summary>
        /// <param name="skill"></param>
        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }
        /// <summary>
        /// 判段角色是否具有某种状态
        /// </summary>
        /// <param name="stateType"></param>
        /// <returns></returns>
        public bool HasState(StateType stateType)
        {
            foreach (State s in states)
            {
                if (s.StateType== stateType)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 随机在当前主动技能列表中选择一个技能作为使用技能
        /// </summary>
        /// <param name="list">当前技能列表</param>
        /// <returns></returns>
        public Skill RandomSkill(List<Skill> list)
        {
            Skill skill = null;
            while(skill==null)
            {
                skill = list[Utils.random.Next(list.Count - 1)];
                if (skill.CanUseSkill(this))
                {
                    return skill;
                }
                skill = null;  
            }             
            return skill;
        }

        /// <summary>
        /// 判断人物是否被命中
        /// </summary>
        /// <param name="cha">被击中者</param>
        /// <returns></returns>
        public bool IsHit(Character cha)
        {
            return Utils.random.Next(1, 101) > cha.DodgeRate(cha.Agile) ? false : true;        
        }
        /// <summary>
        /// 判断攻击者的攻击是否是致命一击
        /// </summary>
        /// <param name="cha">攻击者</param>
        /// <returns></returns>
        public bool IsCrit(Character cha)
        {
            return Utils.random.Next(1, 101) > cha.CritRate(cha.Agile) ? false : true;
        }
        /// <summary>
        /// 将状态添加到人物的状态列表里,包括BUFF和DEBUFF
        /// </summary>
        /// <param name="state"></param>
        public void AddState(State state)
        {
            states.Add(state);
        }

       

        public bool IsAlive()
        {
            if (HP == 0)
                return false;
            return true;
        }
    }
}
