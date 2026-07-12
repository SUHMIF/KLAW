using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ryan Smith KLAW Grabbed object Script

public class Grabbed : MonoBehaviour
{
    private GameObject grabbedObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        else
        {
            changeLayer(collision.gameObject);
        }    
    }

    private void changeLayer(GameObject obj)
    {
        grabbedObject = obj;

        int carriedLayer = LayerMask.NameToLayer("grabbedObject"); // Simply changes layer of object collided with to a layer that does not interact with platform

        obj.layer = carriedLayer;
    }
}
