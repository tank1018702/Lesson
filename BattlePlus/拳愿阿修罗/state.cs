using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    enum StateType
    {
        buff,
        debuff
    }

    class State
    {
        public string Name;
        public StateType type;
        public int AttackUpperlimit;
        public int Attacklowerlimit;
        public int DodgeRate;
        public int CritRate;
        //附加每回合伤害/治疗
        public int DamagePerTime;
        public int HealPerTime;
        //被动BUFF触发条件
        public int MaxHp;
    }
}
