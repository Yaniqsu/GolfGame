using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachine sc;

    public void OnStateEnter(StateMachine stateController)
    {
        sc = stateController;
        OnEnter();
    }

    protected virtual void OnEnter() 
    {
        foreach (GameEventListener listener in GetComponents<GameEventListener>())
            listener.enabled = true;
    }

    public void OnStateUpdate()
    {
        OnUpdate();
    }

    protected virtual void OnUpdate() { }

    public void OnStateHurt()
    {
        OnHurt();
    }

    protected virtual void OnHurt() { }

    public void OnStateExit()
    {
        OnExit();
    }

    protected virtual void OnExit() 
    {
        foreach (GameEventListener listener in GetComponents<GameEventListener>())
            listener.enabled = false;
    }
}
