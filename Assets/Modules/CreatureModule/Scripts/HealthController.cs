using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class HealthController : MonoBehaviour, IWait
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _timeToBeUntouchable = 1;
    private bool _isDamaged = false;
    public Action<float> HealthChanged;
    private Action OnDeath;

    private Creature _creature;

    public bool IsDamaged => _isDamaged;

    private void Start()
    {
        _creature = GetComponent<Creature>();
        //OnDeath += _creature.OnDeath;
    }

    public void AddHealth(float health)
    {
        if(_health + health <= _maxHealth)
        {
            _health += health;

            HealthChanged?.Invoke(_health);
        }
        else
        {
            _health = _maxHealth;

            HealthChanged?.Invoke(_health);
        }
    }

    public float GetHealth() => _health;

    public void RemoveHealth(float health)
    {
        if(_health - health > 0)
        {
            _health -= health;

            StartCoroutine(Wait(_timeToBeUntouchable));
            HealthChanged?.Invoke(_health);
        }
        else
        {
            OnDeath.Invoke();
        }
    }

    public IEnumerator Wait(int seconds)
    {
        _isDamaged = true;

        yield return new WaitForSeconds(seconds);

        _isDamaged = false;
    }
}
