using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Defines all variables needed, able to change them outside of script
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    public SpriteRenderer sprite;
    public Animator anim;
    [SerializeField] public LayerMask jumpableGround;
    public float dirX;
    [SerializeField]public float moveSpeed = 7f;
    [SerializeField]public float jumpForce = 14f;
    private bool canJump;
    private float jumpTimer;
    private float holdDur = .75f;
    public AudioSource jumpSound;

    public enum MovementState {idle, running, jump, fall, crouch}

    // Start is called before the first frame update
    private void Start()
    {
        //Accessing other parts of the player 
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Grabs if right or left keys is pressed
        dirX = Input.GetAxisRaw("Horizontal");
        //Creates the wait before jumping
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.bodyType = RigidbodyType2D.Static;
            canJump = true;
            jumpTimer = Time.time;
        }

        else if(Input.GetButtonUp("Jump") && IsGrounded() && canJump && Time.time - jumpTimer > holdDur) 
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(dirX * moveSpeed, jumpForce);
            canJump = false;
            jumpTimer = float.PositiveInfinity;
            jumpSound.Play();
        }

        else if(Input.GetButtonUp("Jump") && IsGrounded() && canJump) 
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            jumpTimer = float.PositiveInfinity;
        }
        //Movment left or right
        else {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        UpdateAnimationState();
    }
    //Sets all animations states depending on what player is doing
    private void UpdateAnimationState()
    {
        MovementState state = MovementState.idle;

        if (Input.GetButton("Jump") && IsGrounded()) 
        {
            state = MovementState.crouch;
        }
        else if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else 
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.01f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.01f)
        {
            state = MovementState.fall;
        }
        anim.SetInteger("state",(int)state);
    }

    //Checking if plpayer is on ground to allow jumping
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
