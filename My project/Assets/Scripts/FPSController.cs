using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 20f;
    public float dashForce;
    public bool dashing = false;
    public Rigidbody rb;
    public GameObject respawn;
    public GameObject Startingpoint;
    


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


 
 
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
 
    public bool canMove = true;
 
    
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void Update()
    {
 
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward*200);
        Vector3 right = transform.TransformDirection(Vector3.right*200);
 
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
 
        #endregion
 
        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
 
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
 
        #endregion
 
        #region Handles Rotation
        rb.velocity = (moveDirection * Time.deltaTime);
 
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion

        if (dashing == false && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Dash");

        }

    }
    IEnumerator Dash()
    {
        dashing = true;
        rb.velocity = new Vector3(0, 0, 0); //stop player movement
        rb.AddForce(transform.forward * dashForce, ForceMode.Impulse); //push player forward
        yield return new WaitForSeconds(0.4f); //time for push, length of dash
        rb.velocity = new Vector3(0, 0, 0); //stop player again
        dashing = false; //stops player from spamming dash and going super speed
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Respawn")
        {
            transform.position = Startingpoint.transform.position;        }

        if (Other.gameObject.tag == "bullet")
        {
            Destroy(Other.gameObject);
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        transform.parent = hit.gameObject.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}