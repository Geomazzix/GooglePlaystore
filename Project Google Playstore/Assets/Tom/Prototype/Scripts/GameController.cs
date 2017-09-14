using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StartNewGameDelegate();

public class GameController : MonoBehaviour
{
    public event StartNewGameDelegate StartNewGameEvent;


    //Make sure it doesn't get destroyed on load.
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Invoke("StartGame", 1f);
    }

    //Gets called when a new game is supposed to be instantiated.
    public void StartGame()
    {
        StartNewGameEvent.Invoke();
    }
}
