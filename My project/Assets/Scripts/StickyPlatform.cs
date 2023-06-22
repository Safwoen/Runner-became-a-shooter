using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnControllerColliderHit(Collider other)
    {
        Debug.Log("afafaf");
        other.transform.SetParent(transform);
    }

    private void OnControllerColliderExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
