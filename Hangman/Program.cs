using System;
using System.Text;
namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfGuesses = 10;
            string[] Words = { "hund", "gryta", "segelbåt" };
            Random Rand = new Random();
            string Word = Words[Rand.Next(Words.Length)];
            string Guess;
            StringBuilder WrongGuesses = new StringBuilder("", 10);
            char[] RightGuesses = new char[Word.Length];
            bool finished;

            for(int i = 0; i < RightGuesses.Length; i++)
            {
                RightGuesses[i] = '_';
            }

            while (NumberOfGuesses > 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Ditt resultat hittills: ");
                foreach (char c in RightGuesses)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Gissa en bokstav eller gissa hela ordet. Du har " + NumberOfGuesses + " gissnignar kvar.");
                Console.WriteLine("Du har hittils gissat fel på följande bokstäver: " + WrongGuesses.ToString());
               
                Guess = Console.ReadLine();
                try
                {
                    if (Guess.Equals(Word))
                    {
                        Console.WriteLine("Grattis! Du gissade rätt ord.");
                        Console.WriteLine("Du förbrukade " + (10 - NumberOfGuesses) + " felaktiga gissningar.");
                        break;
                    }
                    else if (Guess.Length > 1)  // Spelaren gissar på hela ordet men gissar fel
                    {
                        NumberOfGuesses--;
                        Console.WriteLine("Du gissde på fel ord!");
                    }
                    else if (IsInWord(Guess, Word))
                    {
                        Console.WriteLine("Du gissde rätt bokstav!");
                        for (int i = 0; i < RightGuesses.Length; i++)
                        {
                            if (Word[i] == Guess.ToCharArray()[0])
                            {
                                RightGuesses[i] = Guess.ToCharArray()[0];
                            }
                        }
                    }
                    else
                    {
                        if (WrongGuesses.ToString().Contains(Guess))
                        {
                            Console.WriteLine("Den har du gissat på förut.");
                        }
                        else
                        {
                            NumberOfGuesses--;
                            WrongGuesses.Append(Guess);
                        }
                    }

                    //Om man gissat alla bokstäver vill jag att man inte skall behöva gissa en gång till på hela ordet för att vinna.
                    //Om det inte finns några '_' kvar i RightGuesses har man vunnit.
                    finished = true;
                    foreach (char c in RightGuesses)
                    {
                        if (c == '_')
                        {
                            finished = false;
                        }
                    }
                    if (finished)
                    {
                        Console.WriteLine("Grattis! Du har gissat hela ordet.");
                        Console.WriteLine("Du förbrukade " + (10 - NumberOfGuesses) + " felaktiga gissningar.");
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Nu har du gjort något fel, tex kan det vara så att du inte maat in något alls.");
                }
            }

            
        }

        public static bool IsInWord(string Guess, string Word)
        {
            foreach (char c in Word)
            {
                if (Guess.ToCharArray()[0] == c)
                {
                    Console.WriteLine("True!");

                    return true;
                }
            }
            return false;
        }
    }
}
