using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStay : FSMSingleton<StateStay>, IFSMState<StateManager>
{
    public void Enter(StateManager e)
    {
        e.transform.rotation = e.m_initialRot;
        Debug.Log("플레이어가 오길 기다리는 중...");
    }

    public void Execute(StateManager e)
    {
        if (e.m_target != null)
        {
            if (e.IsCloseToTarget(e.m_target.position, e.m_searchRange))
                e.ChangeState(StateTrace.Instance);
        }
    }

    public void Exit(StateManager e) { Debug.Log("찾았다!!"); }
}
