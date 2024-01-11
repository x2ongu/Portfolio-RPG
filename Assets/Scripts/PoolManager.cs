using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class PoolingUnit
    {
        public GameObject m_prefab;
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

    public GameObject Get(int i)
    {
        GameObject selectedObj = null;

        foreach (GameObject obj in m_poolList[i])
        {
            if(!obj.activeSelf)
            {
                selectedObj = obj;
                selectedObj.SetActive(true);
                break;
            }
        }

        if(selectedObj == null)
        {
            selectedObj = Instantiate(m_poolingUnits[i].m_prefab, transform);
            m_poolList[i].Add(selectedObj);
        }

        return selectedObj;
    }

    //void AddToPooledUnitList(int i, GameObject newItem)
    //{
    //    newItem.SetActive(false);

    //    newItem.transform.parent = transform;

    //    m_poolList[i].Add(newItem);
    //}

    //GameObject Get(string pooledObjName)
    //{
    //    for(int i = 0; i < m_poolingUnits.Length; i++)
    //    {
    //        if (m_poolingUnits[i].m_prefab.name == pooledObjName)
    //        {
    //            int listIndex;

    //            for (listIndex = 0; listIndex < m_poolList[i].Count; listIndex++)
    //            {
    //                if (m_poolList[i][listIndex] == null)
    //                {
    //                    return null;
    //                }

    //                if (m_poolList[i][listIndex].activeInHierarchy == false)
    //                {
    //                    return m_poolList[i][listIndex];
    //                }
    //            }

    //            if (m_canExpand)
    //            {
    //                GameObject tmp = (GameObject)Instantiate(m_poolingUnits[i].m_prefab);

    //                AddToPooledUnitList(i, tmp);

    //                return tmp;
    //            }
    //            break;
    //        }
    //    }
    //    return null;
    //}
}
