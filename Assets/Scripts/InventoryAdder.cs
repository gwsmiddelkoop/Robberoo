using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdder : MonoBehaviour
{

    public static InventoryAdder instance;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
        }
    }

    public int GrabbedDiamonds;
    public int GrabbedEmeralds;
    public int GrabbedGold;
    public int GrabbedPeals;
    public int GrabbedRubys;
}
