using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine {
    private State _CurrentState;

    public void SetState(State state)
    {
        if(_CurrentState != null)
        {
            _CurrentState.Exit();
        }

        _CurrentState = state;

        if(_CurrentState != null)
        {
            _CurrentState.Enter();
        }
    }

    public void Update()
    {
        if(_CurrentState != null)
        {
            _CurrentState.Update();
        }
    }

}
