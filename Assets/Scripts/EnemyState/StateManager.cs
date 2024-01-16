using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateManager : FSM<StateManager>
{
    public NavMeshAgent m_navEnemy;
    public Transform m_target;
    public Transform m_spawnPoint;
    public Quaternion m_initialRot;

    [Header("이동 속도")]
    public float m_moveSpeed = 5f;
    [Header("회전 속도")]
    public float m_rotSpeed = 10f;
    [Header("복귀 속도")]
    public float m_returnSpeed = 10f;
    [Header("탐색 범위")]
    public float m_searchRange = 10f;
    [Header("추적 범위")]
    public float m_traceRange = 25f;

    [Header("공격 범위")]
    public float m_attackRange = 1f;
    public const float m_attackTime = 2f;
    public float m_lastAttackTime = 0f;

    private void Awake()
    {
        m_navEnemy = GetComponent<NavMeshAgent>();
        m_navEnemy.updateRotation = false;
        m_initialRot = transform.rotation;
    }

    private void Start()    { InitState(this, StateStay.Instance); }

    private void Update()    { FSMUpdate(); }


    public bool IsCloseToTarget(Vector3 targetPos, float range)
    {
        float dist = Vector3.SqrMagnitude(transform.position - targetPos);

        if (dist < range * range)
            return true;

        return false;
    }

    public void Move(Vector3 targetPos)
    {
        m_navEnemy.SetDestination(targetPos);
        m_navEnemy.speed = m_moveSpeed;
        m_navEnemy.stoppingDistance = 2f;
    }

    public void MoveReturn(Vector3 targetPos)
    {
        m_navEnemy.SetDestination(targetPos);
        m_navEnemy.speed = m_returnSpeed;
        m_navEnemy.stoppingDistance = 0f;
    }

    public void Rotate(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, m_rotSpeed * Time.deltaTime);
    }
}
