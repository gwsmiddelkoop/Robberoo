using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject PressFText;
    [SerializeField] private List<Item> m_Item;
    private SpriteRenderer m_SpriteRenderer;
    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Item chosenItem = m_Item[Random.Range(0, m_Item.Count)];
        m_SpriteRenderer.sprite = chosenItem.Icon;
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
