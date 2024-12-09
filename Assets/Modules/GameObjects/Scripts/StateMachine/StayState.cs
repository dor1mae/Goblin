using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class StayState : State, IWait
{
    public override string Name => "stay";
    private bool _isComplete = false;
    [Inject] private GameObject _player;

    public override void Enter(AIStateMachine ai)
    {
        base.Enter(ai);

        StartCoroutine(Wait(5));
    }

    public override void Exit()
    {
        _isComplete = false;
    }

    public override void StateAction()
    {
        if(_isComplete)
        {
            _parent.ChangeState("patrol");
        }
    }

    public IEnumerator Wait(int seconds)
    {
        Debug.Log("Ожидание");

        yield return new WaitForSeconds(Random.Range(2, seconds));

        _isComplete = true;
    }
}