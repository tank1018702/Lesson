using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Character
    {
        public string name;
        public int hp;
        public int attack;

        public Character(string _name, int _hp, int _attack)
        {
            name = _name;
            hp = _hp;
            attack = _attack;
        }

        public void CostHp(int atk)
        {
            hp -= atk;
            if (hp < 0) { hp = 0; }
        }

        public void BeHit(int atk)
        {
            CostHp(atk);
        }

        public bool IsDead()
        {
            return hp <= 0;
        }
    }
}
