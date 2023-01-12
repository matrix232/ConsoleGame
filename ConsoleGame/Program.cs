using System;
using System.ComponentModel.DataAnnotations;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            char[,] map = {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'A', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', 'A', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', 'X', '#', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', 'X', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', '#', ' ', 'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            int userX = 6, userY = 6;
            char[] bag = new char[1];
            int userArmor = 0;
            float userHealth = 100;

            while (true)
            {
                Console.SetCursorPosition(0, 19);
                Console.Write($"Здоровье: {userHealth}");

                Console.SetCursorPosition(0, 20);
                Console.Write("Сумка: ");


                // Отрисовка элементов сумки
                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(0, 21);
                Console.Write($"Броня: {userArmor}");

                // Отрисовка Карты
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                // Показ персонажа
                Console.SetCursorPosition(userY, userX);
                Console.Write('@');

                // Обработка клавиш
                ConsoleKeyInfo charKey = Console.ReadKey();
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX-1,userY] != '#')
                        {
                            userX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userX+1,userY] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX,userY-1] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX,userY+1] != '#')
                        {
                            userY++;
                        }
                        break;

                }

                if (map[userX, userY] == 'X')
                {
                    map[userX, userY] = 'o';
                    // Расширение массива
                    char[] tempBag = new char[bag.Length + 1];
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 1] = 'X';
                    bag = tempBag;
                }

                if (map[userX, userY] == 'A')
                {
                    map[userX, userY] = ' ';
                    userArmor += 5;
                }
                Console.Clear();
            }
        }
    }
}