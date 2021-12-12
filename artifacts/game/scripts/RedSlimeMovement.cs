using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlimeMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]public float jumpForce = 14f;
    [SerializeField] public LayerMask jumpableGround;
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(IsGrounded())
        {
           rb.velocity = new Vector2(0, jumpForce);
        }
    }
       public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
