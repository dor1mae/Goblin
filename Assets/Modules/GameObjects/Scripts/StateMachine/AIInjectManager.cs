using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class AIInjectManager : MonoInstaller
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AIStateMachine ai;
    [SerializeField] private List<Transform> patrolPoints = new List<Transform>();
    [SerializeField] private Weapon Weapon;


    public override void InstallBindings()
    {
        Container.Bind<NavMeshAgent>().FromInstance(agent);
        Container.Bind<AIStateMachine>().FromInstance(ai);
        Container.Bind<List<Transform>>().FromInstance(patrolPoints);
        Container.Bind<Weapon>().FromInstance(Weapon);
    }
}
