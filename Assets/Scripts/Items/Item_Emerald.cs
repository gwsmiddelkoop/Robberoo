using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Emerald")]
public class Item_Emerald : ScriptableObject
{
    public SpriteRenderer Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
