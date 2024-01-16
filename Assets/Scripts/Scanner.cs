using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Transform m_nearestTarget;

    public LayerMask m_targetLayer;
    public RaycastHit[] m_targets;

    public float m_scanRange;

    private void FixedUpdate()
    {
        m_targets = Physics.SphereCastAll(transform.position, m_scanRange, Vector3.zero, 0, m_targetLayer);
        m_nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;

        float dist = 100f;

        foreach (RaycastHit target in m_targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDist = Vector3.Distance(myPos, targetPos);

            if (curDist < dist)
            {
                dist = curDist;
                result = target.transform;
            }
        }

        return result;
    }
}
