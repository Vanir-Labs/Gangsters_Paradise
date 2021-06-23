//PlayerAnimation
//By: Lex King
//Player Animations
// ==================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject target;
    public bool attacking;
    public float attackTime;
    public float coolDown;
    public bool casting;
    public float attack;
    public float attack_1;
    public float attack_2;
    public float attack_3;

    //public Animator anim;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
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
    }


    // Use this for initialization
    void anim0()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
    void anim1()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            anim.Play("attack");
    }
    void anim2()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            anim.Play("shoot");
    }
    void anim3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
            anim.Play("cast");
    }
    void anim4()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            anim.Play("attack_1");
    }
    void anim5()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
            anim.Play("attack_2");
    }
    void anim6()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
            anim.Play("attack_3");
    }
}
