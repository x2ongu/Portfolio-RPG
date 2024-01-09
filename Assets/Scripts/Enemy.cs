using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float m_damage = 5f;
    private int m_maxHp = 20;
    private int m_curHp;

    private void Awake()
    {
        m_curHp = m_maxHp;
    }

    public void TakeDamage(float damage)
    {
        if (m_curHp > 0)
        {
            m_curHp -= Mathf.RoundToInt(damage);
            Debug.Log("적에게 " + Mathf.RoundToInt(damage) + "의 피해!!");
            Debug.Log("적 남은 체력 : " + m_curHp);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
