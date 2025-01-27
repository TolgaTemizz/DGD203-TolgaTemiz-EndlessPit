// NPC.cs
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
        Console.WriteLine($"You meet {name}. They give you a special item!");
        inventory.AddItem("Mysterious Artifact");
    }
}
