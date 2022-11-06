using System;
using System.Collections.Generic;
using System.IO;

namespace bninamango
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro();
            Instructions();

            char[] code = new char[]
            {
                'C','M','Y','K'
            };

            List<Ball> secret_code = Randomize(code);

            //Print(secret_code);

            int attemps = 7;

            bool isGameOver = false;

            while (!isGameOver)
            {
                char[] input_code = Console.ReadLine().ToCharArray();

                List<Ball> secretAux = new List<Ball>(secret_code);
                List<char> resultAux = new List<char>();

                for (int i = 0; i < input_code.Length; i++)
                {
                    char inputAux = char.ToUpper(input_code[i]);

                    char result = '-';

                    for (int j = 0; j < secretAux.Count; j++)
                    {
                        Ball ballAux = secretAux[j];

                        if (inputAux == ballAux.Character)
                        {
                            result = (i == ballAux.Index) ? 'O' : 'X';

                            secretAux.Remove(ballAux);

                            break;
                        }
                    }
                    resultAux.Add(result);
                }

                OrderResult(resultAux);

                attemps--;

                Console.WriteLine();

                isGameOver = (CheckResult(resultAux)) || (attemps <= 0);
            }

            Finish();

            bool CheckResult(List<char> results)
            {
                int count = 0;

                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i] == 'O')
                    {
                        count++;
                    }
                }

                return (count >= results.Count);
            }

            char[] OrderResult(List<char> results)
            {
                List<char> resultAux = new List<char>();

                List<char> first = new List<char>();
                List<char> second = new List<char>();
                List<char> third = new List<char>();

                for (int i = 0; i < results.Count; i++)
                {
                    switch (results[i])
                    {
                        case 'O':

                            first.Add(results[i]);

                            break;

                        case 'X':

                            second.Add(results[i]);

                            break;

                        case '-':

                            third.Add(results[i]);

                            break;
                    }
                }

                resultAux.AddRange(first);
                resultAux.AddRange(second);
                resultAux.AddRange(third);

                for (int i = 0; i < resultAux.Count; i++)
                {
                    Console.Write(resultAux[i]);
                }

                return resultAux.ToArray();
            }

            void Print(List<Ball> balls)
            {
                for (int i = 0; i < balls.Count; i++)
                {
                    Console.Write(balls[i].Character);
                }
                Console.WriteLine();
            }


            List<Ball> Randomize(char[] characters)
            {
                List<Ball> aux = new List<Ball>();

                for (int i = 0; i < characters.Length; i++)
                {
                    Ball ball = new Ball(characters[i], i);

                    aux.Add(ball);
                }

                return aux;
            }

            void Intro()
            {
                string[] lines = File.ReadAllLines("Title.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.WriteLine();

                Console.ReadKey();

                Console.Clear();
            }

            void Instructions()
            {
                Console.WriteLine("Instructions");
                Console.WriteLine("Try in 7 atemps to discover the secret code");
                Console.WriteLine("C M Y K is the code");
                Console.WriteLine("O : Correct letter and position");
                Console.WriteLine("X : Correct letter but not the position");
                Console.WriteLine("- : Letter and position incorrect");

                Console.WriteLine("Press any key to continue");

                Console.ReadKey();

                Console.Clear();
            }

            void Finish()
            {
                string[] lines = File.ReadAllLines("Finish.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
            }
        }
    }
}
