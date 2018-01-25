using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Manager
    {
        /// <summary>
        /// 所有角色的列表
        /// </summary>
        public List<Character> cha_list ;
        /// <summary>
        ///  选项的坐标位置
        /// </summary>
        public List<int> text_pos;
        /// <summary>
        /// 战斗信息的位置计数器
        /// </summary>
        public int []BattleInfo_Indext = {0};
        /// <summary>
        /// 战斗回合数
        /// </summary>
        int round ;
        public Manager()
        {
            cha_list = new List<Character>();
            text_pos = new List<int>();
            round = 1;
        }


        
    }
}
