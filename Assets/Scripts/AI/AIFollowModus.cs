using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowModus : MonoBehaviour
{
    [SerializeField] private AIPatrolModus m_Patrol;
    [SerializeField] private GameObject m_Target;
    [SerializeField] private FOW fow;

    [SerializeField] private GameObject m_GameOver;
    [SerializeField] private float GrabDist;
    private Vector3 m_PlayerLastLoc;

    private float Timer;
    //[SerializeField] private float maxTimer;

    private void Start()
    {
        m_Target = GameObject.Find("Player");
        m_Patrol = GetComponent<AIPatrolModus>();
        fow = GetComponent<FOW>();
        m_GameOver = GameObject.Find("Death Menu");
    }

    private void Update()
    {
        if (m_Patrol.IsPatrolModus == false)
        {
            if (m_Target.GetComponent<PlayerController>().isCloaked == false)
            {
                if (fow.visiblePlayer.Count != 0)
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
                    LookingForPlayer();
                }
            }
            else
            {
                //m_Patrol.IsPatrolModus = true;
                LookingForPlayer();
            }
        }
    }
    public bool GetLastLocation = true;
    public void LookingForPlayer()
    {
      
        if (GetLastLocation == true)
        {
            m_PlayerLastLoc = new Vector3(m_Target.transform.position.x - 0.5f, m_Target.transform.position.y - 0.5f, transform.position.z);
            GetLastLocation = false;
        }

        Vector3 dir = m_PlayerLastLoc - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion LookDir = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = LookDir;

        transform.position = Vector2.MoveTowards(transform.position, m_PlayerLastLoc, m_Patrol.m_MoveSpeed * Time.deltaTime);


        if (transform.position == m_PlayerLastLoc)
        {
            m_Patrol.RondKijken();
        }

        Timer += Time.deltaTime;

        if(m_Patrol.EndOfTimer == 0)
        {
            m_Patrol.EndOfTimer = Random.Range(10, 20);
        }

        if (Timer > m_Patrol.EndOfTimer)
        {
            GetLastLocation = true;
            Timer = 0;
            m_Patrol.IsPatrolModus = true;
        }
    }
}
