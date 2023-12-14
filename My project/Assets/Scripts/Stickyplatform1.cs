using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickyplatform1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
         collision.gameObject.transform.parent = transform;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }

    }
}
