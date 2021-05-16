//PlayerConfig
//By: Lex King
//Projectile Configuration
// ==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject FirePoint;
    private Rigidbody bullet;
    public float bulletSpeed = 1;
    public float ammo = 10;

///*
        void Fire()
        {
            var bullet = (GameObject)Instantiate(BulletPrefab);
            var bulletClone = (GameObject)Instantiate(BulletPrefab);

              //Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, FirePoint.transform.position, FirePoint.transform.rotation);
              //bulletClone.velocity = FirePoint.transform.forward * bulletSpeed;
                GameObject gameObject = (GameObject)Instantiate(bullet, FirePoint.transform.position
               // + FirePoint.transform.forward
                ,
                FirePoint.transform.rotation);
                isShooting = false;
                Destroy(gameObject, 2);
                
//            Destroy(bullet, 2);
    }
    //*/
    /*
        void Fire()
        {
            isShooting = true;
            var bullet1 : Rigidbody = Instantiate(bullet, FirePoint.transform.position, FirePoint.transform.rotation);
            bullet1.AddForce(transform.forward * speed);
            ammo--;
            StartCoroutine(shootingDone());
        }
    */

    public bool isShooting = false;
    void Update()
    {
        isShooting = false;
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isShooting)
            {
                isShooting = false;
                if (ammo > 0)
                {
                    Fire();
                    isShooting = true;
                    ammo--;
                    Delay();
                }
            }
        }
//        {
//            if (Input.GetKey(KeyCode.Mouse0))
//                Fire();
//        }
    }

    void Delay()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}
