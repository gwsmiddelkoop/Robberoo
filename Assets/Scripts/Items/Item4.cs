using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Pearl")]
public class Item3 : ScriptableObject
{
    public Sprite Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
