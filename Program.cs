using System;

class Program
{
    /* Huvudmetoden där programmet börjar köras */
    static void Main(string[] args)
    {
        /* Skapar en instans av Word-klassen för att hantera ord. Hämtar ett slumpmässigt tal */
        Word word = new Word();
        string randomWord = word.GetRandomWord();

        Console.Clear();
        Console.WriteLine("Slumpmässigt ord: " + randomWord);

        /* Skapar en instans av Game-klassen. Skickar in det slumpmässiga ordet. */
        Game game = new Game(randomWord);
        /* Startar spelet */
        game.Start();
    }
}