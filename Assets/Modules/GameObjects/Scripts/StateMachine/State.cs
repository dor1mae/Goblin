using UnityEngine;
using UnityEngine.AI;
using Zenject;
using static UnityEngine.GraphicsBuffer;

public abstract class State : MonoBehaviour, IState
{
    [Inject] protected NavMeshAgent _ai;
    protected AIStateMachine _parent;

    public abstract string Name { get; }

    public virtual void Enter(AIStateMachine ai)
    {
        _parent = ai;
    }

    public abstract void Exit();
    public abstract void StateAction();

    protected void Rotate(Transform transformO)
    {
        Vector2 direction = transformO.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _ai.gameObject.transform.rotation = rotation;
    }

    protected void RotateTowardsMovementDirection()
    {
        Vector3 direction = _ai.velocity.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _ai.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}