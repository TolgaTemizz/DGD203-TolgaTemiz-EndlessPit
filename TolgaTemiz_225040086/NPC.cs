using System;

class NPC : IInteractable
{
    private string name;

    public NPC(string name)
    {
        this.name = name;
    }

    public void Interact(Inventory inventory)
    {
        Console.WriteLine($"You meet {name}. They smile at you.");
        Console.WriteLine("1. Ask about the area.");
        Console.WriteLine("2. Show your item to them.");
        Console.WriteLine("3. Leave.");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine($"{name}: 'The area around here is quite mysterious... Keep an eye out for strange things!'");
                break;
            case "2":
                if (inventory.HasItem("Mysterious Artifact"))
                {
                    Console.WriteLine($"{name} looks intrigued by the Mysterious Artifact!");
                    Console.WriteLine($"{name}: 'Ah, I see you're carrying something powerful... Be careful with that artifact, it might attract unwanted attention.'");
                }
                else
                {
                    Console.WriteLine($"{name}: 'You have nothing to show me...'");
                }
                break;
            case "3":
                Console.WriteLine($"{name}: 'Good luck out there, traveler!'");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}