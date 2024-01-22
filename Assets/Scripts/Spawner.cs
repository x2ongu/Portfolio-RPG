using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_spawnPoints;
    public List<Transform> m_spawnPointList = new List<Transform>();

    private void Awake()
    {
        m_spawnPoints = GetComponentsInChildren<Transform>();
        m_spawnPointList.AddRange(m_spawnPoints);
    }

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (m_spawnPointList.Count == 1)
            {
                Debug.Log("No available spawn points.");
                return;
            }
            Spawn(3);
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.Inst.m_pool.Get(0);

        enemy.SetActive(true);

        int num = Random.Range(1, m_spawnPointList.Count);

        Transform spawnPoint = m_spawnPointList[num];

        enemy.transform.position = spawnPoint.position;

        enemy.GetComponent<Enemy>().m_spawnPoint = spawnPoint;

        enemy.GetComponent<StateManager>().m_spawnPoint = spawnPoint;

        enemy.GetComponent<StateManager>().m_target = GameManager.Inst.m_player.transform;

        m_spawnPointList.RemoveAt(num);
    }

    void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }
}
