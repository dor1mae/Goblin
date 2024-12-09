using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;


public class AIDetector : MonoBehaviour
{
    [SerializeField] private int _timeOfDetection = 10;
    [Inject] private AIStateMachine stateMachine;
    private Coroutine _coroutine;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && stateMachine.CurrentState.Name != "attack")
        {   
            if( _coroutine == null )
            {
                _coroutine = StartCoroutine(Wait());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && stateMachine.CurrentState.Name != "attack")
        {
            Debug.Log($"{gameObject.name} прерывает таймер");

            StopCoroutine( _coroutine );
            _coroutine = null;

            stateMachine.ChangeState("stop");
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds( _timeOfDetection );

        Debug.Log("Попытка атаковать");
        stateMachine.ChangeState("attack");
    }
}
