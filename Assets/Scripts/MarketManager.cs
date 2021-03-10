using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketManager : MonoBehaviour
{
    [Header("Items")]
    public Item1 Item1;
    public Item2 Item2;
    public Item3 Item3;
    public Item4 Item4;
    public Item5 Item5;

    [Header("Item Names")]
    public TextMeshProUGUI Item1Name;
    public TextMeshProUGUI Item2Name;
    public TextMeshProUGUI Item3Name;
    public TextMeshProUGUI Item4Name;
    public TextMeshProUGUI Item5Name;

    [Header("Item Sell Values")]
    public TextMeshProUGUI Item1SellValue;
    public TextMeshProUGUI Item2SellValue;
    public TextMeshProUGUI Item3SellValue;
    public TextMeshProUGUI Item4SellValue;
    public TextMeshProUGUI Item5SellValue;

    [Header("Item Buy Values")]
    public TextMeshProUGUI Item1BuyValue;
    public TextMeshProUGUI Item2BuyValue;
    public TextMeshProUGUI Item3BuyValue;
    public TextMeshProUGUI Item4BuyValue;
    public TextMeshProUGUI Item5BuyValue;

    [Header("Item Icons")]
    public Image Item1Icon;
    public Image Item2Icon;
    public Image Item3Icon;
    public Image Item4Icon;
    public Image Item5Icon;
    
    private void Start()
    {
        // Defines all the item names for the market
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

        // Sets all the item values to a random number
        Item1.buyValue = Random.Range(6000, 10000);
        Item2.buyValue = Random.Range(8000, 15000);
        Item3.buyValue = Random.Range(5000, 7000);
        Item4.buyValue = Random.Range(5000, 8000);
        Item5.buyValue = Random.Range(5000, 20000);

        Item1.sellValue = (Item1.buyValue - Random.Range(1000, 4000));
        Item2.sellValue = (Item2.buyValue - Random.Range(1000, 4000));
        Item3.sellValue = (Item3.buyValue - Random.Range(1000, 4000));
        Item4.sellValue = (Item4.buyValue - Random.Range(1000, 4000));
        Item5.sellValue = (Item5.buyValue - Random.Range(1000, 4000));

        // Defines the item selling values
        Item1SellValue.text = string.Format("�" + Item1.sellValue.ToString());
        Item2SellValue.text = string.Format("�" + Item2.sellValue.ToString());
        Item3SellValue.text = string.Format("�" + Item3.sellValue.ToString());
        Item4SellValue.text = string.Format("�" + Item4.sellValue.ToString());
        Item5SellValue.text = string.Format("�" + Item5.sellValue.ToString());

        // Defines the item buying values
        Item1BuyValue.text = string.Format("�" + Item1.buyValue.ToString());
        Item2BuyValue.text = string.Format("�" + Item2.buyValue.ToString());
        Item3BuyValue.text = string.Format("�" + Item3.buyValue.ToString());
        Item4BuyValue.text = string.Format("�" + Item4.buyValue.ToString());
        Item5BuyValue.text = string.Format("�" + Item5.buyValue.ToString());
    }
}