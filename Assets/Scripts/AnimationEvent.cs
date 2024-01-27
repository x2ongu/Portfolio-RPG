using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public Animator m_anim;

    Vector3 m_rollPoint;
    Vector3 m_attackPoint;

    public bool m_isContinueComboAttack;
    public bool m_isMove;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();

        m_isContinueComboAttack = false;
        m_isMove = true;
    }

    private void LateUpdate()
    {
        if (m_anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f)
        {
            m_anim.SetLayerWeight(1, 0);
        }
    }

    public void CheckStartComboAttack()
    {
        m_isContinueComboAttack = false;
    }
    public void CheckEndComboAttack()
    {
        if (!m_isContinueComboAttack)
        {

        }
    }

    public void RollFowardStart()
    {
        m_anim.speed = 1.4f;
        m_isMove = false;
        Roll();
    }

    public void RollFowardEnd()
    {
        m_anim.speed = 1f;
        m_anim.SetFloat("Speed", 0f);
        m_isMove = true;
        GameManager.Inst.m_player.m_navAgent.speed = GameManager.Inst.m_player.m_speed;
    }

    private void Roll()
    {
        Ray ray = GameManager.Inst.m_player.m_mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            GameManager.Inst.m_player.m_navAgent.ResetPath();

            m_rollPoint = raycastHit.point;
            m_rollPoint.y += 0.092f;
        }

        Vector3 dir = m_rollPoint - transform.position;
        Debug.Log("���콺 ��ġ : " + m_rollPoint + " / �÷��̾� ��ġ : " + transform.position);
        Vector3 dest = transform.position + dir.normalized * GameManager.Inst.m_player.m_rollDist;
        Debug.Log("���콺 dir.normalized : " + dir.normalized + " / dest : " + dest);

        GameManager.Inst.m_player.m_navAgent.SetDestination(dest);
        GameManager.Inst.m_player.m_navAgent.speed = GameManager.Inst.m_player.m_rollSpeed;
    }

    private void Attack()
    {
        Ray ray = GameManager.Inst.m_player.m_mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            GameManager.Inst.m_player.m_navAgent.ResetPath();
            m_attackPoint = raycastHit.point;
        }

        Vector3 dir = m_attackPoint - transform.position;
        Vector3 dest = transform.position + dir.normalized * 0.5f;
        GameManager.Inst.m_player.transform.forward = dest;
        GameManager.Inst.m_player.m_navAgent.SetDestination(dest);
    }
}