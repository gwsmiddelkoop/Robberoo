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
        m_Patrol = GetComponent<AIPatrolModus>();
    }

    private void Update()
    {
        if(m_Patrol.IsPatrolModus == false)
        {
            if(m_Target.GetComponent<PlayerController>().m_IsCloaked == false)
            {
                transform.LookAt(m_Target.transform.position);

                transform.Translate(new Vector3(m_Patrol.m_MoveSpeed * Time.deltaTime, 0, 0));
            }
        }
    }
}
