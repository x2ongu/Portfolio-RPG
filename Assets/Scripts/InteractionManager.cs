using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    NPC m_npc;
    public GameObject m_nearestObj;
    public NPCType m_npcType;

    public float m_npcInterRad = 5f;    // NPC Interaction Radius
    public float m_teleInterRad = 2f;   // Teleport Interaction Radius(�� �̵��� �ʿ��Ѱǵ� �ϴ� ������ ����)

    public string m_npcInterTag = "NPC";    // NPC Interaction Tag

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_npcInterRad);

        if (colliders.Length > 0)
        {
            m_nearestObj = FindNearestObj(colliders);
        }
    }

    public void InteractWithNPC()
    {
        switch (m_npcType)
        {
            case NPCType.MainQuestNPC:
                Debug.Log("��������Ʈ �Դϴ�.");
                break;
            case NPCType.RepaetQuestNPC:
                Debug.Log("�ݺ�����Ʈ �Դϴ�.");
                break;
            case NPCType.EquipmentMerchant:
                Debug.Log("������ �Դϴ�.");
                break;
            case NPCType.ItemMerchant:
                Debug.Log("��ȭ���� �Դϴ�.");
                break;
        }
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
                    m_npcType = nearestObj.GetComponent<NPC>().m_npcType;
                }
            }
        }

        return nearestObj;
    }
}
