using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Vector3 m_movePoint;

    private float m_attacktime = -float.MaxValue;
    private float m_rollTime = -float.MaxValue;

    public void GetKey_MouseLeft()
    {
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    GameManager.Inst.m_player.m_animEvent.m_anim.SetTrigger("Attack");
        //    m_attacktime = 0f;
        //}

        m_attacktime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (m_attacktime > GameManager.Inst.m_player.m_attackRate || m_attacktime < 0f)
            {
                GameManager.Inst.m_player.m_animEvent.m_anim.SetTrigger("Attack");
                m_attacktime = 0f;
            }
        }
    }

    public void GetKey_MouseRight()
    {
        if (Input.GetKey(KeyCode.Mouse1) && GameManager.Inst.m_player.m_animEvent.m_isMove)
        {
            Ray ray = GameManager.Inst.m_player.m_mainCam.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                m_movePoint = raycastHit.point;

                if (Vector3.Distance(transform.position, m_movePoint) > 0.1f)
                {
                    GameManager.Inst.m_player.m_navAgent.SetDestination(m_movePoint);
                    GameManager.Inst.m_player.m_animEvent.m_anim.SetFloat("Speed", GameManager.Inst.m_player.m_speed);
                }
            }
        }
    }

    public void GetKeyDown_Space()
    {
        m_rollTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_rollTime > GameManager.Inst.m_player.m_rollDuration || m_rollTime < 0f)
            {
                GameManager.Inst.m_player.m_animEvent.m_anim.SetTrigger("Roll");
                m_rollTime = 0f;
            }
        }
    }

    public void GetKeyDown_G()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameManager.Inst.m_player.m_interManager.ReturnSelectedNPC();
        }
    }
}
