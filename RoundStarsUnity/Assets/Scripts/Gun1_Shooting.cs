using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun1_Shooting : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject BulletPrefab;
    public P1_Aiming aiming;
    public float bulletForce;
    public float attackrate = 2f;

    //public AudioSource ShootSound;
    float nextAttacktime;

    void Start()
    {
        aiming = GameObject.Find("Player 1").GetComponent<P1_Aiming>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttacktime)
        {
        if(Mouse.current.leftButton.wasPressedThisFrame && Time.timeScale != 0f ) // pressing Mouse 1 will trigger this
        {
            Shoot();
            nextAttacktime = Time.time + 1f/ attackrate;
            //ShootSound.Play();
        }
        }
    }

    void Shoot()
    {
        Vector3 FProtation = new Vector3(Firepoint.position.x,Firepoint.position.y,Mathf.Abs(Firepoint.position.z)); //neutralize negative value
        GameObject bullet = Instantiate(BulletPrefab, FProtation, Firepoint.rotation);  // spawns bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
    }
}