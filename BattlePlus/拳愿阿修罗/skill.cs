using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    enum SkillType
    {
        Active,
        passive
    }
  


    class Skill
    {
        public string Name;
        public SkillType Type;
        bool StateTrigger;
        //

        public int DamageRate;                           //伤害倍率
        public List<State> states = new List<State>();
        //附加状态
        public int TriggerRate;                          //触发状态的触发率
        public int Times;
       
        public void AddState(State state)
        {
            states.Add(state);
        }
        public static  Skill CreateDamageSkill (string name,int damagerate,int triggerrate, int times, StateType type,string state_name,int hpovertime)
        {
            Skill skill = new Skill();
            skill.Type = SkillType.Active;
            skill.StateTrigger = false;
            skill.Name = name;
            skill.DamageRate = damagerate;
            skill.TriggerRate = triggerrate;
            skill.Times = times;
            skill.AddState(State.CreateHPState(type,state_name,hpovertime));
            return skill;
        }

    }
}
