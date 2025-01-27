// Game.cs
using System;

class Game
{
    private Map map;
    private Inventory inventory;

    public Game()
    {
        map = new Map();
        inventory = new Inventory();
    }

    public void Start()
    {
        ShowMenu();
    }

    private void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Main Menu ---");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Play();
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowCredits()
    {
        Console.Clear();
        Console.WriteLine("--- Credits ---");
        Console.WriteLine("Game Developer: Your Name");
        Console.WriteLine("Assets: Open Source Resources");
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    private void Play()
    {
        while (true)
        {
            Console.Clear();
            map.DisplayMap();
            Console.WriteLine("Type the name of the location to travel there, or type 'exit' to quit:");

            string locationName = Console.ReadLine();
            if (locationName.ToLower() == "exit")
                break;

            Location location = map.GetLocation(locationName);
            if (location != null)
            {
                location.Enter(inventory);
            }
            else
            {
                Console.WriteLine("Invalid location. Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
