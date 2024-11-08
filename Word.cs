public class Word
{
    /* Lagrar ordet */
    private string[] words;

    /*Konstruktor som laddar in ord från fil. Public för att komma åt den*/
    public Word()
    {
        LoadWords();
    }

    /* Metod för att ladda ord från textfil */
    private void LoadWords()
    {
        /* Try / catch för att hantera felmeddelande */
        try
        {
            /* Läser raderna i textfilen, gör om alla ord till stora bokstäver */
            words = File.ReadAllLines("words.txt").Select(word => word.ToUpper()).ToArray();
        }
        /* Catch ifall filen inte går att läsa ut */
        catch (Exception error)
        {
            Console.WriteLine("Fel vid inladdning av ordfilen: " + error.Message);
            words = null;
        }
    }

    /* Randomisering av ord */
    public string GetRandomWord()
    {
        if (words == null || words.Length == 0)
        {
            Console.WriteLine("Kunde inte ladda ordlistan, kontrollera att filen existerar och innehåller data. Avslutar programmet.");
            Environment.Exit(1);
        }
        
        Random random = new Random();
        return words[random.Next(words.Length)];
    }

}