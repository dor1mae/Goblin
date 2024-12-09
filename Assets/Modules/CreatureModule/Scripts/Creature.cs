using UnityEngine;
using Zenject;

[RequireComponent(typeof(HealthController))]
public abstract class Creature: MonoBehaviour
{
    protected HealthController healthController;
    protected AttackController attackController;
    protected Transform selfTransform;

    public HealthController Health => healthController;

    private void Start()
    {
        selfTransform = GetComponentInParent<Transform>();
    }


    public virtual void OnDeath()
    {
    }
}
