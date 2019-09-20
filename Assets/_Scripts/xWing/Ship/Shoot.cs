using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform[] shootPos;

    private GameObject oldBullet;

    public int bulletCount = 0;

    private void Start()
    {
        StartCoroutine(wait());
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
        
            for (int i = 0; i < shootPos.Length; i++)
            { 
                Rigidbody clone;
                clone = bullet.GetComponent<Rigidbody>();
                clone = Instantiate(bullet, shootPos[i].position, transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.forward * 1000);
                bulletCount++;

            }

            
        }
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        DestroyAll();
    }

    void DestroyAll()
    {
        StartCoroutine(wait());
        for (int i = 0; i < bulletCount; i++)
        {
            oldBullet = GameObject.FindWithTag("PlayerBullet");
            DestroyImmediate(oldBullet);
            bulletCount --;
        }
       
    }
}
