using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_spawnPoint;
    public List<Transform> m_tempList;
    private List<int> m_availableNum;

    private void Awake()
    {
        m_spawnPoint = GetComponentsInChildren<Transform>();
        m_tempList = new List<Transform>(m_spawnPoint);
    }

    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            Spawn();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (m_spawnPoint.Length <= 1)
            //    return;

                Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.Inst.m_pool.Get(0);

        int num = Random.Range(1, m_spawnPoint.Length);

        enemy.transform.position = m_spawnPoint[num].position;

        enemy.GetComponent<StateManager>().m_spawnPoint = m_spawnPoint[num];

        enemy.GetComponent<StateManager>().m_target = GameManager.Inst.m_player.transform;
    }
}
