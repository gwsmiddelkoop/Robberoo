using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Ruby")]
public class Item5 : ScriptableObject
{
    public Sprite Icon;
    public string itemName;
    public int sellValue;
    public int buyValue;
}
