using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOW : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;
    public LayerMask ObstacleMask, playermask;
    Collider2D[] InRadius;
    public List<Transform> visiblePlayer = new List<Transform>();

    private void FixedUpdate()
    {
        FindVisiblePlayer();
    }

    void FindVisiblePlayer()
    {
        InRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius);

        visiblePlayer.Clear();

        for (int i = 0; i < InRadius.Length; i++)
        {
            Transform player = InRadius[i].transform;
            Vector2 dirTarget = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            if (Vector2.Angle(dirTarget, transform.right) < viewAngle / 2)
            {
                float distancePlayer = Vector2.Distance(transform.position, player.position);

                if (!Physics2D.Raycast(transform.position, dirTarget, distancePlayer, ObstacleMask))
                {
                    if (Physics2D.Raycast(transform.position, dirTarget, distancePlayer, playermask))
                    {
                        visiblePlayer.Add(player);
                        GetComponent<AIPatrolModus>().IsPatrolModus = false;
                    }
                    else
                    {
                        GetComponent<AIPatrolModus>().IsPatrolModus = true;
                    }
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }
}
