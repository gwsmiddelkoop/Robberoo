using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTakedown : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public TextMeshProUGUI upgradeCostTxt;

    public void UpgradeTakeDown()
    {
        if (playerInventory.TotalMoney >= playerInventory.UpgradeCost)
        {
            playerInventory.TakedownsAmount++;
            playerInventory.TotalMoney -= playerInventory.UpgradeCost;
            playerInventory.UpgradeCost = playerInventory.UpgradeCost + (playerInventory.UpgradeCost * 2);
            upgradeCostTxt.text = string.Format("€{0}", playerInventory.UpgradeCost);
        }
        else
        {
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }
}
