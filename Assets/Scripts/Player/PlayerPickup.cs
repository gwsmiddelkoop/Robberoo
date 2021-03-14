using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    [Header("Debug Booleans")]
    public bool isPickingUp;
    public bool inCollider;

    private float pickUpTime;

    private GameObject pickedUpItem;

    private PickUpItem bar;

    private void Start()
    {
        // set bools to false
        isPickingUp = false;
        inCollider = false;

        pickUpTime = GameRules.Instance.pickUpTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inCollider)
        {
            StartCoroutine(PickUp());

            bar.startAnimation = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ValueItem"))
        {
            bar = collision.gameObject.GetComponent<PickUpItem>();
            collision.gameObject.GetComponent<PickUpItem>().TurnTextOn();
            inCollider = true;
            pickedUpItem = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ValueItem"))
        {
            collision.gameObject.GetComponent<PickUpItem>().TurnTextOff();
            inCollider = false;
        }
    }

    private IEnumerator PickUp()
    {
        // TODO: play animation

        isPickingUp = true;

        yield return new WaitForSeconds(pickUpTime);

        pickedUpItem.SetActive(false);

        CheckWhatItem();

        // set bools to false again
        isPickingUp = false;
        inCollider = false;
    }

    private void CheckWhatItem()
    {
        if (pickedUpItem.GetComponent<PickUpItem>().chosenItem.itemName == "Diamond")
        {
            InventoryAdder.instance.grabbedDiamonds += 1;
        }
        else if (pickedUpItem.GetComponent<PickUpItem>().chosenItem.itemName == "Emerald")
        {
            InventoryAdder.instance.grabbedEmeralds += 1;
        }
        else if (pickedUpItem.GetComponent<PickUpItem>().chosenItem.itemName == "Gold")
        {
            InventoryAdder.instance.grabbedGold += 1;
        }
        else if (pickedUpItem.GetComponent<PickUpItem>().chosenItem.itemName == "Pearl")
        {
            InventoryAdder.instance.grabbedPearls += 1;
        }
        else if (pickedUpItem.GetComponent<PickUpItem>().chosenItem.itemName == "Ruby")
        {
            InventoryAdder.instance.grabbedRubys += 1;
        }
    }
}
