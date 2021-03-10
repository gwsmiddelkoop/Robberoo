using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowModus : MonoBehaviour
{
    [SerializeField] AIPatrolModus m_Patrol;
    [SerializeField] GameObject m_Target;

    private void Start()
    {
        m_Target = GameObject.Find("Player");
    }

    private void Update()
    {
        if(m_Patrol.IsPatrolModus == false)
        {

        }
    }
}
