using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrace : FSMSingleton<StateTrace>, IFSMState<StateManager>
{
    public void Enter(StateManager e) { Debug.Log("추적 개시..."); }

    public void Execute(StateManager e)
    {
        if (e.IsCloseToTarget(e.m_spawnPoint.position, e.m_traceRange))
        {
            e.Move(e.m_target.position);
            e.Rotate(e.m_target.position);

            if (e.IsCloseToTarget(e.m_target.position, e.m_attackRange))
                e.ChangeState(StateAttack.Instance);
        }
        else
            e.ChangeState(StateReturn.Instance);
    }

    public void Exit(StateManager e) { }
}
