// Inventory.cs
using System;
using System.Collections.Generic;

class Inventory
{
    private List<string> items;

    public Inventory()
    {
        items = new List<string>();
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine($"You have obtained: {item}");
    }

    public void ShowInventory()
    {
        Console.WriteLine("--- Inventory ---");
        if (items.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
