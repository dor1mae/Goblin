using Zenject;


public class Enemy : Creature
{

    public override void OnDeath()
    {
        Destroy(gameObject);
    }
}

