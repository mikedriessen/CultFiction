using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Death : MonoBehaviour
{
   public int Health;

   private void Start()
   {
      Health = 5;
   }
   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("PlayerBullet"))
      {
         Health--;
         if (Health == 0 || Health < 0)
         {
            Dies();
         }
      }
   }

   private void Dies()
   {
      Destroy(this.gameObject);
      
   }
}
