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

    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{item} has been removed from your inventory.");
        }
        else
        {
            Console.WriteLine($"{item} is not in your inventory.");
        }
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
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
        Console.WriteLine("\nPress any key to return.");
        Console.ReadKey();
    }

    public List<string> GetItems()
    {
        return new List<string>(items);
    }

    public void SetItems(List<string> newItems)
    {
        items = newItems;
    }
}