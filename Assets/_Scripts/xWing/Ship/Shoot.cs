using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform[] shootPos;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           
        
            for (int i = 0; i < shootPos.Length; i++)
            { 
                Rigidbody clone;
                clone = Instantiate(bullet, shootPos[i].position, transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.forward * 1000);
            }

            
        }
    }
}
