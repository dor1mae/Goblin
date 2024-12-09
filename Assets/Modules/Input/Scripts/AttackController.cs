using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class AttackController : MonoBehaviour
{
    private Weapon weapon;
    [Inject] private PlayerInput inputActions;
    private InputAction _inputAction;

    private void Start()
    {
        weapon = GetComponentInChildren<Weapon>();

        _inputAction = inputActions.actions.FindAction("Attack");
        _inputAction.started += Attack;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        weapon.Attack();
    }
}