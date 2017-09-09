using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObjectType
{
    public GameObject[] PoolObject;
}

public class PoolController : MonoBehaviour
{
    [Tooltip("Store here all the different pool objects in.")]
    [SerializeField]
    private PoolObjectType[] _DifferentPoolObjects;


    //Activates an entity.
    public void ActivateEntity(GameObject requestedEntity, Vector3 position, Vector3 eulerAngle)
    {
        //Check if the requeste object is possible to spawn.
        if(CheckRequestedObject(requestedEntity))
        {
            requestedEntity.transform.position = position;
            requestedEntity.transform.eulerAngles = eulerAngle;
            requestedEntity.SetActive(true);
        }
    }

    //Checks if the requested object is allowed or possible to spawn.
    public bool CheckRequestedObject(GameObject requestedEntity)
    {
        for (int i = 0; i < _DifferentPoolObjects.Length; i++)
        {
            if (_DifferentPoolObjects[i].PoolObject[0] == requestedEntity)
            {
                return true;
            }
        }

        return false;
    }


    //Deactivates an entity.
    public void DeactivateEntity(GameObject gameObject)
    {

    }
}
