using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 拳愿阿修罗
{
    class Character
    {
        public string Name;
        public int AttackUpperlimit;
        public int Attacklowerlimit;
        public int HP;
        public int MaxHP;
        public int DodgeRate;
        public int CritRate;
        public int SkillTriggerRate;

        public List<Skill> Skills = new List<Skill>();
        public List<State> states = new List<State>();
        public Character(string name,int maxhp,int attacklowerlimit, int attackUpperlimit)
        {
            Name = name;
            MaxHP = maxhp;
            Attacklowerlimit = attacklowerlimit;
            AttackUpperlimit = attackUpperlimit;
            DodgeRate = 10;
            CritRate = 10;
            SkillTriggerRate = 20;

        }


        


        
    }
}
