using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlimeMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float speed = 1.19f;
    Vector3 pointA;
    Vector3 pointB;
    private float xpos;
    private float ypos;
    [SerializeField]private float distance;

    void Start()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
        pointA = new Vector3(xpos, ypos, 0);
        pointB = new Vector3(xpos + distance, ypos, 0);
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);

    }
}
