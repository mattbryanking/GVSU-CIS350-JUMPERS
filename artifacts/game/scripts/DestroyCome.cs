using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCome : MonoBehaviour
{
    private GameObject come;
 
    void Start()
    {
        // finds any object tagged as come, which is a music object for specific levels
        come = GameObject.FindWithTag("come"); 
    }
 
    void Update()
    {
        // destroys music object if it exists
        if (come != null)
        {
            Destroy(come); 
        }
    }
}
