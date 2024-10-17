public class Game
{
    /* Definierar variabler. */
    private string wordToGuess;
    private List<char> guessedLetter;
    private int remainingAttempts;

    /* Konstruktor som initierar spelet med ett ord */
    public Game(string word)
    {
        wordToGuess = word;
        guessedLetter = new List<char>();
        remainingAttempts = 12;
    }

    /* Metod för att starta spelet */
    public void Start()
    {
        Console.WriteLine("Välkommen till Hänga Gubbe!");

        /* Loop för att hålla spelet igång tills användaren vinner/förlorar */
        while (!IsGameOver())
        {
            /* Kör displayWord för att visa antal bokstäver */
            Console.Clear();
            DisplayWord();
            Console.Write("Gissa en bokstav: ");
            char guess = char.ToUpper(Console.ReadKey().KeyChar); 
            Console.WriteLine();

            /* Anropar metod med guess som argument */
            MakeGuess(guess);
        }

        /* Kontroll för att meddela om användaren gissat rätt eller fel bokstav */
        if (IsWordGuessed())
        {
            /* Vinstmeddelande */
            Console.Clear();
            Console.WriteLine("Grattis! Du gissade ordet: " + wordToGuess);
        }
        else
        {
            /* Förlustmeddelande */
            Console.WriteLine("Tyvärr, du förlorade. Ordet var: " + wordToGuess);
        }
    }

    /* Metod för att visa ordet med gissade bokstäver */
    private void DisplayWord()
    {
        /* Går igenom varje bokstav i ordet, om bokstaven gissas så lägger den till bokstaven i strängen. Annars så lägger den till ett understreck */
        string displayWord = "";
        foreach (char letter in wordToGuess)
        {
            if (guessedLetter.Contains(letter))
            {
                displayWord += letter + " ";
            }
            else
            {
                displayWord += "_ ";
            }
        }
        /* Visar gissade bokstäver samt visar kvarvarande försök */
        Console.WriteLine("Ord: " + displayWord);
        Console.WriteLine("Gissade bokstäver: " + string.Join(",", guessedLetter));
        Console.WriteLine("Kvarvarande försök: " + remainingAttempts);
    }

    /* Metod för att hantera en gissning av en bokstav.  */
    public void MakeGuess(char letter)
    {
        /* Kontrollera ifall bokstaven inte har blivit gissad innan */
        if (!guessedLetter.Contains(letter))
        {
            /* Lägg till bokstav i lista */
            guessedLetter.Add(letter);

            /* Om bokstaven inte finns i ordet så minskar antalet kvarvarande försök */
            if (!wordToGuess.Contains(letter))
            {
                remainingAttempts--;
                Console.WriteLine("Fel gissning!");
            }
            else 
            {
                /* Meddelar spelaren att det är en bra gissning */
                Console.WriteLine("Bra gissning!"); 
            }
        }
        else 
        {
            /* Meddelar ifall bokstaven redan har blivit gissad */
            Console.WriteLine("Du har redan gissat på den bokstaven!");
            Console.ReadKey();
        }
    }

    /* Håller spelet igång tills användaren gissar rätt ord eller får slut på gissningsförsök */
    public bool IsGameOver()
    {
        return remainingAttempts <= 0 || IsWordGuessed();
    }

    /* Kontroll för att se ifall ordet har blivit gissat */
    private bool IsWordGuessed()
    {
        foreach (char letter in wordToGuess)
        {
            if (!guessedLetter.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }
}