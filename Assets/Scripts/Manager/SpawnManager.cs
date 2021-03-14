using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject m_Item;
    [SerializeField] private int m_ItemAmount;
    [SerializeField] private List<Transform> m_ItemSpawns;

    void Start()
    {
        for (int i = 0; i < m_ItemAmount; i++)
        {
            Transform chosenSpawn = m_ItemSpawns[Random.Range(0, m_ItemSpawns.Count)];
            Instantiate(m_Item, chosenSpawn.position, Quaternion.identity);
            m_ItemSpawns.Remove(chosenSpawn);
        }
    }

}
