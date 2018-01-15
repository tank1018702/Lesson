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
        public int HPOverTime;
        //被动BUFF触发条件
        public int MaxHpPersentage;

        public virtual State CreateValueState(StateType type ,string name,int attackupperlimit,int attacklowerlimit,int dodgerate,int critrate)                                                                                                                           
        {
            State state = new State();
            state.type = type;
            state.Name = name;
            state.AttackUpperlimit = attackupperlimit;
            state.Attacklowerlimit = attacklowerlimit;
            state.DodgeRate = dodgerate;
            state.CritRate = critrate;
            return state;
        }
        public virtual State CreateValueState(int maxhp,StateType type, string name, int attackupperlimit, int attacklowerlimit, int dodgerate, int critrate)//触发条件 最大血量
        {
            State state = new State();
            state.type = type;
            state.Name = name;
            state.AttackUpperlimit = attackupperlimit;
            state.Attacklowerlimit = attacklowerlimit;
            state.DodgeRate = dodgerate;
            state.CritRate = critrate;
            return state;
        }
        //有触发条件的状态和没有触发条件的状态用函数重载区分 当前触发条件为最大血量的百分比
        public virtual State CreateHPState(  StateType type,string name,int hpovertime )
        {
            State state = new State();
            state.type = type;
            state.Name = name;
            state.HPOverTime = hpovertime;
            return state;
        }
        public virtual State CreateHPState(int maxhp ,StateType type, string name, int hpovertime)//触发条件 最大血量
        {
            State state = new State();
            state.type = type;
            state.Name = name;
            state.HPOverTime = hpovertime;
            return state;
        }

    }
    class 
}
