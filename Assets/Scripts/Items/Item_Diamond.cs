using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Diamond")]
public class Item_Diamond : ScriptableObject
{
    public SpriteRenderer Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
