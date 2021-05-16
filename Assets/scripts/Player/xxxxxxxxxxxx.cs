//PlayerConfig
//By: Lex King
//Basic Player configurations.
// ==================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerMovement
//Basic Player Movement.
// ==================================================

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerConfig : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Animation anima;
    //Adjust "Player" to be your custom sprite name
    SpriteRenderer Player;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundedLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isWalking;

    // Start is called before the first frame update
    // Run GetComponent in the Start(), never Update().
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GetComponent<SpriteRenderer>();

        if (!rb)
        {
            Debug.Log("Rigidbody2D does not exist");
        }
        if (!anim)
        {
            Debug.Log("Animation does not exist");
        }
        if (!Player)
        {
            Debug.Log("Player does not exist");
        }

        if (speed <= 0)
        {
            speed = 3.0f;
        }
        if (jumpForce <= 0)
        {
            jumpForce = 320;
        }
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
        {
            anim = gameObject.GetComponent<Animator>();
        }

        {
            //Attack Speed
            attackTime = 0;
            //Delay between attacks
            coolDown = 2;
        }
    }

    void Update()
    {
        //Projectile Attack (PHYS)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                anim.Play("shoot");
        }
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
                anima.Stop("shoot");
        }
        //Physical Attack (PHYS)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
                anim.Play("attack");
        }
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
                anima.Stop("attack");
        }
        //Projectile Attack (MAGI)
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
                anim.Play("cast");
        }
        {
            if (Input.GetKeyUp(KeyCode.Mouse2))
                anima.Stop("cast");
        }
        //Physical Attack (PHYS)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                anim.Play("attack_1");
        }
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
                anima.Stop("attack_1");
        }
        //Physical Attack (PHYS)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
                anim.Play("attack_2");
        }
        {
            if (Input.GetKeyUp(KeyCode.Alpha2))
                anima.Stop("attack_2");
        }
        //Physical Attack (PHYS)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
                anim.Play("attack_3");
        }
        {
            if (Input.GetKeyUp(KeyCode.Alpha3))
                anima.Stop("attack_3");
        }
        //Animation for Moving in 4 directions
        {
            if (Input.GetKeyDown(KeyCode.D))
                anim.Play("right");
        }
        {
            if (Input.GetKeyUp(KeyCode.D))
                anim.Play("idle_right");
        }
        {
            if (Input.GetKeyDown(KeyCode.W))
                anim.Play("up");
        }
        {
            if (Input.GetKeyUp(KeyCode.W))
                anim.Play("idle_up");
        }
        {
            if (Input.GetKeyDown(KeyCode.S))
                anim.Play("down");
        }
        {
            if (Input.GetKeyUp(KeyCode.S))
                anim.Play("idle_down");
        }
        {
            if (Input.GetKeyDown(KeyCode.A))
                anim.Play("left");
        }
        {
            if (Input.GetKeyUp(KeyCode.A))
                anim.Play("idle_left");
        }

        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundedLayer);

            //Adjust Time.deltaTime * 4, 0, 0 for (X)speed, (Y)jump height, (Z)fall speeds X , Y, Z
            //transform.Translate(new Vector3(horizontalInput * Time.deltaTime * 4, 0, 0));
            //Debug line, not necessarily needed
            Debug.Log(horizontalInput);

            if (Input.GetButtonDown("Jump"))
            {
                //Adjust Time.deltaTime for JUMP height or adjust multiplier below
                rb.AddForce(Vector3.up * jumpForce);
                //Makes jumps act more consistantly
                rb.velocity = Vector2.zero;
            }

            //Jump velocity adjustment as well, adjust if you know what to do.
            Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
            rb.velocity = moveDirection;

            //Math concepts you can introduce to scripts to 
            anim.SetFloat("speed", Mathf.Abs(horizontalInput));
            anim.SetBool("isGrounded", isGrounded);
            /*
                    //Flip character on left/rights (platform mode)
                    if (Player.flipX && horizontalInput > 0 || !Player.flipX && horizontalInput < 0)
                        Player.flipX = !Player.flipX;
                    //transform.Rotate(0f, 180f, 0f);
            */
            /*
                        //Flip Horizontally (platform mode)
                        if (Player.flipY && verticalInput > 0 || !Player.flipY && verticalInput < 0)
                        Player.flipY = !Player.flipY;
            */

        }
    }

    // ==================================================
    // ==================================================
    // ==================================================
    void Movement()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GetComponent<SpriteRenderer>();

        if (!rb)
        {
            Debug.Log("Rigidbody2D does not exist");
        }
        if (!anim)
        {
            Debug.Log("Animation does not exist");
        }
        if (!Player)
        {
            Debug.Log("Player does not exist");
        }
        /*
        if (speed <= 0)
        {
            speed = 1.0f;
        }
        if (jumpForce <= 0)
        {
            jumpForce = 320;
        }
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
        */
    }


    void Walking()
    {
        //Alternative movement animation
        /*
        {
            if (Input.GetKeyDown(KeyCode.D))
                anim.SetBool("isWalking", Player.flipX);
            anim.Play("right");
        }
        {
            if (Input.GetKeyDown(KeyCode.A))
                anim.SetBool("isWalking", Player.flipX);
            anim.Play("left");
        }
        {
            if (Input.GetKeyDown(KeyCode.W))
                anim.SetBool("isWalking", Player.flipX);
            anim.Play("up");
        }
        {
            if (Input.GetKeyDown(KeyCode.S))
                anim.SetBool("isWalking", Player.flipX);
            anim.Play("down");
        }
        */

        //Speed based on direction; adjust formula for faster speeds
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * speed);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * speed);
            }

            else if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * speed);
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
    }


    // ==================================================
    // ==================================================
    // ==================================================

    /* PLAYER JUMP NOT FUNCTIONAL, SETTINGS ADJUSTABLE IN COMBO WITH OTHER FUNCTIONS
    //PlayerJump
    //Basic Player jumping.
    // ==================================================

        public Vector3 jump;
//      public float jumpForce = 2.0f;

//      public bool isGrounded;
//      Rigidbody rb;
        void playJump()
    {
        rb = GetComponent <Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void JumpLand()
    {
        if (Input.GetKeyDown((KeyCode.Space) || (KeyCode.UpArrow) && (isGrounded)))
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    */

    // ==================================================
    // ==================================================
    // ==================================================

    //PlayerAttack
    //Attack and damage
    //Additional damages in progress
    // ==================================================

    public GameObject target;
    public float attackTime;
    public float coolDown;
    public float attack;
    public bool attacking;
    public bool casting;

    // Use this for initialization
    void platk1()
    {
        attackTime = 1;
        //Delay between attacks
        coolDown = 2;
    }

    // Update is called once per frame
    void platk2()
    {
        if (attackTime > 0)
            attackTime -= Time.deltaTime;

        if (attackTime < 0)
            attackTime = 0;
        //button pressed to activate attack (Mouse0 default)
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (attackTime == 0)
            {
                Attack();
                attackTime = coolDown;
            }
        }
    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);
        Debug.Log(direction);

        //Distance to target
        if (distance < 2.5f)
        {
            if (direction > 0)
            {
                //EnemyHP deduction, WIP
                //EnemyHealth enhp = (EnemyHealth)target.GetComponent("EnemyHealth");
                // enhp.EnHealth(-10);
            }
        }
    }

    // ==================================================
    // ==================================================
    // ==================================================

    //PlayerAnimation
    //Basic Player attack aniamtions.
    // By: Lex King
    // ==================================================

    //    public Animator anim;
    // Use this for initialization
    void anim1()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void anim2()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            anim.Play("attack");
    }

    // ==================================================
    // ==================================================
    // ==================================================
    // ==================================================
    // End of Section
    // ==================================================
    //
    //End of PlayerConfig
    //
    //
    //
    // Experimental past this line //


}
