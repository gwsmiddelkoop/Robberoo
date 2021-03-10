using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Gold")]
public class Item2 : ScriptableObject
{
    public Sprite Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
