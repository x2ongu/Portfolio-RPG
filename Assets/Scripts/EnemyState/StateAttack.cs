using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : FSMSingleton<StateAttack>, IFSMState<StateManager>
{
    public void Enter(StateManager e) { Debug.Log("공격 개시..."); }

    public void Execute(StateManager e)
    {
        if (e.IsCloseToTarget(e.m_target.position, e.m_attackRange))
        {
            if (Time.time > e.m_lastAttackTime + StateManager.m_attackTime)
            {
                GameManager.Inst.m_player.TakeDamage(GameManager.Inst.m_enemy.m_damage);
                e.m_lastAttackTime = Time.time;
            }
        }
        else
            e.ChangeState(StateTrace.Instance);
    }

    public void Exit(StateManager e) { Debug.Log("공격 종료..."); }
}
