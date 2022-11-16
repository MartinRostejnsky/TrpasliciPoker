using TrpasliciPoker;

Console.WriteLine("Hello, World!");

Round rnd = new Round(6);

foreach (string x in rnd.State())
{
    Console.WriteLine(x);
}