using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Ruby")]
public class Item_Ruby : ScriptableObject
{
    public SpriteRenderer Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
