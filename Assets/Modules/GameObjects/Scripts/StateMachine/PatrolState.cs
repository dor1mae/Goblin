using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PatrolState : State
{
    [Inject] private List<Transform> _patrolPoints;
    private Transform _point;
    private bool _isComplete = false;


    public override string Name => "patrol";


    public override void Enter(AIStateMachine ai)
    {
        base.Enter(ai);
        _ai.updateRotation = false;
        _ai.updateUpAxis = false; 

        ChangePoint(Random.Range(0, _patrolPoints.Count));
        _ai.SetDestination(new Vector2(_point.position.x, _point.position.y));
    }

    public override void Exit()
    {
        _isComplete = false;
    }

    public override void StateAction()
    {
        if (_ai.velocity.sqrMagnitude > 0.1f)
        {
            RotateTowardsMovementDirection();
        }
        if (_isComplete)
        {
            _parent.ChangeState("stay");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "point")
        {
            Debug.Log($"{this.name} достиг точки");
            _isComplete = true;
        }
    }

    private void ChangePoint(int index)
    {
        if(_point != _patrolPoints[index])
        {
            _point = _patrolPoints[index];
        }
        else
        {
            if(index + 1 < _patrolPoints.Count)
            {
                _point = _patrolPoints[index + 1];
            }
            else
            {
                _point = _patrolPoints[index - 1];
            }
        }
    }
}
