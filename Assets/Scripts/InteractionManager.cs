using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject m_nearestObj;

    private INPC m_iNpc; 

    public float m_npcInterRad = 5f;    // NPC Interaction Radius
    public float m_teleInterRad = 2f;   // Teleport Interaction Radius(맵 이동시 필요한건데 일단 나중을 위해)

    public string m_npcInterTag = "NPC";    // NPC Interaction Tag

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_npcInterRad);

        if (colliders.Length > 0)
        {
            m_nearestObj = FindNearestObj(colliders);
        }
    }

    public void ReturnSelectedNPC()
    {
        if (m_nearestObj == null)
            return;

        m_iNpc = m_nearestObj.GetComponent<INPC>();
        m_iNpc.DoInteraction();
    }

    GameObject FindNearestObj(Collider[] colls)
    {
        GameObject nearestObj = null;
        float nearestDist = 100f;

        foreach(Collider coll in colls)
        {
            if (coll.CompareTag(m_npcInterTag))
            {
                float dist = Vector3.Distance(transform.position, coll.transform.position);

                if (dist < nearestDist)
                {
                    nearestDist = dist;
                    nearestObj = coll.gameObject;
                }
            }
        }

        if (nearestObj == null)
        {
            Debug.Log("No nearest object found.");
        }

        return nearestObj;
    }
}
