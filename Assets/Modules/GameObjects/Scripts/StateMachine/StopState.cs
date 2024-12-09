using System.Collections;
using UnityEngine;
using Zenject;



public class StopState : State, IWait
{
    public override string Name => "stop";
    [Inject] private GameObject player;
    private bool _isComplete = false;
    private Coroutine _coroutine;


    public override void Enter(AIStateMachine ai)
    {
        base.Enter(ai);

        Rotate(player.transform);
        _ai.destination = this.gameObject.transform.position;

        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(Wait(5));
        }
    }

    public override void Exit()
    {
        _isComplete = false;

        StopCoroutine(_coroutine);
        _coroutine = null;
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
