using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class State
    {
        /// <summary>
        ///  生效状态的委托
        /// </summary>
        /// <param name="cha"></param>
        public delegate void StateEffect(Character cha);
        /// <summary>
        /// 状态名字
        /// </summary>
        public string Name;
        /// <summary>
        /// 触发状态的技能名字
        /// </summary>
        public string SkillName;
        /// <summary>
        /// 状态类型 BUFF/DEBUFF
        /// </summary>
        public StateType StateType;
        /// <summary>
        /// 状态效果类型
        /// </summary>
        public StateEffectType stateEffectType;
        /// <summary>
        /// 状态的生效次数
        /// </summary>
        public int Times = 0;
        /// <summary>
        /// 状态的回合数
        /// </summary>
        public int Rounds = 0;

       
        /// <summary>
        /// 受到状态时每回合的伤害/治疗值
        /// </summary>
        public int DamageOverTime=0;
        /// <summary>
        /// 受到状态时每回合恢复/损失的体力值
        /// </summary>
        public int StaminaOverTime = 0;
        /// <summary>
        /// 受到状态影响时提升/降低的力量值
        /// </summary>
        public int StrengthChange = 0;
        /// <summary>
        /// 受到状态影响时提升/降低的敏捷值
        /// </summary>
        public int AgileChange = 0;
        /// <summary>
        /// 受到伤害加深或削弱的比率
        /// </summary>
        public double BeHitRate = 0;
        /// <summary>
        /// 攻击时伤害加深或者削弱的比率
        /// </summary>
        public double HitRate = 0;
        /// <summary>
        /// 添加第一次生效的状态时调用的方法
        /// </summary>
        public StateEffect AddState = null;
        /// <summary>
        /// 移除状态时调用的方法
        /// </summary>
        public StateEffect RemoveState = null;
    }
}
