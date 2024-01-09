using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class PoolingUnit
    {
        GameObject m_prefab;
        public int m_amount;
        private int m_curAmount;
        public int CurAmount
        {
            get { return m_curAmount; }
            set { m_curAmount = value; }
        }
    }

    public PoolingUnit[] m_poolingUnits;
    public List<GameObject>[] m_poolList;

    public int m_defualtAmount = 10;

    public bool m_canExpand = true;    

    private void Awake()
    {
        m_poolList = new List<GameObject>[m_poolingUnits.Length];

        for (int i = 0; i < m_poolingUnits.Length; i++)
        {
            m_poolList[i] = new List<GameObject>();

            if (m_poolingUnits[i].m_amount > 0)
            {
                m_poolingUnits[i].CurAmount = m_poolingUnits[i].m_amount;
            }
            else
            {
                m_poolingUnits[i].CurAmount = m_defualtAmount;
            }
        }
    }

}
