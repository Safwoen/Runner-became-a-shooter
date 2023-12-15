using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickyplatform1 : MonoBehaviour
{
    
        void OnTriggerEnter(Collider other)
        {
            other.transform.SetParent(transform);
        }

        void OnTriggerExit(Collider other)
        {
            other.transform.SetParent(null);
        }


    
}