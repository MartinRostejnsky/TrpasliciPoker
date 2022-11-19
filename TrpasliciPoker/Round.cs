using System;
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
                _Dices.Add(new Dice(6));
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
                    result.Add(dice.Locked.ToString() + " ; " + dice.Value.ToString());
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

        public List<Dice> Dices
        {
            get { return _Dices; }
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

        public bool? Value(int p1, int p2, int[] p1v, int[] p2v)
        {
            bool? result = null;
            if (p1 > p2)
            {
                result = true;
            }
            else if (p1 < p2)
            {
                result = false;
            }
            else if (p1 == p2)
            {
                if (p1v.Sum() > p2v.Sum())
                {
                    result = true;
                }
                else if (p1v.Sum() < p2v.Sum())
                {
                    result = false;
                }
                else if (p1v.Sum() == p2v.Sum())
                {
                    int extra1;
                    int extra2;
                    do
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Dices.Add(new Dice(6));
                            Dices[Dices.Count() - 1].Roll();
                        }
                        extra1 = (Dices[Dices.Count() - 2].Value);
                        extra2 = (Dices[Dices.Count() - 1].Value);

                    } while (extra1 == extra2);

                    if (extra1 > extra2)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public int Rank(int[] Values)
        {
            int Rank = 0;
            foreach (int i in Values)
            {
                if (i == 2)
                {
                    Rank++;
                }
                if (i == 3)
                {
                    Rank = 3;
                }
                if (i == 4)
                {
                    Rank = 7;
                }
                if (i == 5)
                {
                    Rank = 8;
                }
            }

            if ((Values.Count(n => n == 1) == 5) && (Values[5] == 0))
            {
                {
                    Rank = 4;
                }
            }

            if ((Values.Count(n => n == 1) == 5) && (Values[0] == 0))
            {
                {
                    Rank = 5;
                }
            }

            if ((Values.Count(n => n == 2) == 1) && (Values.Count(n => n == 3) == 1))
            {
                Rank = 6;
            }
            return Rank;
        }
    }
}
