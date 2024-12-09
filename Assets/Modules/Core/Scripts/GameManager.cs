using System.Collections;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private int _timeToWait = 5;
    private int _sceneIndex;


    private void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_timeToWait);

        SceneManager.LoadScene(_sceneIndex);
    }
}
