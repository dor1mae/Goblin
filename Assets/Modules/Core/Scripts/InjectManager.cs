using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InjectManager : MonoInstaller
{
    [SerializeField] private PlayerInput inputActions;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D bodyplayer;
    [SerializeField] private GameManager gameManager;

    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().FromInstance(inputActions);
        Container.Bind<GameObject>().FromInstance(player);
        Container.Bind<Rigidbody2D>().FromInstance(bodyplayer);
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
    }
}
