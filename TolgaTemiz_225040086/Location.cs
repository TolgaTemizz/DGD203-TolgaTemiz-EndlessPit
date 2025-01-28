using System;

class Location
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IInteractable InteractiveElement { get; private set; }

    public Location(string name, string description, IInteractable interactiveElement)
    {
        Name = name;
        Description = description;
        InteractiveElement = interactiveElement;
    }

    public void Enter(Inventory inventory)
    {
        Console.Clear();
        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine(Description);

        if (Name == "Village")
        {
            HandleVillageScenario(inventory);
        }
        else if (Name == "Castle")
        {
            HandleCastleScenario(inventory);
        }
        else
        {
            InteractiveElement?.Interact(inventory);
        }

        Console.WriteLine("Press any key to return to the map.");
        Console.ReadKey();
    }

    private void HandleVillageScenario(Inventory inventory)
    {
        Console.WriteLine("You see a poor villager. They approach you with a desperate look.");
        Console.WriteLine("'Please, kind traveler, if you have a coin, could you spare it for me and my family?'");
        Console.WriteLine("What will you do?");
        Console.WriteLine("1. Give the Ancient Coin to the villager.");
        Console.WriteLine("2. Refuse to help.");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            if (inventory.HasItem("Ancient Coin"))
            {
                inventory.RemoveItem("Ancient Coin");
                Console.WriteLine("You hand over the Ancient Coin to the villager.");
                Console.WriteLine("The villager is overwhelmed with gratitude.");
                Console.WriteLine("'Thank you, kind soul! May the gods bless you!'");
                inventory.AddItem("Blessing of the Gods");
            }
            else
            {
                Console.WriteLine("You don't have an Ancient Coin to give.");
            }
        }
        else if (choice == "2")
        {
            Console.WriteLine("You refuse to help the villager.");
            Console.WriteLine("Suddenly, the sky darkens, and you hear thunder...");
            Console.WriteLine("A lightning bolt strikes you!");
            Console.WriteLine("You have angered the gods. You are dead.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();

            Game game = new Game();
            game.Start();
            return;
        }
        else
        {
            Console.WriteLine("Invalid choice. Returning to the map.");
        }
    }

    private void HandleCastleScenario(Inventory inventory)
    {
        Console.WriteLine("You stand before the king in the grand hall.");
        Console.WriteLine("'Adventurer, show me what you have accomplished on your journey.'");

        if (inventory.HasItem("Blessing of the Gods"))
        {
            Console.WriteLine("The king sees the divine blessing upon you and declares you a hero.");
            Console.WriteLine("You have achieved the good ending!");
        }
        else
        {
            Console.WriteLine("The king is disappointed by your lack of compassion.");
            Console.WriteLine("You are banished from the kingdom.");
            Console.WriteLine("You have reached the bad ending.");
        }

        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();

        Game game = new Game();
        game.Start();
    }
}
