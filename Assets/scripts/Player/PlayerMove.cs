// PlayerMove
// By: Lex King
// Basic Player Movement, controls & animation
// ==================================================
 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;

 //#include PlayerAnimation
//#include PlayerAttack

 [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
 public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private Animation anima;
    //Adjust "Player" to be your custom sprite name
    public SpriteRenderer Player;
    public float speed = (1) / 2;
    public Vector2 movement;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            Player = GetComponent<SpriteRenderer>();

            {
                anim = gameObject.GetComponent<Animator>();
            }
        }

            void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

                //Projectile Attack (PHYS)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                        anim.Play("shoot");
                }
                //Physical Attack (PHYS)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                        anim.Play("attack");
                }
                //Projectile Attack (MAGI)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha4))
                        anim.Play("cast");
                }
                //Physical Attack (PHYS)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                        anim.Play("attack_1");
                }

                //Physical Attack (PHYS)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                        anim.Play("attack_2");
                }
                //Physical Attack (PHYS)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                        anim.Play("attack_3");
                }
        }

        void FixedUpdate () 
    {
                    //Direction for Moving in 4 +4 directions
        {
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        {
            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        {
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
                    //Animation for Moving in 4 +4 directions
        {
            if (Input.GetKey(KeyCode.D))
                anim.Play("right");
        }
        {
            if (Input.GetKey(KeyCode.W))
                anim.Play("up");
        }
        {
            if (Input.GetKey(KeyCode.S))
                anim.Play("down");
        }
        {
            if (Input.GetKey(KeyCode.A))
                anim.Play("left");
        }
        {
            if (Input.GetKeyDown(KeyCode.D) & (Input.GetKeyDown(KeyCode.W)))
                anim.Play("up");
        }
        {
            if (Input.GetKeyDown(KeyCode.A) & (Input.GetKeyDown(KeyCode.W)))
                anim.Play("up");
        }
        {
            if (Input.GetKeyDown(KeyCode.D) & (Input.GetKeyDown(KeyCode.S)))
                anim.Play("down");
        }
        {
            if (Input.GetKeyDown(KeyCode.A) & (Input.GetKeyDown(KeyCode.S)))
                anim.Play("down");
        }
                    //Animation for Idle in 4 directions
        {
            if (Input.GetKeyUp(KeyCode.D))
                anim.Play("idle_right");
        }
        {
            if (Input.GetKeyUp(KeyCode.W))
                anim.Play("idle_up");
        }
        {
            if (Input.GetKeyUp(KeyCode.S))
                anim.Play("idle_down");
        }
        {
            if (Input.GetKeyUp(KeyCode.A))
                anim.Play("idle_left");
        }

    }


//End Of Script
}