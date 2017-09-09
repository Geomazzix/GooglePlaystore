using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

#region Inspector
    [Header("Layers")]
    [SerializeField]
    private LayerMask _ReflectLayer;
    
    [SerializeField]
    private LayerMask _PlayerBalls;

    [Header("Forces")]
    [SerializeField]
    private float _MoveSpeed = 10f;

    [Header("Angles")]
    [SerializeField]
    private float _StartAngleMin = 30f;
    [SerializeField]
    private float _StartAngleMax = 30f, _DirectionAngle = 0f;
    #endregion

#region Private members
    private float _CurrDirectionAngle;
#endregion


    //Set a starting direction.
    private void Start()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x, 
            Mathf.Round(Random.Range(transform.eulerAngles.y - _StartAngleMin, transform.eulerAngles.y + _StartAngleMax)), 
            transform.eulerAngles.z);
    }


    //Call all the updated player functions.
    private void Update()
    {
        MovePlayer();
        ReflectPlayer();
        AdjustPlayerDirection();
    }


    //Moves the player (made it for readability code).
    private void MovePlayer()
    {
        transform.Translate(transform.forward * _MoveSpeed * Time.deltaTime, Space.World);
    }


    //Checks if the player needs to reflect, if so then reflect him else ignore it.
    private void ReflectPlayer()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * _MoveSpeed + 0.5f, _ReflectLayer))
        {
            //Show the normal of the plane
            Debug.DrawRay(transform.position, transform.forward);

            //Reflect the electricity
           
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);

            //Calculate the turn of the electricity
            float rot = Mathf.Atan2(reflectDir.x, reflectDir.z) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
    }


    //Adjust the player direction to the direction he is supposed to be going.
    private void AdjustPlayerDirection()
    {
        transform.eulerAngles += new Vector3(0, _CurrDirectionAngle * Time.deltaTime, 0);
    }

    
    //Check when the player enters a player created ball, when entered check the distance and calculate the rotation circle.s
    private void OnTriggerEnter(Collider other)
    {
        //Make sure to fix the 9 to an appropraite layer.
        if (other.gameObject.layer == 9)
        {
            Vector3 coreSide = transform.position - other.transform.position;

            if (coreSide.x > 0)
            {
                //The x,y and z scale are all the same so I just use 1 here.
                _CurrDirectionAngle = other.transform.localScale.x * -_DirectionAngle;
            }
            else if (coreSide.x < 0)
            {
                //The x,y and z scale are all the same so I just use 1 here.
                _CurrDirectionAngle = other.transform.localScale.x * _DirectionAngle;
            }
            else
            {
                _DirectionAngle = 0f;
            }
        }
    }
}
