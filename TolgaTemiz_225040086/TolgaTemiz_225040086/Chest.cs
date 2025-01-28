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

        // Eşyayı kullanmak için seçenek
        Console.WriteLine("Do you want to use this item?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            UseItem(inventory);
        }
        else
        {
            Console.WriteLine("You decide not to use the item.");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void UseItem(Inventory inventory)
    {
        if (item == "Ancient Coin")
        {
            Console.WriteLine("You use the Ancient Coin and hear a distant sound of a door opening...");
        }
        else
        {
            Console.WriteLine("This item has no immediate effect.");
        }
    }
}