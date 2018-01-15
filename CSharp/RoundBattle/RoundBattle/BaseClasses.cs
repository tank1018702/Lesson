using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundBattle
{
    enum SkillType
    {
        Damage,
        DamageOverTime,
        Heal,
        Invincible,
        Execute,
    }

    enum StateType
    {
        DamageOverTime,
        Invincible,
    }
}

namespace RoundBattle
{
    class Character
    {
        public static Random random = null;//清空随机种子

        public string name;
        public int hp;
        public List<Skill> skills = new List<Skill>();//创建技能列表

        // 正在生效的状态
        public List<State> states = new List<State>();//创建状态列表

        public bool AddState(State state)
        {
            states.Add(state);
            return true;
        }

        public bool HasState(StateType state_type)//状态数量的判定
        {
            for (int i=0; i<states.Count; ++i)
            {
                if (states[i].time>0 && states[i].type == state_type)//如果状态列表里的第i个状态持续回合时间大于0且第i个状态类型与当前状态类型相同
                {
                    return true;
                }
            }
            return false;
        }

        public void AddSkill(Skill skill)//在创建角色时添加技能到角色的技能列表
        {
            skills.Add(skill);
        }

        public Skill GetSkill(int skill_index)//使用技能前加载技能的函数
        {
            Skill skill = skills[skill_index];
            return skill;
        }

        public Skill RandSkill()//骷髅兵的随机选择技能函数
        {
            int r = random.Next(skills.Count);
            return GetSkill(r);
        }

        private void CostHp(int n)//CostHP()函数属于Character类的私有函数,由BeHit()函数调用
        {
            hp -= n;
            if (hp < 0)
            {
                hp = 0;
            }
        }

        public bool BeHit(Skill skill)//被攻击的判定
        {
            if (hp <= 0)
            {
                return false;
            }
            switch (skill.type)//技能类型的判定
            {
                case SkillType.Damage://直接伤害技能
                    if (HasState(StateType.Invincible))//无敌状态判定 当状态中有无敌效果时此次伤害无效
                    {
                        return false;
                    }
                    CostHp(skill.damage);
                    break;
                case SkillType.DamageOverTime://DOT技能
                    State temp = new State(StateType.DamageOverTime, skill.time_DOT, skill.damage_DOT);
                    temp.name = skill.name;
                    AddState(temp);
                    break;
                case SkillType.Heal://治疗技能
                    hp += skill.heal;
                    break;
                case SkillType.Invincible://无敌
                    State temp2 = new State(StateType.Invincible, skill.time, 0);
                    temp2.name = skill.name;
                    AddState(temp2);
                    break;
                case SkillType.Execute://斩杀
                    CostHp(hp);
                    break;
            }
            return true;
        }

        public List<State> StateTakeEffect(Character cur_cha)//正在生效状态效果列表
        {
            List<State> effect_states = new List<State>();

            //for(int i=effect_states.Count-1;i>=0; i--)
            foreach (State state in states)
            {
                if (state.time == 0)
                {
                    continue;
                }
                effect_states.Add(state);
                switch (state.type)
                {
                    case StateType.DamageOverTime:
                        CostHp(state.damage);
                        state.time -= 1;
                         Console.WriteLine("{0}的{1}状态生效，当前HP:{2}", cur_cha.name, state.name, cur_cha.hp);
                        break;
                    case StateType.Invincible:
                        state.time -= 1;
                        break;
                }
            }
            return effect_states;
        }

        public bool UseSkill(Skill skill, Character target_cha)//技能使用条件的判断函数
        {
            switch(skill.type)
            {
                case SkillType.Execute://处决技能
                    if (target_cha.hp >= skill.max_hp)//目标血量大于等于斩杀血量则返回FALSE
                    {
                        return false;
                    }
                    return true;
                default:
                    return true;
            }
        }
    }

    class Skill
    {
        public string name;
        public SkillType type;

        // 攻击类型
        public int damage;

        // 治疗类型
        public int heal;

        // DOT类型
        public int time_DOT;
        public int damage_DOT;

        // 处决类型
        public int max_hp;

        // 无敌类型
        public int time;

        public static Skill CreateDamageSkill(string name, int damage)//创建直接伤害类型技能
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.type = SkillType.Damage;
            skill.damage = damage;
            return skill;
        }

        public static Skill CreateDOTSkill(string name, int time, int damage)
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.type = SkillType.DamageOverTime;
            skill.time_DOT = time;
            skill.damage_DOT = damage;
            return skill;
        }

        public static Skill CreateHealSkill(string name, int heal)
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.type = SkillType.Heal;
            skill.heal = heal;
            return skill;
        }

        public static Skill CreateInvincibleSkill(string name, int time)
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.type = SkillType.Invincible;
            skill.time = time;
            return skill;
        }

        public static Skill CreateExecuteSkill(string name, int hp)
        {
            Skill skill = new Skill();
            skill.name = name;
            skill.type = SkillType.Execute;
            skill.max_hp = hp;
            return skill;
        }
    }

    class State
    {
        public StateType type;
        public string name;
        public int damage;
        public int time;
         public State(StateType t, int d1, int d2)// 状态的构造函数
        {
            type = t;
            switch(t)
            {
                case StateType.DamageOverTime:
                    time = d1;
                    damage = d2;
                    break;
                case StateType.Invincible:
                    time = d1;
                    break;
            }
        }

        public override string ToString()//重载ToString()函数的返回值  加上自己要的信息
        {
            return name + "(" + time + ")";
        }
    }

}
