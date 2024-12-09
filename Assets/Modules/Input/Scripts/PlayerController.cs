using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [Inject] private PlayerInput _inputCore;
    [Inject] private GameObject _player;

    private InputActionAsset _actions;
    private InputAction _move;
    private Vector2 _direction;
    [Inject] private Rigidbody2D _rigidBody;


    void Start()
    {
        _actions = _inputCore.actions;
        _move = _actions.FindAction("Move");

        _move.performed += WhenMoving;
        _move.canceled += WhenStop;
    }

    private void WhenStop(InputAction.CallbackContext obj)
    {
        _direction = Vector2.zero;
    }

    private void WhenMoving(InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<Vector2>();
    }

    private void RotateCamera()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - _player.transform.position;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        _player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }


    private void RaplaceTransform()
    {
        _rigidBody.velocity = _direction * _speed;
    }


    private void FixedUpdate()
    {
        RaplaceTransform();
        RotateCamera();
    }
}
