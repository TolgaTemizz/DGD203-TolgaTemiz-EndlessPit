using System;
using System.Collections.Generic;

class Map
{
    private Dictionary<string, Location> locations;

    public Map()
    {
        locations = new Dictionary<string, Location>
        {
            { "Forest", new Location("Forest", "A dense forest with tall trees.", new NPC("Wandering Merchant")) },
            { "Cave", new Location("Cave", "A dark and damp cave. There seems to be a treasure chest.", new Chest("Ancient Coin")) },
            { "Village", new Location("Village", "A small peaceful village. A poor villager is asking for help.", null) },
            { "Castle", new Location("Castle", "An ancient castle where the king awaits your arrival.", null) }
        };
    }

    public void DisplayMap()
    {
        Console.WriteLine("--- Map ---");
        foreach (var location in locations.Keys)
        {
            Console.WriteLine(location);
        }
        Console.WriteLine("\n(Type 'inventory' to view your items or 'exit' to return to the menu.)");
    }

    public Location GetLocation(string name)
    {
        locations.TryGetValue(name, out Location location);
        return location;
    }
}