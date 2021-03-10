using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject PressFText;
    public Item ChosenItem;
    [SerializeField] private List<Item> m_Item;
    private SpriteRenderer m_SpriteRenderer;
    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        ChosenItem = m_Item[Random.Range(0, m_Item.Count)];
        m_SpriteRenderer.sprite = ChosenItem.Icon;
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
