using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Gold")]
public class Item_Gold : ScriptableObject
{
    public SpriteRenderer Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
