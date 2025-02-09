using System;
using System.Threading;

namespace StopWatchToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu(); // Calling the menu 
        }

        // Function that starts the application 
        static void Menu()
        {
            Console.Clear(); // Cleaning the terminal

            Console.WriteLine("Temporizador"); // Title
            Console.WriteLine("----------------------");

            // Asking to the person how much time she wants
            Console.WriteLine("Digite o quanto quer contar, em seguida digite se quer em minutos ou segundos");
            Console.WriteLine("Exemplo: 10s - 10 segundos");
            Console.WriteLine("Exemplo: 1M - 1 minuto");
            Console.WriteLine("");
            Console.WriteLine("Quanto deseja contar?");

            // Storing in a variable the value that the person insert
            string entrance = Console.ReadLine().ToLower(); // Transforming all the characters in 

            // Taking just the letter of the entrance
            char type = char.Parse(entrance.Substring(entrance.Length - 1, 1));

            // If the type is minute or second
            if (type == 's' || type == 'm')
            {
                // If the entrance is a number
                if (int.TryParse(entrance.Substring(0, entrance.Length - 1), out int time)) // Creating a variable 
                {
                    if (time > 0) // If the time is bigger than 0
                    {
                        // Multiplier to multiply the time in 60 if the type is in minutes
                        int multiplier = 1; // firts his value is 1

                        Console.Clear(); // Clean the terminal

                        // If the type is in minutes
                        if (type == 'm')
                        {
                            multiplier = 60; // Multiply the time

                            if (time > 1)
                                Console.WriteLine($"{time} minutos");
                            else
                                Console.WriteLine($"{time} minuto");
                        }
                        // If the type is in seconds
                        else if (type == 's')
                        {
                            if (time > 1)
                                Console.WriteLine($"{time} segundos");
                            else
                                Console.WriteLine($"{time} segundo");
                        }

                        // Pause the execution for 2 seconds
                        Thread.Sleep(2000);

                        // Call the function with the number 
                        Timer(time * multiplier);
                    }
                    else // If the time is not bigger than 0
                    {
                        Console.Clear(); // Clean the terminal
                        Console.WriteLine("Insira um número maior que zero");
                        Thread.Sleep(2000); // Pause the execution for 2 seconds
                        Menu(); // Call again the Menu
                    }
                }
                else // If the time is not a number
                {
                    Console.Clear(); // Clean the terminal
                    Console.WriteLine("Insira um número válido");
                    Thread.Sleep(2000); // Pause the execution for 2 seconds
                    Menu(); // Call again the Menu
                }
            }
            else // If the type is not seconds or minutes
            {
                Console.Clear(); // Clean the menu
                Console.WriteLine("Digite 's' para segundos e 'm' para minutos após o tempo desejado");
                Thread.Sleep(3000); // Pause the execution for 2 seconds
                Menu(); // Call again the Menu
            }
        }

        // Function that does the time count
        static void Timer(int time)
        {
            // Storing in a variable the parameter 
            int InicialTime = time + 1;

            // While the time is not 0
            while (InicialTime != 0)
            {
                Console.Clear(); // Clean the terminal
                InicialTime--; // Time count
                Console.WriteLine(InicialTime); // Shows on terminal
                Thread.Sleep(1000); // Pause the execution for 1 second
            }

            // Call the function that starts again the timer
            StartAgain(InicialTime);
        }

        // Function to start again the timer
        static void StartAgain(int time)
        {
            // If the time is equal to 0
            if (time == 0)
            {
                Console.Clear(); // Clear the terminal
                Console.WriteLine("Temporizador finalizado!");
                Thread.Sleep(2000); // Pause the execution for 2 seconds
                Menu(); // Call again the function that starts
            }
        }
    }
}