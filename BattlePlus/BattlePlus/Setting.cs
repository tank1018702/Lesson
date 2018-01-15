using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum SkillType
{
    Active,           //主动技能
    Passive,          //被动技能
    State,            //状态技能,BUFF
    NegativeState,    //负面状态技能,DEBUFF
}
enum StateType
{
    buff,
    debuff,
}

namespace BattlePlus
{
    class Skill
    {
        public SkillType type;      //技能类型
        public int Attack;          //攻击力
        public int Damage;          //伤害值
        public int Defence;         //防御力
        public int Block;           //防御力
        public int MaxHP;           //血量
        public int DamageMultiple;  //技能的伤害倍数
        public int Odds;            //触发几率
        public int Rate;            //命中几率
        public int HealHPOverTime;  //每回合持续性治疗
        public int DamageOverTime;  //每回合持续性伤害
        public int times;           //持续回合数
        public string Name;         //技能名字


        public List<State> States = new List<State>();

        public static Skill CreateActiveSkills(string Name, int Attack, int DamageMulitipe)
        {
            Skill skill = new Skill();
            skill.type = SkillType.Active;
            skill.Name = Name;
            skill.Attack = Attack;
            skill.DamageMultiple = DamageMulitipe;
            skill.Damage = skill.DamageMultiple * skill.Attack;
            return skill;
        }
        public static Skill CreateStateSkills(string Name, int Defence, int Attack, int HealHPOverTime, int times)
        {
            Skill skill = new Skill();
            skill.type = SkillType.State;
            skill.Name = Name;
            skill.Defence = Defence;
            skill.Attack = Attack;
            skill.HealHPOverTime = HealHPOverTime;
            return skill;
        }
    }
        /* public static Skill CreatePassiveSkills(string Name,int Defence,int Odds)
         {
             Skill skill = new Skill();
             skill.type = SkillType.Passive;
             skill.Name = Name;
             skill.Defence = Defence;
             skill.Odds = Odds;
             return skill; 
          }*/
        /* 
       {
           */
    
    /*public static Skill CreateNegativeStateSkill(string Name,int Attack,int DamageOverTime,int Defence)
    {
        Skill skill = new Skill();
        skill.type = SkillType.State;
        skill.Name = Name;
        skill.Attack = Attack;
        skill.Defence = Defence;
        skill.DamageOverTime = DamageOverTime;
        return skill;
    }*/
    class State
    {
        public StateType Type;
        public string Name;
        public int TriggerRate;
        //BUFF
        public int Times;
        public int Attack;
        public int Defence;
        public int HealOverTimes;
        //DEBUFF
        public int DamageOverTime;

        public static State CreatePassiveState_ForCharacter( string _name,int _attack,int _defence)// 被动状态
        {
            State state = new State();
            state.Type = StateType.buff;
            state.Name = _name;
            state.Attack = _attack;
            state.Defence = _defence;
            return state;
        }
        //public static State CreateDamageState_ForAttack()
        //{

        //}



    }


    class Character//角色
    {
        public static Random Random = null;
        public int HP;
        public int MaxHP;
        public int Attack;
        public int Defence;
        public string Name;

        public List<Skill> Skills = new List<Skill>();

        public List<State> States = new List<State>();

        public Character(int _maxhp,int _attack,int _defence,string _name)
        {
            MaxHP = _maxhp;
            Attack = _attack;
            Defence = _defence;
            Name = _name;
            HP = _maxhp;
        }
        public void AddState(State state)
        {
            States.Add(state);
        }
        public State GetState(int state_index)
        {
            State state = States[state_index];
            return state;
        }
        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }
        public Skill GetSkill(int skill_index)
        {
            Skill skill = Skills[skill_index];
            return skill;
        }
        public Skill RandomSkill()
        {
            int r = Random.Next(Skills.Count);
            return GetSkill(r);
        }
        private void CostHP(int n)
        {
            HP -= n;
            if (HP < 0)
            {
                HP = 0;
            }
        }
        public bool BeHit(Skill skill)
        {
            if (HP<0)
            {
                return false;
            }
            switch(skill.type)
            {
                case SkillType.Active:
                    {
                        CostHP(skill.Damage);
                        break;
                    }
                case SkillType.NegativeState:
                    {
                        break;
                    }
                case SkillType.Passive:
                    {
                        break;
                    }
                case SkillType.State:
                    {
                        break;
                    }
                    
            }
            return true;
        }
    }
}
