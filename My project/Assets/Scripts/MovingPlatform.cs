using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform myPlatform;
    public Transform myStartPoint;
    public Transform myEndPoint;
    void Start()
    {
        myPlatform.position = myStartPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        myPlatform.position = Vector3.MoveTowards(myPlatform.position, myEndPoint.position, 0.1f);
    }
}
