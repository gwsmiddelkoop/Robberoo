using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpMessage : MonoBehaviour
{
    public static PopUpMessage Instance;

    public Animator Animation;
    public TextMeshProUGUI MessageText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        Animation.SetBool("showMessage", false);
        Animation.SetBool("hideMessage", false);
    }

    // Shows a pop-up message in the screen with the given 'info' message.
    public void ShowMessage(string info)
    {
        MessageText.text = info;
        Animation.SetBool("showMessage", true);
        StartCoroutine("HideMessage");
    }

    // Hides the message after given actions.
    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(4);
        Animation.SetBool("hideMessage", true);
        yield return new WaitForSeconds(1);
        Animation.SetBool("hideMessage", false);
        Animation.SetBool("showMessage", false);
        StopCoroutine("HideMessage");
    }
}
