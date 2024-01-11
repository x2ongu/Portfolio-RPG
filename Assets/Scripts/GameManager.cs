using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_inst;
    public static GameManager Inst
    { 
        get
        {
            if (m_inst == null)
            {
                m_inst = FindObjectOfType<GameManager>();

                if (m_inst == null)
                {
                    GameObject singletonObj = new GameObject("Game Manager");
                    m_inst = singletonObj.AddComponent<GameManager>();
                }
            }
            return m_inst;
        }
    }

    public Player m_player;
    public Enemy m_enemy;
    public PoolManager m_pool;
    public Spawner m_spawner;

    private void Awake()
    {
        if (m_inst == null)
            m_inst = this;
    }
}
