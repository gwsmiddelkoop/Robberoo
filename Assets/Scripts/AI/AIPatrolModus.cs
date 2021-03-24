using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolModus : MonoBehaviour
{
    [Header("Waypoint")]
    [SerializeField] public GameObject[] m_PatrolPoints;
    public float m_MoveSpeed;
    public int m_PatrolPointIndex;

    [Header("Modus")]
    public bool IsPatrolModus = true;
    private bool BackWards;

    [Header("WatchAround")]
    [SerializeField] private LayerMask m_Layer;
    public bool LeftOrRight;
    public bool islooking;
    private float Timer;
    private float Timer2;
    public float EndOfTimer;
    private float Zas;
    [SerializeField] private int[] m_WichSide;
    [SerializeField] private float[] m_WatchSpeed;
    private int m_WichSideIndex;
    private int m_WatchSpeedIndex;

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

        if (transform.position == new Vector3(m_PatrolPoints[m_PatrolPointIndex].transform.position.x, m_PatrolPoints[m_PatrolPointIndex].transform.position.y, transform.position.z))
        {
            RondKijken();
        }
        else
        {
            islooking = false;
        }

        for (int i = 0; i < m_WatchSpeed.Length; i++)
        {
            if(m_WatchSpeed[i] == 0)
            {
                m_WatchSpeed[i] = 5;
            }
        }

        if (m_PatrolPointIndex == m_PatrolPoints.Length)
        {
            BackWards = true;
            m_PatrolPointIndex -= 1;
            m_WichSideIndex -= 1;
            m_WatchSpeedIndex -= 1;
        }

        if (m_PatrolPointIndex <= 0)
        {
            BackWards = false;
            m_PatrolPointIndex = 0;
            m_WichSideIndex = 0;
            m_WatchSpeedIndex = 0;
        }
    }
    public void RondKijken()
    {
        islooking = true;
        Timer += Time.deltaTime;

        if (EndOfTimer == 0)
            EndOfTimer = Random.Range(10, 20);

        Zas += Time.deltaTime * m_WatchSpeed[m_WatchSpeedIndex];


        if (m_WichSide[m_WichSideIndex] == 1)
        {
            LeftOrRight = true;
        }
        else if (m_WichSide[m_WichSideIndex] == 2)
        {
            LeftOrRight = false;
        }

        if (LeftOrRight == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, Zas);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -Zas);
        }


        if (Timer > EndOfTimer)
        {
            if (BackWards == false)
            {
                m_PatrolPointIndex += 1;
                m_WichSideIndex += 1;
                m_WatchSpeedIndex += 1;
            }
            else
            {
                m_PatrolPointIndex -= 1;
                m_WichSideIndex -= 1;
                m_WatchSpeedIndex -= 1;
            }
            EndOfTimer = 0;
            Timer = 0;
            IsPatrolModus = true;
        }
    }
}

