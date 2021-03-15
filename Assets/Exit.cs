using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [Header("Debug Booleans")]
    public bool isPickingUp;
    public bool inCollider;

    public GameObject uiTxt;

    private PickUpItem bar;

    private void Start()
    {
        // set bools to false
        inCollider = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && inCollider)
        {
            SceneLoader.Instance.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiTxt.SetActive(true);
            inCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiTxt.SetActive(true);
            inCollider = false;
        }
    }
}
