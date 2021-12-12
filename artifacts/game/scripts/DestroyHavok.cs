using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHavok : MonoBehaviour
{
   private GameObject hhavok;
 
    void Start()
    {
        // finds any object tagged as come, which is a music object for specific levels
        hhavok = GameObject.FindWithTag("hhavok"); 
    }
 
    void Update()
    {
        // destroys music object if it exists
        if (hhavok != null)
        {
            Destroy(hhavok); 
        }
    }
}
