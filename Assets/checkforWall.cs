using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkforWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Tilemap" && GetComponentInParent<AIPatrolModus>().islooking == true)
        {
            if (GetComponentInParent<AIPatrolModus>().LeftOrRight == true)
            {
                GetComponentInParent<AIPatrolModus>().LeftOrRight = false;
            }
            else
            {
                GetComponentInParent<AIPatrolModus>().LeftOrRight = true;
            }
        }
    }
}
