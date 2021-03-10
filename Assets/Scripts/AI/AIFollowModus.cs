using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowModus : MonoBehaviour
{
    [SerializeField] private AIPatrolModus m_Patrol;
    [SerializeField] private GameObject m_Target;

    [SerializeField] private GameObject m_GameOver;

    [SerializeField] private float GrabDist; 
    private void Start()
    {
        m_Target = GameObject.Find("Player");
        m_Patrol = GetComponent<AIPatrolModus>();
    }

    private void Update()
    {
        if (m_Patrol.IsPatrolModus == false)
        {
            if (m_Target.GetComponent<PlayerController>().m_IsCloaked == false)
            {
                Vector3 dir = m_Target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion LookDir = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = LookDir;

                transform.Translate(new Vector3(m_Patrol.m_MoveSpeed * Time.deltaTime, 0, 0));

                float dist = Vector3.Distance(m_Target.transform.position, transform.position);

                if (dist <= GrabDist)
                {
                    m_GameOver.SetActive(true);
                    m_Target.SetActive(false);
                }
            }
            else
            {
                m_Patrol.IsPatrolModus = true;
            }
        }
    }
}
