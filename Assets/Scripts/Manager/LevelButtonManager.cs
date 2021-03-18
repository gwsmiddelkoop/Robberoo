using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelButtonManager : MonoBehaviour
{
    public GameObject buyButton2;
    public GameObject buyButton3;
    public GameObject buyText2;
    public GameObject buyText3;
    public TextMeshProUGUI totalMoneyTxt;
    public PlayerInventory playerInventory;
    public int levelPrice = 100000;

    private void Start()
    {
        if (playerInventory.Level2Unlocked)
        {
            buyButton2.SetActive(false);
            buyText2.SetActive(false);
        }

        if (playerInventory.Level3Unlocked)
        {
            buyButton3.SetActive(false);
            buyText3.SetActive(false);
        }
    }

    private void Update()
    {
        totalMoneyTxt.text = string.Format("Total Cash: €{0}", playerInventory.TotalMoney);
    }

    public void BuyLevel2()
    {
        if (playerInventory.TotalMoney >= levelPrice)
        {
            gameObject.SetActive(false);
            buyText2.SetActive(false);
            playerInventory.Level2Unlocked = true;
            playerInventory.TotalMoney -= levelPrice;
        }
        else
        {
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }

    public void BuyLevel3()
    {
        if (playerInventory.TotalMoney >= levelPrice)
        {
            gameObject.SetActive(false);
            buyText3.SetActive(false);
            playerInventory.Level3Unlocked = true;
            playerInventory.TotalMoney -= levelPrice;
        }
        else
        {
            PopUpMessage.Instance.ShowMessage("Not enough money!");
        }
    }
}
