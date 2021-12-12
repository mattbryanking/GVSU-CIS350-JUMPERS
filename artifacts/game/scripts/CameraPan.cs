using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    // pans intro camera right, this was way easier than making a never ending animation
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 2);
    }
}
