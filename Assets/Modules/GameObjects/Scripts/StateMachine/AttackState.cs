using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;


public class AttackState : State, IWait
{
    [SerializeField] private int _timeOfAttack = 5;
    public override string Name => "attack";
    private Coroutine coroutine;
    [Inject] private GameObject _player;

    public override void Enter(AIStateMachine ai)
    {
        base.Enter(ai);

        _ai.destination = _player.transform.position;
    }


    public override void Exit()
    {
        //
    }

    public override void StateAction()
    {
        _ai.destination = _player.transform.position;

        RotateTowardsMovementDirection();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            coroutine = StartCoroutine(Wait(_timeOfAttack));
        }
    }

    public IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(_timeOfAttack);

        _parent.ChangeState("stop");
    }
}

