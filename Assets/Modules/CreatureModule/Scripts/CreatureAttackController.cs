using UnityEngine;
using Zenject;


public class CreatureAttackController : MonoBehaviour
{
    [Inject] private Weapon _weapon;

    public void Attack()
    {
        _weapon.Attack();
    }
}
