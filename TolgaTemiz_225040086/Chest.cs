// Chest.cs
using System;

class Chest : IInteractable
{
    private string item;

    public Chest(string item)
    {
        this.item = item;
    }

    public void Interact(Inventory inventory)
    {
        Console.WriteLine("You open the chest and find something inside!");
        inventory.AddItem(item);
    }
}
