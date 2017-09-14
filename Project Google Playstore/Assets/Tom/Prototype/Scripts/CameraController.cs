using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private WorldController _WorldController;

    [Tooltip("DO NOT CHANGE FOR DEBUG PURPOSES ONLY.")]
    [SerializeField]
    private float _MoveSpeed;


    //Subscribe the camera to the world controller so it will move.
    private void Start()
    {
        if(_WorldController != null)
        {

        }
        else
        {
            Debug.LogError(gameObject.name + " CameraController doesn't have a WorldController.");
        }
        _WorldController.UpdateWorldSpeedEvent += UpdateSpeed;
    }


    //Move the camera forward.
    private void Update()
    {
        transform.Translate(Vector3.up * _MoveSpeed * Time.deltaTime);
    }


    //Updates the speed to the speed of the worldcontroller.
    private void UpdateSpeed(float speed)
    {
        _MoveSpeed = speed;
    }
}
