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
        public int Strength;
        public int HP;
        public int MaxHP;
        public int DodgeRate;
        public int CritRate;

        public List<Skill> Skills = new List<Skill>();
        //public List<State> states = new List<State>();
        public Character(string name,int maxhp,int strength)
        {
            Name = name;
            MaxHP = maxhp;
            HP = maxhp;
            Strength = strength;
            DodgeRate = 10;
            CritRate = 10;
        }

        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }
        
        public void GetDamage(int strength)
        {
            
        }

        
    }
}
