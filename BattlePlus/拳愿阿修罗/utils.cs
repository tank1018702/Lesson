using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Utils
    {
        public static Random random = new Random();
    }
    /// <summary>
    /// 技能类型,主动和被动
    /// </summary>
    public enum SkillType
    {
        /// <summary>
        /// 主动技能类型
        /// </summary>
        Active,
        /// <summary>
        /// 被动技能类型
        /// </summary>
        Passive
    }
    public enum ActiveSkillType
    {

    }
    /// <summary>
    /// 角色类型
    /// </summary>
    public enum CharaType
    {
        /// <summary>
        /// 玩家
        /// </summary>
        Player,
        /// <summary>
        /// 电脑
        /// </summary>
        Computer
    }

    /// <summary>
    /// 状态的类型
    /// </summary>
    enum StateType
    {
        /// <summary>
        /// 增益状态
        /// </summary>
        Buff,
        /// <summary>
        /// 减益状态
        /// </summary>
        Debuff,
        /// <summary>
        /// 常驻状态,多由被动技能附带
        /// </summary>
        PermanentState
    }

}
