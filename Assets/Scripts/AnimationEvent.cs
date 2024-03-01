using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationEvent : MonoBehaviour
{
    public Animator m_anim;
    Coroutine m_coroutine;

    Vector3 m_rollPoint;
    Vector3 m_attackPoint;
    Vector3 m_attackMousePoint;

    public bool m_isMove;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();

        m_isMove = true;
    }

    private void LateUpdate()
    {
        if (m_anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f)
        {
            m_anim.SetLayerWeight(1, 0);
        }
    }


    public void Attack()
    {
        Ray ray = GameManager.Inst.m_player.m_mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit groundHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            m_attackMousePoint = groundHit.point;
            m_attackMousePoint.y = transform.position.y;
        }
        else if (Physics.Raycast(ray, Mathf.Infinity, LayerMask.GetMask("BackGround")))
        {
            if (Physics.Raycast(ray, out RaycastHit pivotHit, Mathf.Infinity, LayerMask.GetMask("Pivot")))
            {
                m_attackMousePoint = pivotHit.point;
                m_attackMousePoint.y = transform.position.y;
            }
        }

        Vector3 dir = m_attackMousePoint - transform.position;
        m_attackPoint = transform.position + dir.normalized * 10f;
    }
    public void CheckStartComboAttack()
    {
        m_anim.SetBool("Combo", true);
        m_anim.SetBool("IsReadyToAttack", true);

        m_anim.speed = 2f;
        m_isMove = false;

        GameManager.Inst.m_player.transform.forward = m_attackPoint; // 이렇게 정면을 관리하면 순간이동 함... 근데 해도 될 듯?

        if (m_coroutine != null)
            StopCoroutine(m_coroutine);
    }
    public void CheckEndComboAttack()
    {
        m_anim.speed = 1f;
        m_anim.SetBool("Combo", false);

        m_isMove = true;

        m_coroutine = StartCoroutine(IsReadyToAttack());
    }            
    IEnumerator IsReadyToAttack()
    {
        yield return new WaitForSeconds(10f);

        m_anim.SetBool("IsReadyToAttack", false);
        m_anim.Play("Disarm", 1, 0f);
        m_anim.SetLayerWeight(1, 1);
    }


    public void Roll()
    {
        m_isMove = false;
        GameManager.Inst.m_player.m_navAgent.speed = GameManager.Inst.m_player.m_rollSpeed;

        Ray ray = GameManager.Inst.m_player.m_mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit groundHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            m_rollPoint = groundHit.point;
            m_rollPoint.y = transform.position.y;
            Debug.Log("Ground Hit");
        }
        else if (Physics.Raycast(ray, Mathf.Infinity, LayerMask.GetMask("BackGround")))
        {
            Debug.Log("BackGround Hit");
            if (Physics.Raycast(ray, out RaycastHit pivotHit, Mathf.Infinity, LayerMask.GetMask("Pivot")))
            {
                m_rollPoint = pivotHit.point;
                m_rollPoint.y = transform.position.y;
                Debug.Log("Pivot Hit");
            }
        }

        Vector3 rollDir = (m_rollPoint - transform.position).normalized;
        Vector3 rollDest = transform.position + rollDir * GameManager.Inst.m_player.m_rollDist;

        GameManager.Inst.m_player.m_navAgent.SetDestination(rollDest);
    }
    public void RollFowardStart()
    {
        m_anim.speed = 1.4f;
    }
    public void RollFowardEnd()
    {
        GameManager.Inst.m_player.m_navAgent.speed = GameManager.Inst.m_player.m_speed;
        m_anim.speed = 1f;
        m_anim.SetFloat("Speed", 0f);
        m_isMove = true;
    }
}