using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawn;
    public GameObject Startingpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider Other) 
    {
        if (Other.tag == "Respawn")
        {
            transform.position = Startingpoint.transform.position;
        }

    }
}
