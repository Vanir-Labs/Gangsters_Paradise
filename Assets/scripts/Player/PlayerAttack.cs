//PlayerAttack
//By: Lex King
//Attack and damage -10 for each hit.
//Additional damages in progress
// ==================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#include PlayerMove

public class PlayerAttack : PlayerMove
{
//    Rigidbody2D rb;
//    Animator anim;
//    Animation anima;

    public GameObject target;
    public bool attacking;
    public float attackTime;
    public float coolDown;
    public bool casting;
    public float attack;
    public float attack_1;
    public float attack_2;
    public float attack_3;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
//        Player = GetComponent<SpriteRenderer>();

        if (!rb)
        {
            Debug.Log("Rigidbody2D does not exist");
        }
        if (!anim)
        {
            Debug.Log("Animation does not exist");
        }
 /*       if (!Player)
        {
            Debug.Log("Player does not exist");
        }*/
/*
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
*/
        {
            anim = gameObject.GetComponent<Animator>();
        }

        {
            //Attack Speed
            attackTime = 1;
            //Delay between attacks
            coolDown = 1 / 2;
        }
    }

    // Update is called once per frame
    void Update()

    {
        if (attackTime > 0)
            attackTime -= Time.deltaTime;

        if (attackTime < 0)
            attackTime = 0;
        //button pressed to activate attack (Mouse0 default)
        if (Input.GetKeyUp(KeyCode.Mouse1))
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
}
