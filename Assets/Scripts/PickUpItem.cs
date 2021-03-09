using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject PressFText;
    private void Start()
    {
        PressFText.SetActive(false);
    }
    public void TurnTextOn()
    {
        PressFText.SetActive(true);
    }

    public void TurnTextOff()
    {
        PressFText.SetActive(false);
    }
}
