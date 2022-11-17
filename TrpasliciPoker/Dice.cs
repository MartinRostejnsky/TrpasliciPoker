using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrpasliciPoker
{
    internal class Dice
    {
        private int _Value;
        private int _Size;
        private bool _Locked = false;

        public Dice(int sides)
        {
            _Size = sides;
        }

        public bool Roll()
        {
            if (!_Locked)
            {
                _Value = Random.Shared.Next(1,_Size+1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Value
        {
            get { return _Value; }
        }

        public int Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public bool Locked
        {
            get { return _Locked; }
            set { _Locked = value; }
        }
    }
}
