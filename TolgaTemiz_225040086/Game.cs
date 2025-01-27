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
        Console.WriteLine("Game Developer: Tolga Temiz");
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
            Console.WriteLine("Type the name of the location to travel there, 'inventory' to view your inventory, or type 'exit' to quit:");
            Console.WriteLine("Tip: Type 'inventory' to see the items you've collected.");

            string locationName = Console.ReadLine();
            if (locationName.ToLower() == "exit")
                break;
            else if (locationName.ToLower() == "inventory")
            {
                inventory.ShowInventory();
                Console.WriteLine("You can view your collected items here.");
                Console.WriteLine("Press any key to return to the map.");
                Console.ReadKey();
            }
            else
            {
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
}
