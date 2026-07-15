using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ryan Smith KLAW Out of bounds Script

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}