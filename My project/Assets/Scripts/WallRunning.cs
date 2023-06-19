using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    public LayerMask whatIsWall;
    public float wallrunForce,maxWallrunTime,maxWallSpeed;
    bool isWallRight,isWallLeft;
    bool isWallRunning;
    bool WallClimbing;
    public Rigidbody rb;
    public GameObject orientation;
    public FPSController player;
   
    void Update()
    {
        CheckForWall();
        if (Input.GetKey(KeyCode.D)){StartWallRun();}
        if (Input.GetKey(KeyCode.A)){StartWallRun();}
    }
    private void  WallRunInput()
    {
        if (isWallRight) StartWallRun();
        if (isWallLeft) StartWallRun();
    }
    private void  StartWallRun()
    {
        rb.velocity = new Vector3(0, 0, 0);
        player.gravity = 0;
        rb.useGravity = false;
        isWallRunning = true;
        if(rb.velocity.magnitude <= maxWallSpeed)
        {
            rb.AddForce(transform.forward  * wallrunForce * Time.deltaTime);

            if(isWallRight)
            rb.AddForce(orientation.transform.right  * wallrunForce / 5* Time.deltaTime);
            else if (isWallLeft)
            rb.AddForce(-transform.right  * wallrunForce / 5* Time.deltaTime);

        }
    }
    private void  StopWallRun()
    {
        player.gravity = 10f;
        rb.useGravity = true;
        isWallRunning = false;
    }
    private void  CheckForWall()
    {
        isWallRight = Physics.Raycast(transform.position, orientation.transform.right,1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.transform.right,1f, whatIsWall);

        if(!isWallLeft || ! isWallRight) StopWallRun();
        if (WallClimbing == true)
        {
            
        }
    }
}
