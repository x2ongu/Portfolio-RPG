using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateReturn : FSMSingleton<StateReturn>, IFSMState<StateManager>
{
    public void Enter(StateManager e) { Debug.Log("º¹±Í Áß..."); }

    public void Execute(StateManager e)
    {
        if (Vector3.Distance(e.m_spawnPoint.position, e.transform.position) > 0.1f)
        {
            e.MoveReturn(e.m_spawnPoint.position);
            e.Rotate(e.m_spawnPoint.position);
        }
        else
            e.ChangeState(StateStay.Instance);
    }

    public void Exit(StateManager e) { }
}
