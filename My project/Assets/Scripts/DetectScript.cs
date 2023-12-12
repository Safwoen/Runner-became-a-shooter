using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class DetectScript : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;
    

    public GameObject bullet;
    public Transform shootpoint;
    public GameObject DeathUI;



    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;
    
    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(detected)
        {
            enemy.LookAt(target.transform);
        }
        timeToShoot -= Time.deltaTime;

        if(timeToShoot <= 0 && detected)
        {
            ShootPlayer();
            timeToShoot = originalTime;
        }
    
    }
    private void FixedUpdate()
    {
       if (detected)
        {
            enemy.LookAt(target.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = false;
            target =null;
        }
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootpoint.position, shootpoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
   

}
