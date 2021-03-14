using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    private static GameRules instance;
    public static GameRules Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameRules>();
            }
            return instance;
        }
    }

    [HideInInspector] public float pickUpTime       = 2f;
    [HideInInspector] public float playerMoveSpeed  = 2f;

}
