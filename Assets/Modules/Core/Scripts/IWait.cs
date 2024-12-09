using System.Collections;

public interface IWait
{
    public abstract IEnumerator Wait(int seconds);
}