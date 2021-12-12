using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePan : MonoBehaviour
{
    void Update()
    {
        // pans UI in title sequence
        transform.Translate(Vector3.right * Time.deltaTime * 2);
    }
}
