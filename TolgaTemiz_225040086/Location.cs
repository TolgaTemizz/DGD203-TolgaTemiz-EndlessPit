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

        // Fakir köylü diyalogu sadece Village'de
        if (Name == "Village")
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
                

                // Oyunu yeniden başlatmak için ana menüye dön
                Game game = new Game();
                game.Start();
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Returning to the map.");
            }
        }

        // Eğer başka bir element varsa, onunla da etkileşim sağlanır
        InteractiveElement?.Interact(inventory);
        Console.WriteLine("Press any key to return to the map.");
        Console.ReadKey();
    }
}
