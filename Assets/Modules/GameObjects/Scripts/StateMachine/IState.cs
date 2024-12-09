public interface IState
{
    public abstract string Name { get; }
    public abstract void Enter(AIStateMachine ai);
    public abstract void StateAction();
    public abstract void Exit();
}
