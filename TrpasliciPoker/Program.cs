﻿using System.Diagnostics.Metrics;
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
                    Console.WriteLine(state[i] + "; #" + (i + 1));
                }
                Console.WriteLine("(Uzamčení ; Hodnota; Číslo kostky)");
                Console.WriteLine("Zvolte kostku kterou chcete uzamknout (0 pro ukončení tahu)");
                do
                {
                    choice = ReadInt();
                } while ((choice > 10) || (choice < 6) || (choice!=0));

                if (choice == 0)
                {
                    break;
                }
                games[gamecounter].Rounds[roundcounter].SwitchLock(games[gamecounter].Rounds[roundcounter].Dices[choice - 1]);


            } while (choice != 0);

            rollcounter++;

            Console.ReadLine();
        } //

        foreach (string x in games[gamecounter].Rounds[roundcounter].State())
        {
            Console.WriteLine(x);
        }


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