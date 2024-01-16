using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ItemData[] m_itemDatas;
    public GoldData m_gold;
    public Transform m_spawnPoint;
    public float m_damage = 5f;
    private int m_maxHp = 20;
    private int m_curHp;

    private void Awake()
    {
        m_curHp = m_maxHp;
    }

    private void OnEnable()
    {
        m_curHp = m_maxHp;
    }

    public void TakeDamage(float damage)
    {
        if (m_curHp > 0)
        {
            m_curHp -= Mathf.RoundToInt(damage);
            Debug.Log("������ " + Mathf.RoundToInt(damage) + "�� ����!!");
            Debug.Log("�� ���� ü�� : " + m_curHp);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Inst.m_spawner.m_spawnPointList.Add(m_spawnPoint);
        gameObject.SetActive(false);
        m_itemDatas[0].WhenTheItemDrops();
        m_itemDatas[1].WhenTheItemDrops();
    }
}
