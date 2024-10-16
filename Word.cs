public class Word
{
    /* Lagrar ordet */
    private string[] words;

    /*Konstruktor som laddar in ord från fil  */
    public Word()
    {
        LoadWords();
    }

    /* Metod för att ladda ord från textfil */
    private void LoadWords()
    {
        /* Try / catch för att hantera fel. */
        try
        {
            words = File.ReadAllLines("words.txt");
        }
        /* Catch ifall filen inte går att läsa ut */
        catch (Exception error)
        {
            Console.WriteLine("Fel vid inladdning av ordfilen: " + error.Message);
        }
    }

    /* Randomisering av ord */
    public string GetRandomWord()
    {
        Random random = new Random();
        return words[random.Next(words.Length)];
    }

}