using Zenject;
using UnityEngine;

public class GameCreatureInjectManager : MonoInstaller
{
    [SerializeField] private Creature creature;


    public override void InstallBindings()
    {
        Container.Bind<Creature>().FromInstance(creature);
    }
}
