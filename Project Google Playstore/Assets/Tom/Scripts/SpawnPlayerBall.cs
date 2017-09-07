using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerBall : MonoBehaviour
{
    [SerializeField]
    private LayerMask _SpawnLayer;

    [SerializeField]
    private GameObject _Playerball;


    private GameObject _SpawningPlayerBall;


    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, _SpawnLayer))
        {
            //Start spawning the ball.
            if (Input.GetButtonDown("Fire1"))
            {
                _SpawningPlayerBall = Instantiate(_Playerball, hit.point, Quaternion.identity);
            }

            //When a ball is being spawned make sure to scale him.
            if (Input.GetButton("Fire1"))
            {
                _SpawningPlayerBall.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }

            //Make sure to reset the spawning ball.
            if (Input.GetButtonUp("Fire1"))
            {
                _SpawningPlayerBall = null;
            }
        }
    }
}
