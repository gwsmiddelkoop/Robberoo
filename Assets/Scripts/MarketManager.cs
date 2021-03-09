using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarketManager : MonoBehaviour
{
    [Header("Items")]
    public Item_Diamond DiamondItem;
    public Item_Emerald EmeraldItem;
    public Item_Gold GoldItem;
    public Item_Pearl PearlItem;
    public Item_Ruby RubyItem;

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

    private void Start()
    {
        // Defines all the item names for the market
        Item1Name.text = DiamondItem.itemName;
        Item2Name.text = EmeraldItem.itemName;
        Item3Name.text = GoldItem.itemName;
        Item4Name.text = PearlItem.itemName;
        Item5Name.text = RubyItem.itemName;

        // Defines the item selling values
        Item1SellValue.text = string.Format("€" + DiamondItem.sellValue.ToString());
        Item2SellValue.text = string.Format("€" + EmeraldItem.sellValue.ToString());
        Item3SellValue.text = string.Format("€" + GoldItem.sellValue.ToString());
        Item4SellValue.text = string.Format("€" + PearlItem.sellValue.ToString());
        Item5SellValue.text = string.Format("€" + RubyItem.sellValue.ToString());

        // Defines the item buying values
        Item1BuyValue.text = string.Format("€" + DiamondItem.buyValue.ToString());
        Item2BuyValue.text = string.Format("€" + EmeraldItem.buyValue.ToString());
        Item3BuyValue.text = string.Format("€" + GoldItem.buyValue.ToString());
        Item4BuyValue.text = string.Format("€" + PearlItem.buyValue.ToString());
        Item5BuyValue.text = string.Format("€" + RubyItem.buyValue.ToString());
    }
}
