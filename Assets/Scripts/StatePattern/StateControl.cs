using UnityEngine;

public abstract class StateControl<T> : MonoBehaviour where T:Component
{
    protected IState _currentState;

    protected virtual void Awake()
    {
        InitializeStates();
    }

    protected abstract void InitializeStates();

    public void UpdateState(IState newState)
    {
        if (_currentState != null) _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState(this as T);
    }
}