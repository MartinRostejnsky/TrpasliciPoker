using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrpasliciPoker
{
    internal class Game
    {
        private int _Player1Wins = 0;
        private int _Player2Wins = 0;
        private List<Round> _Rounds = new List<Round>();

        public void NewRound()
        {
            _Rounds.Add(new Round(10));
        }

        public List<Round> Rounds
        {
            get { return _Rounds; }
        }
        public void Player1Win()
        {
            _Player1Wins++;
        }

        public void Player2Win()
        {
            _Player2Wins++;
        }
    }
}
