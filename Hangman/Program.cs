using System.Text;

namespace Hangman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            var word = GetWord().ToUpper();
            StringBuilder felaktigaGissningar = new StringBuilder();
            var correctLetters = GetCryptedWord(word);
            int turn = 10;

            while (running)
            {
                Rita(felaktigaGissningar, correctLetters, turn);
                string guess = Console.ReadLine().ToUpper();
                if (guess.Length != 0)
                {
                    //Om gissningen var fel
                    if (!word.Contains(guess))
                    {

                        if (!felaktigaGissningar.ToString().Contains(guess))
                        {
                            if (guess.Length == 1)
                            {
                                felaktigaGissningar.Append(guess + " ");
                            }
                            if (guess == "COLOR")
                                GetNewTextColor();
                            turn--;
                        }
                    }
                    //Om en bokstav eller hela ordet stämde
                    else
                    {
                        //Om man gissade för hela ordet
                        if (guess.Length > 1)
                        {
                            if (guess == word)
                            {
                                for (int i = 0; i < correctLetters.Length; i++)
                                {
                                    correctLetters[i] = word[i];
                                }
                            }
                        }
                        //Om en bokstav var korrekt
                        else
                        {
                            for (var ii = 0; ii < word.Length; ii++)
                            {
                                if (word[ii] == guess[0])
                                {
                                    correctLetters[ii] = guess[0];
                                }
                            }
                        }
                    }
                }
                //Avslutar om användaren får rätt svar eller 'turn' når 0 
                running = false;
                for (int ii = 0; ii < word.Length; ii++)
                {
                    if (correctLetters[ii] != word[ii])
                        running = true;
                }

                if (turn == 0)
                {
                    running = false;
                }
            }

            Rita(felaktigaGissningar, correctLetters, turn);

            Console.WriteLine("Rätt ord: " + word);
        }

        //metod som anropas för att rita upp grafiken
        private static void Rita(StringBuilder felaktigaGissningar, char[] correctLetters, int turn)
        {
            System.Console.Clear();
            GubbRitare(turn);
            Console.WriteLine($"Gissningar: " + felaktigaGissningar);
            foreach (var c in correctLetters)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine("");
        }

        private static void GubbRitare(int turn)
        {
            //rad 1
            if (turn > 7)
                Console.WriteLine("********");
            else
                Console.WriteLine("*____***");
            //rad 2
            if (turn == 8 || turn == 7)
                Console.WriteLine("*|******");
            else if (turn > 8)
            {
                Console.WriteLine("********");
            }
            else if (turn == 6)
                Console.WriteLine("*|/*****");
            else
                Console.WriteLine("*|/*|***");
            //rad 3
            if (turn < 9 && turn > 4)
                Console.WriteLine("*|******");
            else if (turn < 9 && turn != 0)
                Console.WriteLine("*|**0***");
            else if (turn == 0)
                Console.WriteLine("*|**0*:(");
            else
                Console.WriteLine("********");
            //rad 4
            if (turn > 8)
                Console.WriteLine("********");
            else if (turn < 9 && turn > 3)
                Console.WriteLine("*|******");
            else if (turn == 3)
                Console.WriteLine("*|**|***");
            else
                Console.WriteLine("*|*/|\\**");
            //rad 5
            if (turn > 8)
                Console.WriteLine("********");
            else if (turn > 1)
                Console.WriteLine("*|******");
            else
                Console.WriteLine("*|*/*\\**");
            //rad 6
            if (turn > 8)
                Console.WriteLine("********");
            else
                Console.WriteLine("*|******");
            //rad 7
            if (turn == 10)
                Console.WriteLine("******10");
            else
                Console.WriteLine("///\\\\\\0" + turn);

        }

        //översätter det hemliga ordet till en hemlig rad 
        private static char[] GetCryptedWord(string word)
        {
            char[] correctLetters = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                correctLetters[i] = '_';
                if (word[i] == ' ')
                {
                    correctLetters[i] = ' ';
                }
            }

            return correctLetters;
        }

        //Slumpar fram ett ord/mening från högskoleprovet
        public static string GetWord()
        {
            string[] words = new string[] {
             "proviant", "reflektera", "foajé","sekundär","inrådan","hålla låda","hänförd","premiss","naturtroget","hedonist",
            "vital","späck","alternera","falang","modstulet","prolog","emanciperad","spjuver","freda sig","bestörtning",
                "Yxmördaren Julia Blomqvist på fäktning i Schweiz"};

            Random rnd = new Random();
            int wordIndex = rnd.Next(1, words.Length);

            return words[wordIndex];

        }
        public static void GetNewTextColor()
        {
            Random r = new Random();
            var dice = r.Next(1, 7);
            if (dice == 1)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (dice == 2)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (dice == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (dice == 4)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (dice == 5)
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (dice == 6)
                Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}