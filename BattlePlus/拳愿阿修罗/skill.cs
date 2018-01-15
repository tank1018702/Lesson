using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    enum SkillType
    {
        ActiveDamageSkill,         //主动伤害技能,可附加负面状态
        ActiveStateSkill,          //主动BUFF,有持续时间
        PassiveStateSkill,         //被动BUFF,常驻
        PassiveTriggerStateSkill   //被动触发BUFF,有触发条件或者几率
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
        public virtual  Skill CreateDamageSkill (string name,int damagerate,int triggerrate)
        {
            Skill skill = new Skill();
            skill.Type = SkillType.ActiveDamageSkill;
            skill.StateTrigger = false;
            skill.Name = name;
            skill.DamageRate = damagerate;
            skill.TriggerRate = triggerrate;
            skill.AddState(State.CreateDebuff());



            return skill;
        }

    }
}
