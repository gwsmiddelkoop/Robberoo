using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketManager : MonoBehaviour
{
    public static MarketManager Instance;

    [Header("Items")]
    public Item Item1;
    public Item Item2;
    public Item Item3;
    public Item Item4;
    public Item Item5;

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
    public Sprite SellValueChangePlus;
    public Sprite SellValueChangeMin;
    public Sprite BuyValueChangePlus;
    public Sprite BuyValueChangeMin;
    public Sprite ValueChangeSame;

    public Image Item1BuyChangeIcon;
    public Image Item2BuyChangeIcon;
    public Image Item3BuyChangeIcon;
    public Image Item4BuyChangeIcon;
    public Image Item5BuyChangeIcon;

    public Image Item1SellChangeIcon;
    public Image Item2SellChangeIcon;
    public Image Item3SellChangeIcon;
    public Image Item4SellChangeIcon;
    public Image Item5SellChangeIcon;

    public Image TimerResetIcon;

    public TextMeshProUGUI TimerTxt;
    public int timerAmount = 60;
    public int rotationSpeed = 40;
    private bool oneTimeCalled = false;
    private bool oneTimeCalledRanks = false;

    private int Item1SavedBuyValue;
    private int Item2SavedBuyValue;
    private int Item3SavedBuyValue;
    private int Item4SavedBuyValue;
    private int Item5SavedBuyValue;

    private int Item1SavedSellValue;
    private int Item2SavedSellValue;
    private int Item3SavedSellValue;
    private int Item4SavedSellValue;
    private int Item5SavedSellValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine("UpdateTimer");
        timerAmount = 30;

        #region Defining Item Names, Icons, and Values
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

        // Defines the item selling values and transforms it to text
        Item1SellValue.text = string.Format("€" + Item1.sellValue.ToString());
        Item2SellValue.text = string.Format("€" + Item2.sellValue.ToString());
        Item3SellValue.text = string.Format("€" + Item3.sellValue.ToString());
        Item4SellValue.text = string.Format("€" + Item4.sellValue.ToString());
        Item5SellValue.text = string.Format("€" + Item5.sellValue.ToString());

        // Defines the item buying values and transforms it to text
        Item1BuyValue.text = string.Format("€" + Item1.buyValue.ToString());
        Item2BuyValue.text = string.Format("€" + Item2.buyValue.ToString());
        Item3BuyValue.text = string.Format("€" + Item3.buyValue.ToString());
        Item4BuyValue.text = string.Format("€" + Item4.buyValue.ToString());
        Item5BuyValue.text = string.Format("€" + Item5.buyValue.ToString());
        #endregion
    }

    private void Update()
    {
        // Sets the timer to 30 when in real life a new minute has started.
        if (System.DateTime.Now.Second == 1)
        {
            timerAmount = 29;
        }

        // When in real life 30 seconds are reached, the market gets updated.
        if (System.DateTime.Now.Second == 30 || System.DateTime.Now.Second == 0)
        {
            timerAmount = 30;

            UpdateSavedValues();
            UpdateValues();
            Invoke("UpdateTradeRanks", 1.5f);
        }

        // Updates the timer text.
        TimerTxt.text = string.Format("00:00:{0}", timerAmount);

        // Rotates the given icon a certain degrees on the Z axis.
        TimerResetIcon.transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);

    }

    public void UpdateValues()
    {
        // Sets all the market item values to a random number
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

        // Defines the market item selling values
        Item1SellValue.text = string.Format("€" + Item1.sellValue.ToString());
        Item2SellValue.text = string.Format("€" + Item2.sellValue.ToString());
        Item3SellValue.text = string.Format("€" + Item3.sellValue.ToString());
        Item4SellValue.text = string.Format("€" + Item4.sellValue.ToString());
        Item5SellValue.text = string.Format("€" + Item5.sellValue.ToString());

        // Defines the market item buying values
        Item1BuyValue.text = string.Format("€" + Item1.buyValue.ToString());
        Item2BuyValue.text = string.Format("€" + Item2.buyValue.ToString());
        Item3BuyValue.text = string.Format("€" + Item3.buyValue.ToString());
        Item4BuyValue.text = string.Format("€" + Item4.buyValue.ToString());
        Item5BuyValue.text = string.Format("€" + Item5.buyValue.ToString());
    }

    public void UpdateSavedValues()
    {
        if (!oneTimeCalled)
        {
            // Sets all the given values to the current Item buy value, before updating it on the market.
            Item1SavedBuyValue = Item1.buyValue;
            Item2SavedBuyValue = Item2.buyValue;
            Item3SavedBuyValue = Item3.buyValue;
            Item4SavedBuyValue = Item4.buyValue;
            Item5SavedBuyValue = Item5.buyValue;

            Item1SavedSellValue = Item1.sellValue;
            Item2SavedSellValue = Item2.sellValue;
            Item3SavedSellValue = Item3.sellValue;
            Item4SavedSellValue = Item4.sellValue;
            Item5SavedSellValue = Item5.sellValue;

            oneTimeCalled = true;
            Invoke("ResetOneTime", 30);
        }
    }

    public void UpdateTradeRanks()
    {
        if (!oneTimeCalledRanks)
        {
            #region Update buy-tradingmarker arrow for Item 1
            if (Item1SavedBuyValue > Item1.buyValue)
            {
                // If the old price is higher than the new buy price, the given sprite is shown.
                Item1BuyChangeIcon.sprite = BuyValueChangeMin;
            }
            else if (Item1SavedBuyValue < Item1.buyValue)
            {
                // If the old price is lower than the new buy price, the given sprite is shown.
                Item1BuyChangeIcon.sprite = BuyValueChangePlus;
            }
            else
            {
                // If the old price is even as the new buy price, the given sprite is shown.
                Item1BuyChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update buy-tradingmarker arrow for Item 2
            if (Item2SavedBuyValue > Item2.buyValue)
            {
                // If the old price is higher than the new buy price, the given sprite is shown.
                Item2BuyChangeIcon.sprite = BuyValueChangeMin;
            }
            else if (Item2SavedBuyValue < Item2.buyValue)
            {
                // If the old price is lower than the new buy price, the given sprite is shown.
                Item2BuyChangeIcon.sprite = BuyValueChangePlus;
            }
            else
            {
                // If the old price is even as the new buy price, the given sprite is shown.
                Item2BuyChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update buy-tradingmarker arrow for Item 3
            if (Item3SavedBuyValue > Item3.buyValue)
            {
                // If the old price is higher than the new buy price, the given sprite is shown.
                Item3BuyChangeIcon.sprite = BuyValueChangeMin;
            }
            else if (Item3SavedBuyValue < Item3.buyValue)
            {
                // If the old price is lower than the new buy price, the given sprite is shown.
                Item3BuyChangeIcon.sprite = BuyValueChangePlus;
            }
            else
            {
                // If the old price is even as the new buy price, the given sprite is shown.
                Item3BuyChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update buy-tradingmarker arrow for Item 4
            if (Item4SavedBuyValue > Item4.buyValue)
            {
                // If the old price is higher than the new buy price, the given sprite is shown.
                Item4BuyChangeIcon.sprite = BuyValueChangeMin;
            }
            else if (Item4SavedBuyValue < Item4.buyValue)
            {
                // If the old price is lower than the new buy price, the given sprite is shown.
                Item4BuyChangeIcon.sprite = BuyValueChangePlus;
            }
            else
            {
                // If the old price is even as the new buy price, the given sprite is shown.
                Item4BuyChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update buy-tradingmarker arrow for Item 5
            if (Item5SavedBuyValue > Item5.buyValue)
            {
                // If the old price is higher than the new buy price, the given sprite is shown.
                Item5BuyChangeIcon.sprite = BuyValueChangeMin;
            }
            else if (Item5SavedBuyValue < Item5.buyValue)
            {
                // If the old price is lower than the new buy price, the given sprite is shown.
                Item5BuyChangeIcon.sprite = BuyValueChangePlus;
            }
            else
            {
                // If the old price is even as the new buy price, the given sprite is shown.
                Item5BuyChangeIcon.sprite = ValueChangeSame;
            }
            #endregion

            #region Update sell-tradingmarker arrow for Item 1
            if (Item1SavedSellValue > Item1.sellValue)
            {
                // If the old price is higher than the new sell price, the given sprite is shown.
                Item1SellChangeIcon.sprite = SellValueChangeMin;
            }
            else if (Item1SavedSellValue < Item1.sellValue)
            {
                // If the old price is lower than the new sell price, the given sprite is shown.
                Item1SellChangeIcon.sprite = SellValueChangePlus;
            }
            else
            {
                // If the old price is even as the new sell price, the given sprite is shown.
                Item1SellChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update sell-tradingmarker arrow for Item 2
            if (Item2SavedSellValue > Item2.sellValue)
            {
                // If the old price is higher than the new sell price, the given sprite is shown.
                Item2SellChangeIcon.sprite = SellValueChangeMin;
            }
            else if (Item2SavedSellValue < Item2.sellValue)
            {
                // If the old price is lower than the new sell price, the given sprite is shown.
                Item2SellChangeIcon.sprite = SellValueChangePlus;
            }
            else
            {
                // If the old price is even as the new sell price, the given sprite is shown.
                Item2SellChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update sell-tradingmarker arrow for Item 3
            if (Item3SavedSellValue > Item3.sellValue)
            {
                // If the old price is higher than the new sell price, the given sprite is shown.
                Item3SellChangeIcon.sprite = SellValueChangeMin;
            }
            else if (Item3SavedSellValue < Item3.sellValue)
            {
                // If the old price is lower than the new sell price, the given sprite is shown.
                Item3SellChangeIcon.sprite = SellValueChangePlus;
            }
            else
            {
                // If the old price is even as the new sell price, the given sprite is shown.
                Item3SellChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update sell-tradingmarker arrow for Item 4
            if (Item4SavedSellValue > Item4.sellValue)
            {
                // If the old price is higher than the new sell price, the given sprite is shown.
                Item4SellChangeIcon.sprite = SellValueChangeMin;
            }
            else if (Item4SavedSellValue < Item4.sellValue)
            {
                // If the old price is lower than the new sell price, the given sprite is shown.
                Item4SellChangeIcon.sprite = SellValueChangePlus;
            }
            else
            {
                // If the old price is even as the new sell price, the given sprite is shown.
                Item4SellChangeIcon.sprite = ValueChangeSame;
            }
            #endregion
            #region Update sell-tradingmarker arrow for Item 5
            if (Item5SavedSellValue > Item5.sellValue)
            {
                // If the old price is higher than the new sell price, the given sprite is shown.
                Item5SellChangeIcon.sprite = SellValueChangeMin;
            }
            else if (Item5SavedSellValue < Item5.sellValue)
            {
                // If the old price is lower than the new sell price, the given sprite is shown.
                Item5SellChangeIcon.sprite = SellValueChangePlus;
            }
            else
            {
                // If the old price is even as the new sell price, the given sprite is shown.
                Item5SellChangeIcon.sprite = ValueChangeSame;
            }
            #endregion

            oneTimeCalledRanks = true;
        }
    }

    public void ResetOneTime()
    {
        oneTimeCalled = false;
        oneTimeCalledRanks = false;
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            // Takes one from the timer every 1 second.
            yield return new WaitForSeconds(1);
            timerAmount--;
        }
    }

    #region Item Buy Buttons
    public void BuyItem1()
    {
        if (InventoryManager.Instance.moneyTotalAmount >= Item1.buyValue)
        {
            InventoryManager.Instance.moneyTotalAmount -= Item1.buyValue;
            InventoryManager.Instance.item1TotalAmount++;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }
    public void BuyItem2()
    {
        if (InventoryManager.Instance.moneyTotalAmount >= Item2.buyValue)
        {
            InventoryManager.Instance.moneyTotalAmount -= Item2.buyValue;
            InventoryManager.Instance.item2TotalAmount++;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }
    public void BuyItem3()
    {
        if (InventoryManager.Instance.moneyTotalAmount >= Item3.buyValue)
        {
            InventoryManager.Instance.moneyTotalAmount -= Item3.buyValue;
            InventoryManager.Instance.item3TotalAmount++;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }
    public void BuyItem4()
    {
        if (InventoryManager.Instance.moneyTotalAmount >= Item4.buyValue)
        {
            InventoryManager.Instance.moneyTotalAmount -= Item4.buyValue;
            InventoryManager.Instance.item4TotalAmount++;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }
    public void BuyItem5()
    {
        if (InventoryManager.Instance.moneyTotalAmount >= Item5.buyValue)
        {
            InventoryManager.Instance.moneyTotalAmount -= Item5.buyValue;
            InventoryManager.Instance.item5TotalAmount++;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }
    #endregion

    #region Item Sell Buttons
    public void SellItem1()
    {
        if (InventoryManager.Instance.item1TotalAmount >= 1)
        {
            InventoryManager.Instance.moneyTotalAmount += Item1.sellValue;
            InventoryManager.Instance.item1TotalAmount--;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("No  " + Item1.itemName + "  to sell!");
        }
    }
    public void SellItem2()
    {
        if (InventoryManager.Instance.item2TotalAmount >= 1)
        {
            InventoryManager.Instance.moneyTotalAmount += Item2.sellValue;
            InventoryManager.Instance.item2TotalAmount--;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("No  " + Item2.itemName + "  to sell!");
        }
    }
    public void SellItem3()
    {
        if (InventoryManager.Instance.item3TotalAmount >= 1)
        {
            InventoryManager.Instance.moneyTotalAmount += Item3.sellValue;
            InventoryManager.Instance.item3TotalAmount--;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("No  " + Item3.itemName + "  to sell!");
        }
    }
    public void SellItem4()
    {
        if (InventoryManager.Instance.item4TotalAmount >= 1)
        {
            InventoryManager.Instance.moneyTotalAmount += Item4.sellValue;
            InventoryManager.Instance.item4TotalAmount--;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("No  " + Item4.itemName + "  to sell!");
        }
    }
    public void SellItem5()
    {
        if (InventoryManager.Instance.item5TotalAmount >= 1)
        {
            InventoryManager.Instance.moneyTotalAmount += Item5.sellValue;
            InventoryManager.Instance.item5TotalAmount--;
            InventoryManager.Instance.ConvertInventory();
        }
        else
        {
            // Shows a popup message on screen with the given text.
            PopUpMessage.Instance.ShowMessage("No  " + Item5.itemName + "  to sell!");
        }
    }
    #endregion
}
