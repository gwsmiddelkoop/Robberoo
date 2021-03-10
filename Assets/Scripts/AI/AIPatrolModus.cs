using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolModus : MonoBehaviour
{
    [Header("Waypoint")]
    [SerializeField] public GameObject[] m_PatrolPoints;
    [SerializeField] private float m_MoveSpeed;
    public int m_PatrolPointIndex;

    [Header("Modus")]
    public bool IsPatrolModus = true;
    bool BackWards;

    [Header("WatchAround")]
    private float Timer;
    private float EndOfTimer;
    private float z;

    void Update()
    {
        if (IsPatrolModus == true)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        Vector3 dir = m_PatrolPoints[m_PatrolPointIndex].transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion LookDir = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = LookDir;

        transform.position = Vector2.MoveTowards(transform.position, m_PatrolPoints[m_PatrolPointIndex].transform.position, m_MoveSpeed * Time.deltaTime);

        //if (BackWards == false)
        //{
        if (transform.position == m_PatrolPoints[m_PatrolPointIndex].transform.position)
        {
            RondKijken();
        }
        //}
        //else
        //{
        //    if (transform.position == m_PatrolPoints[m_PatrolPointIndex].transform.position)
        //    {
        //        m_PatrolPointIndex -= 1;
        //    }
        //}

        if (m_PatrolPointIndex == m_PatrolPoints.Length)
        {
            BackWards = true;
            m_PatrolPointIndex -= 1;
        }

        if (m_PatrolPointIndex <= 0)
        {
            BackWards = false;
            m_PatrolPointIndex = 0;
        }
    }
    void RondKijken()
    {
        Timer += Time.deltaTime;
        EndOfTimer = Random.Range(10, 20);

        z += Time.deltaTime * 3;

        transform.rotation = Quaternion.Euler(0, 0, z);

        if (Timer > EndOfTimer)
        {
            if (BackWards == false)
            {
                m_PatrolPointIndex += 1;
            }
            else
            {

                m_PatrolPointIndex -= 1;
            }
            Timer = 0;
        }
    }
}
