class Program 
{
    static void Main(string[] args)
    {
        /* Skapar en instans av klassen word. Returnerar ett slumpmässigt ord*/
        Word word = new Word();
        string randomWord = word.GetRandomWord();
        Console.WriteLine("Slumpmässigt ord: " + randomWord);
    }
}