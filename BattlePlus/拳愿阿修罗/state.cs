//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace 拳愿阿修罗
//{
//    enum StateType
//    {
//        buff,
//        debuff
//    }

//    class State
//    {
//        public string Name;
//        public StateType type;
//        public int Strength;
//        public int DodgeRate;
//        public int CritRate;
//        附加每回合伤害/治疗
//        public int HPOverTime;
//        被动BUFF触发条件


//        public static State CreateValueState(StateType type, string name, int strength, int dodgerate, int critrate)
//        {
//            State state = new State();
//            state.Name = name;
//            state.Strength = strength;
//            state.DodgeRate = dodgerate;
//            state.CritRate = critrate;


//            return state;
//        }

//        有触发条件的状态和没有触发条件的状态用函数重载区分 当前触发条件为最大血量的百分比
//        public static State CreateHPState(StateType type, string name, int hpovertime)
//        {
//            State state = new State();
//            state.type = type;
//            state.Name = name;
//            state.HPOverTime = hpovertime;
//            return state;
//        }


//    }
//    class TriggerState : State
//    {
//        public int MaxHpPersentage;

//        public override TriggerState CreateValueState(int maxhppersentage, StateType type, string name, int attackupperlimit, int attacklowerlimit, int dodgerate, int critrate)
//        {
//            TriggerState state = new TriggerState();
//            state.type = type;
//            state.Name = name;
//            state.AttackUpperlimit = attackupperlimit;
//            state.Attacklowerlimit = attacklowerlimit;
//            state.DodgeRate = dodgerate;
//            state.CritRate = critrate;
//            state.MaxHpPersentage = maxhppersentage;
//            return state;
//        }
//        public override State CreateHPState(int maxhp, StateType type, string name, int hpovertime)//触发条件 最大血量
//        {
//            State state = new State();
//            state.type = type;
//            state.Name = name;
//            state.HPOverTime = hpovertime;
//            return state;
//        }
//    }
//}
