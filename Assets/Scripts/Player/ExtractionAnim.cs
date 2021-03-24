using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionAnim : MonoBehaviour
{
    public static ExtractionAnim Instance;

    public Animator Animation;

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

    public void IsExtracting()
    {
        Animation.SetBool("isExtracting", true);
    }
}
