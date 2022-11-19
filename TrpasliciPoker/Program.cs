using System.Diagnostics.Metrics;
using TrpasliciPoker;

List<Game> games = new List<Game>();
int gamecounter = 0;
int roundcounter;
int rollcounter;
int choice;

while (true)
{
    games.Add(new Game());
    roundcounter = 0;
    while (!((games[gamecounter].Player1Wins > 1) || (games[gamecounter].Player2Wins > 1)))
    {
        games[gamecounter].NewRound();
        rollcounter = 0;
        while (rollcounter < 2)
        {
            games[gamecounter].Rounds[roundcounter].Roll();
            Console.WriteLine("Hraje hráč č.1");
            
            do
            {
                List<String> state = games[gamecounter].Rounds[roundcounter].State();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(state[i] + "; #" + (i + 1));
                }
                Console.WriteLine("(Uzamčení ; Hodnota; Číslo kostky)");
                Console.WriteLine("Zvolte kostku kterou chcete uzamknout (0 pro ukončení tahu)");
                do
                {
                    choice = ReadInt();
                } while ((choice > 5) || (choice < 0));

                if (choice == 0)
                {
                    break;
                }

                games[gamecounter].Rounds[roundcounter].SwitchLock(games[gamecounter].Rounds[roundcounter].Dices[choice - 1]);


            } while (choice != 0);
            Console.WriteLine();

            Console.WriteLine("Hraje hráč č.2");

            do
            {
                List<String> state = games[gamecounter].Rounds[roundcounter].State();
                for (int i = 5; i < 10; i++)
                {
                    Console.WriteLine(state[i] + "; #" + (i - 4));
                }
                Console.WriteLine("(Uzamčení ; Hodnota; Číslo kostky)");
                Console.WriteLine("Zvolte kostku kterou chcete uzamknout (0 pro ukončení tahu)");
                do
                {
                    choice = ReadInt();
                } while ((choice > 5) || (choice < 0));

                if (choice == 0)
                {
                    break;
                }

                games[gamecounter].Rounds[roundcounter].SwitchLock(games[gamecounter].Rounds[roundcounter].Dices[choice + 4]);


            } while (choice != 0);
            Console.WriteLine();

            rollcounter++;
        } //

        int[] Player1Values = new int[games[gamecounter].Rounds[roundcounter].Dices[0].Size];
        int[] Player2Values = (int[])Player1Values.Clone();

        for (int i = 0; i < 5; i++)
        {
            Player1Values[games[gamecounter].Rounds[roundcounter].Dices[i].Value-1]++; 
        }

        for (int i = 5; i < 10; i++)
        {
            Player2Values[games[gamecounter].Rounds[roundcounter].Dices[i].Value-1]++;
        }

        int Player1Ranking = games[gamecounter].Rounds[roundcounter].Rank(Player1Values);
        int Player2Ranking = games[gamecounter].Rounds[roundcounter].Rank(Player2Values);

        if (games[gamecounter].Rounds[roundcounter].Value(Player1Ranking, Player2Ranking, Player1Values, Player2Values) == true)
        {
            Console.WriteLine("Kolo vyhrává hráč č.1");
            games[gamecounter].Player1Win();
        }
        else
        {
            games[gamecounter].Player2Win();
            Console.WriteLine("Kolo vyhrává hráč č.2");
        } 

        roundcounter++;
    }
    if (games[gamecounter].Player1Wins == 2)
    {
        Console.WriteLine("Hru vyhrává hráč č.1");
    }
    else
    {
        Console.WriteLine("Hru vyhrává hráč č.2");
    }
    
    Console.WriteLine("Stiskni enter pro spuštění další hry");
    Console.ReadLine();
    gamecounter++;
}

static int ReadInt()
{
    int cislo;
    while (!int.TryParse(Console.ReadLine(), out cislo))
        {
            Console.WriteLine("Neplatný vstup, zadej číslo!");
        }
    return cislo;

}