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
    while (roundcounter < 2)
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

        int Player1Ranking = 0;
        int Player2Ranking = 0;

        foreach (int i in Player1Values)
        {
            if (i == 2)
            {
                Player1Ranking++;
            }
            if (i == 3)
            {
                Player1Ranking = 3;
            }
            if (i == 4)
            {
                Player1Ranking = 7;
            }
            if (i == 5)
            {
                Player1Ranking = 8;
            }
        }

        if ((Player1Values.Count(n => n == 1) == 5) && (Player1Values[5] == 0))
        {
            {
                Player1Ranking = 4;
            }
        }

        if ((Player1Values.Count(n => n == 1) == 5) && (Player1Values[0] == 0))
        {
            {
                Player1Ranking = 5;
            }
        }

        if ((Player1Values.Count(n => n == 2) == 1) && (Player1Values.Count(n => n == 3) == 1))
        {
            Player1Ranking = 6;
        }

        foreach (int i in Player2Values)
        {
            if (i == 2)
            {
                Player2Ranking++;
            }
            if (i == 3)
            {
                Player2Ranking = 3;
            }
            if (i == 4)
            {
                Player2Ranking = 7;
            }
            if (i == 5)
            {
                Player2Ranking = 8;
            }
        }

        if ((Player2Values.Count(n => n == 1) == 5) && (Player2Values[5] == 0))
        {
            {
                Player2Ranking = 4;
            }
        }

        if ((Player2Values.Count(n => n == 1) == 5) && (Player2Values[0]==0))
        {
            {
                Player2Ranking = 5;
            }
        }

        if ((Player2Values.Count(n => n == 2) == 1) && (Player2Values.Count(n => n == 3) == 1))
        {
            Player2Ranking = 6;
        }

        Console.WriteLine(Player1Ranking); //Player1Ranking = Skore hrace c.2 a naopak
        Console.WriteLine(Player2Ranking); //Obracena logika v prumyslu ig, nevim proc to tak funguje ale kdyz to funguje tak na to nebudu sahat

        roundcounter++;
    }
    
    Console.WriteLine("Stiskni libovolnou klávesu pro spuštění další hry");
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