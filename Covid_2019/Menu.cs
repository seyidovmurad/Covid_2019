using System;
namespace Menu
{
    public static class SelectingMenu
    {
        public static int choose(string[] items)
        {
            int size = items.Length;
            bool[] isChoosenLine = new bool[size];
            int index = 0;
            while (true)
            {
                Console.Clear();
                int j = 0;
                foreach (var item in items)
                {
                    Console.WriteLine("--------------------------");
                    if (isChoosenLine[j])
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(item);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    j++;
                }
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = size - 1;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == size)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return index;
                }
                for (int i = 0; i < size; i++)
                {
                    isChoosenLine[i] = false;
                }
                isChoosenLine[index] = true;

            }
        }

        public static int choose(string dontSelect, string[] items)
        {
            int size = items.Length;
            bool[] isChoosenLine = new bool[size];
            int index = 0;
            while (true)
            {
                Console.Clear();
                int j = 0;
                Console.WriteLine(dontSelect);
                foreach (var item in items)
                {
                    Console.WriteLine("--------------------------");
                    if (isChoosenLine[j])
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(item);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    j++;
                }
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = size - 1;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == size)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return index;
                }
                for (int i = 0; i < size; i++)
                {
                    isChoosenLine[i] = false;
                }
                isChoosenLine[index] = true;

            }
        }

        public static string chooseByString(string[] items)
        {
            int size = items.Length;
            bool[] isChoosenLine = new bool[size];
            int index = 0;
            while (true)
            {
                Console.Clear();
                int j = 0;
                foreach (var item in items)
                {
                    if (isChoosenLine[j])
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(item);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    j++;
                }
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = size - 1;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == size)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return items[index];
                }
                for (int i = 0; i < size; i++)
                {
                    isChoosenLine[i] = false;
                }
                isChoosenLine[index] = true;

            }
        }
    }
}
