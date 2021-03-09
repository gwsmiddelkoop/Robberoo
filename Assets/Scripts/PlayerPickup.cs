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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ValueItem"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("ClickedF");
            }
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
        //PlayPickUpAnimation
        PickingUp = true;
        yield return new WaitForSeconds(2);
        print("PickedUp");
        m_SelectedItem.SetActive(false);
        PickingUp = false;
        InCollider = false;
    }
}
