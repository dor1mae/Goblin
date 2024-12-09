using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private int Speed = 1;
    [SerializeField] private int Damage = 50;
    private Animator _animator;
    private bool _isEnemy = false;

    [Inject] private Creature _creature;

    public Action<float> OnAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if(_creature is Enemy) _isEnemy = true;
    }

    public void Attack()
    {
        Debug.Log("ATTACK!");
        OnAttack?.Invoke(Speed);
        PlayAnimation("Attack");
    }

    private void PlayAnimation(string clip)
    {
        if (clip != null && _animator != null)
        {
            _animator.PlayInFixedTime(clip, 1, Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.attachedRigidbody.GetComponentInChildren<HealthController>();

        if (enemy != null && enemy != _creature.Health && _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !enemy.IsDamaged)
        {
            if(!(_isEnemy && collision.gameObject.GetComponent<Creature>() is Enemy))
            {
                enemy.RemoveHealth(Damage);
            }
        }
    }
}