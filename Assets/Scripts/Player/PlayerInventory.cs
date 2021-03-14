using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory")]

public class PlayerInventory : ScriptableObject
{
    public int Diamond;
    public int Emerald;
    public int Gold;
    public int Pearl;
    public int Ruby;

    public int TotalMoney;
}
