using Zenject;

public class Player : Creature
{
    public AttackController Attack => attackController;


    public override void OnDeath()
    {

    }
}
