public class Game
{
    /* Definierar variabler. */
    private string wordToGuess;
    private List<char> guessedLetters;
    private int remainingAttempts;

    /* Konstruktor som initierar spelet med ett ord */
    public Game(string word)
    {
        wordToGuess = word;
        guessedLetters = new List<char>();
        remainingAttempts = 7;
    }

    /* Metod för att starta spelet */
    public void Start()
    {
        Console.WriteLine("Välkommen till Hänga Gubbe!");

        /* Loop för att hålla konsolen igång */
        while (!IsGameOver())
        {
            /* Startar spelet och visar hänga gubben samt ordet. Skickar bokstav som argument till MakeGuess*/
            Console.Clear();
            DrawHangman();
            DisplayWord();
            Console.Write("Gissa en bokstav: ");
            char guess = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            MakeGuess(guess);
        }

        if (IsWordGuessed())
        {
            Console.Clear();
            DrawHangman();
            Console.WriteLine("Grattis! Du gissade ordet: " + wordToGuess);
            Console.WriteLine($"Du hade {remainingAttempts} försök kvar!");
        }
        else
        {
            Console.Clear();
            DrawHangman();
            Console.WriteLine("Tyvärr, du förlorade. Ordet var: " + wordToGuess);
            Console.WriteLine("Du har inga försök kvar.");
        }
    }
    /* Fråga om användaren vill spela igen */
    public bool AskToPlayAgain()
    {
        /* Loop för få "ja" eller "nej" av användaren. */
        while (true)
        {
            Console.Write("Vill du spela igen? (ja/nej): ");
            string response = Console.ReadLine().Trim().ToLower();

            /* Returnerar true till Program.cs */
            if (response == "ja")
            {
                return true;
            }
            /* Returnerar false till Program.cs */
            else if (response == "nej")
            {
                return false;
            }
            /* Ifall användaren skriver inte skriver "ja" eller "nej", be dem försöka igen */
            else
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt svar. Svara med 'ja' eller 'nej'.");
            }
        }
    }

    /* Visuell hänga gubbe */
    private void DrawHangman()
    {
        /* Switch för att visa rätt hänga gubbe beroende på hur många försök användaren har kvar.*/
        switch (remainingAttempts)
        {
            case 7:
                Console.WriteLine("  +---+");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("     ===");
                break;
            case 6:
                Console.WriteLine("  +---+");
                Console.WriteLine("  O   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("     ===");
                break;
            case 5:
                Console.WriteLine("  +---+");
                Console.WriteLine("  O   |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("     ===");
                break;
            case 4:
                Console.WriteLine("  +---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|   |");
                Console.WriteLine("      |");
                Console.WriteLine("     ===");
                break;
            case 3:
                Console.WriteLine("  +---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine("      |");
                Console.WriteLine("     ===");
                break;
            case 2:
                Console.WriteLine("  +---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" /    |");
                Console.WriteLine("     ===");
                break;
            case 1:
                Console.WriteLine("  +---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" / \\  |");
                Console.WriteLine("     ===");
                break;
            default:
                Console.WriteLine("  +---+");
                Console.WriteLine("  X   |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" / \\  |");
                Console.WriteLine("     ===");
                break;
        }
    }

    /* Metod för att visa ordet med gissade bokstäver */
    private void DisplayWord()
    {
        /* Går igenom varje bokstav i ordet, om bokstaven gissas så lägger den till bokstaven i strängen. Annars så lägger den till ett understreck */
        string displayWord = "";
        foreach (char letter in wordToGuess)
        {
            if (guessedLetters.Contains(letter))
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
        Console.WriteLine("Gissade bokstäver: " + string.Join(",", guessedLetters));
        Console.WriteLine($"Du har {remainingAttempts} försök kvar innan gubben är hängd!");
    }

    /* Metod för att hantera en gissning av en bokstav.  */
    public void MakeGuess(char letter)
    {
        /* Kontrollera ifall bokstaven inte har blivit gissad innan */
        if (!guessedLetters.Contains(letter))
        {
            /* Lägg till bokstav i lista */
            guessedLetters.Add(letter);

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
            if (!guessedLetters.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }
}