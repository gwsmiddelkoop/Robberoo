using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public Sprite Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
