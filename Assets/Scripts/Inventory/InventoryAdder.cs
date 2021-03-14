using UnityEngine;

public class InventoryAdder : MonoBehaviour
{
    // singleton
    public static InventoryAdder instance;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
        }
    }

    [Header("Grabbed Items Amount")]
    public int grabbedDiamonds;
    public int grabbedEmeralds;
    public int grabbedGold;
    public int grabbedPearls;
    public int grabbedRubys;
}
