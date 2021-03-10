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

        // Sets all the item values to a random number
        DiamondItem.buyValue = Random.Range(6000, 10000);
        EmeraldItem.buyValue = Random.Range(8000, 15000);
        GoldItem.buyValue = Random.Range(5000, 7000);
        PearlItem.buyValue = Random.Range(5000, 8000);
        RubyItem.buyValue = Random.Range(5000, 20000);

        DiamondItem.sellValue = (DiamondItem.buyValue - Random.Range(1000, 4000));
        EmeraldItem.sellValue = (EmeraldItem.buyValue - Random.Range(1000, 4000));
        GoldItem.sellValue = (GoldItem.buyValue - Random.Range(1000, 4000));
        PearlItem.sellValue = (PearlItem.buyValue - Random.Range(1000, 4000));
        RubyItem.sellValue = (RubyItem.buyValue - Random.Range(1000, 4000));

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
