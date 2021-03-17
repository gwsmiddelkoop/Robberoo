using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject BlackMarket;
    public GameObject Inventory;
    public TextMeshProUGUI InventoryButtonText;
    private bool marketIsOpen = false;

    private void Start()
    {
        BlackMarket.SetActive(false);
        Inventory.SetActive(true);
        InventoryButtonText.text = string.Format("Black Market");
    }

    public void OpenMarket()
    {
        if (!marketIsOpen)
        {
            BlackMarket.SetActive(true);
            Inventory.SetActive(false);
            InventoryButtonText.text = string.Format("Inventory");
            marketIsOpen = true;
        }
        else if (marketIsOpen)
        {
            BlackMarket.SetActive(false);
            Inventory.SetActive(true);
            InventoryButtonText.text = string.Format("Black Market");
            marketIsOpen = false;
        }
    }
}
