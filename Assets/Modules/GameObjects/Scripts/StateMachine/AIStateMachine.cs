using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    private List<IState> states = new List<IState>();

    private IState _currentState;

    public IState CurrentState => _currentState;

    private void Start()
    {
        states.AddRange(GetComponentsInChildren<State>());
        Debug.Log($"AIStateMachine собрал {states.Count} states");

        ChangeState(states[0]);
    }

    private void FixedUpdate()
    {
        _currentState.StateAction();
    }

    public void ChangeState(IState state)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = state;

        _currentState.Enter(this);
    }

    public void ChangeState(string state)
    {
        if (states.Find((x) => x.Name == state) != null)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = states.Find((x) => x.Name == state);

            _currentState.Enter(this);
        }
    }
}
