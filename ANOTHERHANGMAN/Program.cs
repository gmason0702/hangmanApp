using System;
using System.IO;
using System.Reflection;

namespace ANOTHERHANGMAN
{
    class Program
    {
        static void Main(string[] args)
        {
            string hangmanheader = System.IO.File.ReadAllText("../../Assets/HangmanHeader.txt");
            //string hangmanheader = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Assets\HangmanHeader.txt");
            //string[] files = File.ReadAllLines(hangmanheader);
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine($"{hangmanheader}\n" +
                        "1.) Begin Game\n" +
                        "2.) Exit");
                string userInput = Console.ReadLine();
                // userInput = userInput.Replace(" ", "");

                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        runHangman();
                        break;
                    case "2":
                        continueToRun = false;
                        break;
                }
            }
            void runHangman()
            {
                string[] hangMan = {
                    @"../../Assets/Zerostrikes.txt",
                    @"../../Assets/OneStrike.txt",
                    @"../../Assets/Twostrikes.txt",
                    @"../../Assets/ThreeStrikes.txt",
                    @"../../Assets/FourStrikes.txt",
                    @"../../Assets/FiveStrikes.txt",
                    @"../../Assets/SixStrikes.txt" };

                string[] listwords = new string[15];
                listwords[0] = "pizza";
                listwords[1] = "billygoat";
                listwords[2] = "computer";
                listwords[3] = "america";
                listwords[4] = "rose";
                listwords[5] = "pudding";
                listwords[6] = "console";
                listwords[7] = "pineapple";
                listwords[8] = "hamburger";
                listwords[9] = "mango";
                listwords[10] = "steaks";
                listwords[11] = "chief";
                listwords[12] = "almond";
                listwords[13] = "burrito";
                listwords[14] = "poster";

                Random randGen = new Random();
                var index = randGen.Next(0, 14);
                int win = 0;
                int hang = 0;
                string wrong = "";
                int life = 6;
                string mysteryWord = listwords[index];
                char[] guess = new char[mysteryWord.Length];
             
                Console.Write("Guess a letter and seal your fate!\n");


                for (int p = 0; p < mysteryWord.Length; p++)
                    guess[p] = '_';

                while (true)
                {
                    char playerGuess;
                    int count = 0;
                    try
                    {
                        playerGuess = char.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException )
                    {
                        Console.WriteLine("Please only enter one letter!");
                        continue;
                    }
                   
                    Console.Clear();

                    //char playerGuess = char.Parse(Console.ReadLine());

                    for (int j = 0; j < mysteryWord.Length; j++)
                    {
                        if (playerGuess == mysteryWord[j])
                        {
                            guess[j] = playerGuess;
                            win++;
                        }
                        else if (playerGuess == ' ')
                        {
                            continue;
                        }
                        else
                        {
                            count++;
                        }
                        if (count == mysteryWord.Length)
                        {
                            wrong += playerGuess + ", ";
                            life--;
                            hang++;
                        }
                    }
                    switch (hang)
                    {
                        case 0:
                            Console.WriteLine(System.IO.File.ReadAllText(hangMan[0]));
                            break;
                        case 1:
                            Console.WriteLine(System.IO.File.ReadAllText(hangMan[1]));
                            break;
                        case 2:
                            Console.WriteLine(System.IO.File.ReadAllText(hangMan[2]));
                            break;
                        case 3:
                            Console.WriteLine(System.IO.File.ReadAllText(hangMan[3]));
                            break;
                        case 4:
                            Console.WriteLine(System.IO.File.ReadAllText(hangMan[4]));
                            break;
                        case 5:
                            Console.WriteLine(System.IO.File.ReadAllText(hangMan[5]));
                            break;
                        case 6:
                            Console.WriteLine(System.IO.File.ReadAllText(hangMan[6]));
                            break;
                        default:
                            break;
                    }

                    //Console.Write(word_track);
                    Console.ForegroundColor
                    = ConsoleColor.Red;
                    Console.WriteLine("\n\n\t\tWrong letter: ({0})\n\t\tYou have {1} lives left", wrong, life);
                    //Console.WriteLine(hangMan[hang]);
                    Console.WriteLine(guess);
                    if (win == mysteryWord.Length)
                    {
                        Console.WriteLine("Congratulations, you have survived a gruesome death!");
                        break;
                    }
                    else if (life == 0)
                    {
                        Console.WriteLine("Hang in there buddy...jk you ded");
                        break;
                    }
                }
            }
        }
    }

}
