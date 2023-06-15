using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Rigidbody>() == null)
        {
       //  if(Mathf.Abs(Vector3.Dot(collision.GetContact(0).normal, Vector3.up))<0.1f &&(wallLimit != collision .GetContact(0).normal ||(wallLimit != collision.GetContact(0).normal && wallLimitTime <= 0) )
        }
    }
}
