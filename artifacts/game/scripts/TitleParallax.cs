using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleParallax : MonoBehaviour
{
    private float length;
    private float startpos;
    public GameObject cam;

    // user can set how quickly a layer moves
    public float parallaxEffect;

    void Start()
    {
        // where paralax objects start
        startpos = transform.position.x;

        // length of paralax objects
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        // relative pan of each object
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);  

        // resets items when end of paralax is reached, appearing to loop infinitely 
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
