﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrpasliciPoker
{
    internal class Round
    {
        private List<Dice> _Dices = new List<Dice>();

        public Round(int dices)
        {
            for (int i = 0; i < dices; i++)
            {
                _Dices.Add(new Dice());
            }
        }

        public int Total()
        {
            int result = 0;
            foreach (Dice dice in _Dices)
            {
                result += dice.Value;
            }
            return result;
        }

        public List<String> State()
        {
            List<string> result = new List<string>();
            foreach (Dice dice in _Dices)
            {
                try
                {
                    result.Add(dice.Locked.ToString() + " " + dice.Value.ToString());
                }
                catch
                {
                    result.Add("Hodnoty nelze určit");
                }
                
            }
            return result;
        }

        public void Roll()
        {
            foreach (Dice dice in _Dices)
            {
                dice.Roll();
            }
        }

        public void SetLock(Dice target, bool value)
        {
            target.Locked = value;
        }

        public void Lock(Dice target)
        {
            target.Locked = true;
        }

        public void Unlock(Dice target)
        {
            target.Locked = false;
        }

        public void SwitchLock(Dice target)
        {
            target.Locked = (!target.Locked);
        }
    }
}
