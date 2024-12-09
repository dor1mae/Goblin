using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _topBody;
    [SerializeField] private Animator _bottomBody;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _creature;

    private void Start()
    {
        _weapon.OnAttack += AttackAnimation;
    }

    private void FixedUpdate()
    {
        if (_rigidBody.velocity != new Vector2(0, 0))
        {
            _bottomBody.SetBool("isWalk", true);
            RotateTowardsMovementDirection();
        }
        else 
        { 
            _bottomBody.SetBool("isWalk", false);
            ResetRotation();
        }
    }

    private void RotateTowardsMovementDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - _creature.transform.position;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        Vector3 direction2 = _rigidBody.velocity.normalized;

        float angle2 = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;

        _bottomBody.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2 + 270));
    }

    private void ResetRotation()
    {
        _bottomBody.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void AttackAnimation(float time)
    {
        _topBody.PlayInFixedTime("Attack", 1, time);
    }
}
