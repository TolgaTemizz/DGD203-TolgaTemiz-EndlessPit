// Location.cs
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
        InteractiveElement?.Interact(inventory);
        Console.WriteLine("Press any key to return to the map.");
        Console.ReadKey();
    }
}