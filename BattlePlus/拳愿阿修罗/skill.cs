﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Skill
    {
        /// <summary>
        /// 被动常驻技能的触发条件委托
        /// </summary>
        /// <param name="Attacter"></param>
        /// <param name="BeHiter"></param>
        /// <returns></returns>
        internal delegate bool SkillTrigger(Character Attacter, Character BeHiter);
        /// <summary>
        /// 技能附加状态的委托
        /// </summary>
        /// <param name="attacter">攻击者</param>
        /// <param name="BeHiter">被攻击者</param>
        internal delegate void SkillState(Character Attacter, Character BeHiter);
        /// <summary>
        /// 技能名字
        /// </summary>
        public string Name;
        /// <summary>
        /// 技能的信息,包含简略介绍,消耗HP/STA,攻击次数等等
        /// </summary>
        public string Info="略";
        /// <summary>
        /// 技能类型
        /// </summary>
        public SkillType Type;
        /// <summary>
        /// 技能消耗的生命值,卖血技能
        /// </summary>
        public int CostHP=0;
        /// <summary>
        /// 技能消耗的体力值;
        /// </summary>
        public int CostSTA=0;
        /// <summary>
        ///  技能的攻击次数;
        /// </summary>
        public int HitTimes=1;
        /// <summary>
        /// 技能的伤害系数
        /// </summary>
        public double DamageRate=1;
        /// <summary>
        /// 技能是否包含即死效果
        /// </summary>
        public bool DeathState=false;
        /// <summary>
        /// 即死概率
        /// </summary>
        public int DeathRate = 0;
        /// <summary>
        /// 必中效果
        /// </summary>
        public bool MustHit = false;
        /// <summary>
        /// 必定暴击效果
        /// </summary>
        public bool MustCrit = false;
        /// <summary>
        /// 状态的触发几率
        /// </summary>
        public int TriggerRate = 0;
        /// <summary>
        /// 技能附加状态
        /// </summary>
        public SkillState skillstate = null;
        /// <summary>
        /// 技能的伤害值计算,返回一个计算完毕后的伤害值
        /// </summary>
        public  int SkillDamage(Character attacter,Character behiter)
        {
            int damage = Convert.ToInt32(attacter.Damage(attacter.Strength) * DamageRate - behiter.DamageModifier(behiter.Frame));
            return damage > 0 ? damage : 1;
        }
        /// <summary>
        /// 创建被动常驻技能的时候调用的触发方法,返回一个布尔值,为true则触发,触发可以是增益或减益状态或直接反击伤害之类
        /// </summary>
        public SkillTrigger skilltrigger = null;

        /// <summary>
        ///  判断角色是否能使用技能
        /// </summary>
        /// <param name="cha">使用者</param>
        /// <returns></returns>
        public bool CanUseSkill(Character cha)
        {
            if(cha.HP<=CostHP||cha.STA<=CostSTA)
            {
                return false;
            }
            return true;
        }
   

        public void UseSkill(Character attacker,Character behiter,int[] index)
        {
            if (Type==SkillType.Active)
            {
                
                attacker.HP -= CostHP;
                attacker.STA -= CostSTA; 
                for(int i=0;i<HitTimes;i++)
                {
                    int tempdamage;
                    if(behiter.IsHit()&&MustHit==false)
                    {
                        string text = string.Format("{0}躲闪开了",behiter.Name);
                        Draw.BattleInfo(text, index);
                        continue;
                    }
                    tempdamage = SkillDamage(attacker, behiter);
                    if (skillstate != null)
                    {
                        skillstate.Invoke(attacker, behiter);
                    }
                    tempdamage = attacker.GetIncreaseDamage(tempdamage, StateType.Buff);
                    tempdamage = behiter.GetIncreaseDamage(tempdamage, StateType.Debuff);
                    tempdamage = attacker.GetWeakenedDamage(tempdamage, StateType.Debuff);
                    tempdamage = behiter.GetWeakenedDamage(tempdamage, StateType.Buff);
                    if(attacker.IsCrit()||MustCrit==true)
                    {
                        string text = string.Format("{0}击中了要害",attacker.Name);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Draw.BattleInfo(text, index);
                        tempdamage = (int)(tempdamage * attacker.CriticalRatio(attacker.Strength));
                        behiter.GetDamage(tempdamage, index);
                    }                   
                }
            }
            if(Type==SkillType.Passive)
            {

            }
        }
                               
        

      

    }
}
