using System;
using System.IO;
using System.Text.Json;

class Game
{
    private Map map;
    private Inventory inventory;
    private string currentLocation;

    private const string SaveFilePath = "savegame.json";

    public Game()
    {
        map = new Map();
        inventory = new Inventory();
        currentLocation = "Village"; // Başlangıç konumu
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
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Credits");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Play();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "3":
                    ShowCredits();
                    break;
                case "4":
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
            Console.WriteLine("Type the name of the location to travel there, 'inventory' to view your items, 'save' to save the game, or 'exit' to return to the menu:");

            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;
            else if (input.ToLower() == "inventory")
                inventory.ShowInventory();
            else if (input.ToLower() == "save")
                SaveGame();
            else
            {
                Location location = map.GetLocation(input);
                if (location != null)
                {
                    currentLocation = location.Name;
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

    private void SaveGame()
    {
        SaveData data = new SaveData
        {
            CurrentLocation = currentLocation,
            InventoryItems = inventory.GetItems()
        };

        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(SaveFilePath, json);

        Console.WriteLine("Game saved successfully!");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void LoadGame()
    {
        if (File.Exists(SaveFilePath))
        {
            string json = File.ReadAllText(SaveFilePath);
            SaveData data = JsonSerializer.Deserialize<SaveData>(json);

            currentLocation = data.CurrentLocation;
            inventory.SetItems(data.InventoryItems);

            Console.WriteLine("Game loaded successfully!");
            Console.WriteLine($"You are at: {currentLocation}");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Play();
        }
        else
        {
            Console.WriteLine("No save file found.");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }
}