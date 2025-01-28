using System;
using System.Collections.Generic;

[Serializable]
class SaveData
{
    public string CurrentLocation { get; set; }
    public List<string> InventoryItems { get; set; }
}