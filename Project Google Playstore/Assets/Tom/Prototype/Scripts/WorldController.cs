using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateWorldSpeedDelegate(float _Speed);

public class WorldController : MonoBehaviour
{
    [SerializeField]
    private GameController _GameController;

    [SerializeField]
    private float _WorldSpeed;

    [SerializeField]
    private float _WorldAccelerationSpeed;

    [SerializeField]
    private float _SpeedUpdateInterval;

    [SerializeField]
    private PlayerController _Player;


    public event UpdateWorldSpeedDelegate UpdateWorldSpeedEvent;


    //Subscribes to the player.
    private void Start()
    {
        if(_Player != null)
        {
            _Player.PlayerDeadEvent += PlayerDead;
        }
        else
        {
            Debug.LogError(gameObject.name + " does not have an assigned player.");
        }

        if(_GameController != null)
        {
            _GameController.StartNewGameEvent += StartGame;
        }
        else
        {
            Debug.LogError(gameObject.name + " doesn't have a gamecontroller assigned.");
        }
    }


    //Start the invoking for the update of the accelerating objects.
    public void StartGame()
    {
        InvokeRepeating("UpdateSpeed", 0.0f, _SpeedUpdateInterval);
    }


    //Makes sure the speed accelerates.
    private void Update()
    {
        _WorldSpeed += _WorldAccelerationSpeed * Time.deltaTime;
    }


    //Updates the speed over all the accelerating objects.
    private void UpdateSpeed()
    {
        if (UpdateWorldSpeedEvent != null)
        {
            UpdateWorldSpeedEvent.Invoke(_WorldSpeed);
        }
    }


    //Gets called when the player dies.
    private void PlayerDead()
    {
        CancelInvoke("UpdateSpeed");
    }
}
