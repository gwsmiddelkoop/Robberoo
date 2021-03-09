using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ValueItem"))
        {
            if (Input.GetKey(KeyCode.F))
            {
            print("PickedUp");
            collision.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator PickUp()
    {
        yield return new WaitForSeconds(1);
    }
}
