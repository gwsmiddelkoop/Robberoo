using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    public bool PickingUp;
    private GameObject m_SelectedItem;
    public bool InCollider;

    private void Start()
    {
        PickingUp = false;
        InCollider = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && InCollider)
        {
            StartCoroutine(PickUp());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ValueItem"))
        {
            collision.gameObject.GetComponent<PickUpItem>().TurnTextOn();
            InCollider = true;
            m_SelectedItem = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ValueItem"))
        {
            collision.gameObject.GetComponent<PickUpItem>().TurnTextOff();
            InCollider = false;
        }
    }


    private IEnumerator PickUp()
    {
        //Play PickUpAnimation
        PickingUp = true;
        yield return new WaitForSeconds(2);
        m_SelectedItem.SetActive(false);
        CheckWhatItem();
        PickingUp = false;
        InCollider = false;
    }

    private void CheckWhatItem()
    {
        if (m_SelectedItem.GetComponent<PickUpItem>().ChosenItem.itemName == "Diamond")
        {
            InventoryAdder.instance.GrabbedDiamonds += 1; 
        }
        else if (m_SelectedItem.GetComponent<PickUpItem>().ChosenItem.itemName == "Emerald")
        {
            InventoryAdder.instance.GrabbedEmeralds += 1;
        }
        else if (m_SelectedItem.GetComponent<PickUpItem>().ChosenItem.itemName == "Gold")
        {
            InventoryAdder.instance.GrabbedGold += 1;
        }
        else if (m_SelectedItem.GetComponent<PickUpItem>().ChosenItem.itemName == "Preal")
        {
            InventoryAdder.instance.GrabbedPeals += 1;
        }
        else if (m_SelectedItem.GetComponent<PickUpItem>().ChosenItem.itemName == "Ruby")
        {
            InventoryAdder.instance.GrabbedRubys += 1;
        }
    }
}
