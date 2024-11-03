using System;

class Program
{
    /* Huvudmetoden där programmet börjar köras */
    static void Main(string[] args)
    {
        bool keepPlaying = true;
        while (keepPlaying)
        {
            /* Skapar en instans av Word-klassen för att hantera ord. Hämtar ett slumpmässigt tal */
            Word word = new Word();
            string randomWord = word.GetRandomWord();

            Console.Clear();
            /* Skapar en instans av Game-klassen. Skickar in det slumpmässiga ordet. */
            Game game = new Game(randomWord);
            game.Start();

            /* Fråga om spelaren vill spela igen */
            keepPlaying = game.AskToPlayAgain();
        }
        Console.WriteLine("Tack för att du spelade! Spelet skapat av Joakim");
    }
}