using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Items")]
    public Item1 Item1;
    public Item2 Item2;
    public Item3 Item3;
    public Item4 Item4;
    public Item5 Item5;

    [Header("Item Icons")]
    public Image Item1Icon;
    public Image Item2Icon;
    public Image Item3Icon;
    public Image Item4Icon;
    public Image Item5Icon;

    [Header("Item Amounts")]
    public int item1TotalAmount;
    public int item2TotalAmount;
    public int item3TotalAmount;
    public int item4TotalAmount;
    public int item5TotalAmount;

    [Header("Item Amount Text")]
    public TextMeshProUGUI Item1AmountTxt;
    public TextMeshProUGUI Item2AmountTxt;
    public TextMeshProUGUI Item3AmountTxt;
    public TextMeshProUGUI Item4AmountTxt;
    public TextMeshProUGUI Item5AmountTxt;

    [Header("Item Names")]
    public TextMeshProUGUI Item1Name;
    public TextMeshProUGUI Item2Name;
    public TextMeshProUGUI Item3Name;
    public TextMeshProUGUI Item4Name;
    public TextMeshProUGUI Item5Name;

    private void Start()
    {
        // Defines all the item names for the inventory
        Item1Name.text = Item1.itemName;
        Item2Name.text = Item2.itemName;
        Item3Name.text = Item3.itemName;
        Item4Name.text = Item4.itemName;
        Item5Name.text = Item5.itemName;

        // Sets all the item icons
        Item1Icon.sprite = Item1.Icon;
        Item2Icon.sprite = Item2.Icon;
        Item3Icon.sprite = Item3.Icon;
        Item4Icon.sprite = Item4.Icon;
        Item5Icon.sprite = Item5.Icon;

        // Sets the total amounts of the items
        Item1AmountTxt.text = string.Format(item1TotalAmount.ToString());
        Item2AmountTxt.text = string.Format(item2TotalAmount.ToString());
        Item3AmountTxt.text = string.Format(item3TotalAmount.ToString());
        Item4AmountTxt.text = string.Format(item4TotalAmount.ToString());
        Item5AmountTxt.text = string.Format(item5TotalAmount.ToString());
    }
}