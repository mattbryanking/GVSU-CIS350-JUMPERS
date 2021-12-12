using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArm : MonoBehaviour
{
   private GameObject arp;
 
    void Start()
    {
        // finds any object tagged as arp, which is a music object for specific levels
        arp = GameObject.FindWithTag("arp"); 
    }
 
    void Update()
    {
        // destroys music object if it exists
        if (arp != null)
        {
            Destroy(arp); 
        }
    }
}
