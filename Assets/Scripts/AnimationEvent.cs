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

    public bool m_isAttack;
    public bool m_isMove;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();

        m_isAttack = false;
        m_isMove = true;
    }

    private void LateUpdate()
    {
        if (m_anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f)
        {
            m_anim.SetLayerWeight(1, 0);
        }
    }

    public void SetAttackAnimationSpeed()
    {
        m_anim.speed = 2f;
    }

    public void CheckEndIsAttack()
    {
        m_isAttack = false;
    }

    public void CheckStartComboAttack()
    {
        m_anim.SetBool("Combo", true);
        m_anim.SetBool("IsReadyToAttack", true);

        m_isAttack = true;

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

    public void RollFowardStart()
    {
        m_anim.speed = 1.4f;
        m_isMove = false;
        StartCoroutine(Roll());
    }

    public void RollFowardEnd()
    {
        m_anim.speed = 1f;
        m_anim.SetFloat("Speed", 0f);
        m_isMove = true;
        GameManager.Inst.m_player.m_navAgent.speed = GameManager.Inst.m_player.m_speed;
    }
    
    public void Attack()
    {
        Ray ray = GameManager.Inst.m_player.m_mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            m_attackPoint = raycastHit.point;
            m_attackPoint.y = transform.position.y;
        }

        Vector3 dir = m_attackPoint - transform.position;
        Vector3 dest = transform.position + dir.normalized * 10f;

        if (!m_isAttack)
        {
            GameManager.Inst.m_player.transform.forward = dest; // 이렇게 정면을 관리하면 순간이동 함...
            GameManager.Inst.m_player.m_navAgent.SetDestination(dest);
        }
    }

    private IEnumerator Roll()
    {
        Ray ray = GameManager.Inst.m_player.m_mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Pivot")))
        {
            m_rollPoint = raycastHit.point;
            m_rollPoint.y = transform.position.y;

            Ray fixedRay = new Ray(raycastHit.point, -Vector3.up);
            Debug.DrawRay(fixedRay.origin, fixedRay.direction * 100f, Color.magenta);

            if (Physics.Raycast(fixedRay, out RaycastHit fixedRaycast, Mathf.Infinity, LayerMask.GetMask("Pivot")))
            {
                m_rollPoint = fixedRaycast.point;
                m_rollPoint.y = transform.position.y;
            }
            
        }

        Vector3 dir = m_rollPoint - transform.position;
        Debug.Log("마우스 위치 : " + m_rollPoint + " / 플레이어 위치 : " + transform.position);
        Vector3 dest = transform.position + dir.normalized * GameManager.Inst.m_player.m_rollDist;
        Debug.Log("마우스 dir.normalized : " + dir.normalized + " / dest : " + dest);

        GameManager.Inst.m_player.m_navAgent.SetDestination(dest);
        GameManager.Inst.m_player.m_navAgent.speed = GameManager.Inst.m_player.m_rollSpeed;

        yield return null;

        //float dist = Vector3.Distance(transform.position, dest);
        //Debug.Log("dist : " + dist + " / 남은 거리 : " + GameManager.Inst.m_player.m_navAgent.remainingDistance);
        //if (dist + 0.1f <= GameManager.Inst.m_player.m_navAgent.remainingDistance)
        //{
        //    GameManager.Inst.m_player.m_navAgent.ResetPath();
        //}
    }

    IEnumerator IsReadyToAttack()
    {
        yield return new WaitForSeconds(10f);

        m_anim.SetBool("IsReadyToAttack", false);
        m_anim.Play("Disarm", 1, 0f);
        m_anim.SetLayerWeight(1, 1);
    }
}
