using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDie : FSMSingleton<StateDie>, IFSMState<StateManager>
{
    public void Enter(StateManager e) { e.gameObject.SetActive(false); }

    public void Execute(StateManager e) { }

    public void Exit(StateManager e) { }
}
