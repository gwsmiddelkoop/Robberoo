using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pickUpText;

    [Header("Item References")]
    public Item chosenItem;
    public List<Item> availableItems;

    [Header("Bar Properties")]
    public Image barFill;

    private float time;
    private float barMinimum;
    private float barMaximum;
    private float pickUpTime;

    [Header("Debug Properties")]
    public bool startAnimation;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // instantiate
        spriteRenderer = GetComponent<SpriteRenderer>();

        // selecting chosen item
        chosenItem = availableItems[Random.Range(0, availableItems.Count)];

        // set sprite renderen to display
        spriteRenderer.sprite = chosenItem.Icon;

        // set overlays / other stuff to inactive
        pickUpText.SetActive(false);

        // settings bar properties
        barFill.fillAmount = 0f;
        barMinimum = 0f;
        barMaximum = 1f;
        pickUpTime = GameRules.Instance.pickUpTime;
    }

    private void Update()
    {
        if (startAnimation)
        {
            time += Time.deltaTime / pickUpTime;
            barFill.fillAmount = Mathf.Lerp(barMinimum, barMaximum, time);
        }
    }

    public void TurnTextOn()
    {
        // turning text on
        pickUpText.SetActive(true);
    }

    public void TurnTextOff()
    {
        // turning text off
        pickUpText.SetActive(false);
    }
}
