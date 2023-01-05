using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun1_Shooting : MonoBehaviour
{
    
    public Transform Firepoint;
    public Transform[] TripleFP;
    public GameObject BulletPrefab;
    public P1_Aiming aiming;
    public float bulletForce;
    public float grenadeForce;
    public float attackrate = 2f;
    public float grenaderate = 5f;
    public float triplerate = 5f;
    public float tripletimer;
    public float grenadetimer;
    public GameObject LesserBullet;
    public GameObject GrenadePrefab;

    score_tracker score_menu;

    //public AudioSource ShootSound;
    public float nextAttacktime;
    public float nextGrenadetime;

    [SerializeField] private AudioSource shoot_sound;

    void Start()
    {
        aiming = GameObject.Find("Player 1").GetComponent<P1_Aiming>();
        score_menu = GameObject.Find("ScoreHUD").GetComponent<score_tracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grenadetimer >0)
        {
            grenadetimer -= Time.deltaTime;
        }
        if(tripletimer > 0)
        {
            tripletimer -= Time.deltaTime;
        }


        if(Time.time >= nextAttacktime)
        {
            if(Mouse.current.leftButton.wasPressedThisFrame && Time.timeScale != 0f ) // pressing Mouse 1 will trigger this
            {
                Shoot();
                nextAttacktime = Time.time + 1f/ attackrate;
                //ShootSound.Play();
            }

            if(Mouse.current.rightButton.wasPressedThisFrame && Time.timeScale != 0f && tripletimer <=0 ) // pressing Mouse 1 will trigger this
            {
                tripleShoot();
                tripletimer = triplerate;
                //ShootSound.Play();
            }
        }

        if(grenadetimer <= 0)
        {
            if(aiming.boom && Time.timeScale != 0f )
            {
                GrenadeShoot();
                grenadetimer = grenaderate;
            }
        }

    }

    void Shoot()
    {
        Vector3 FProtation = new Vector3(Firepoint.position.x,Firepoint.position.y,Mathf.Abs(Firepoint.position.z)); //neutralize negative value
        GameObject bullet = Instantiate(BulletPrefab, FProtation, Firepoint.rotation);  // spawns bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
        score_menu.ShotsTracker(1,0,0);
        shoot_sound.Play();
    }

    void tripleShoot()
    {
        Vector3 FProtation = new Vector3(Firepoint.position.x,Firepoint.position.y,Mathf.Abs(Firepoint.position.z)); //neutralize negative value
        GameObject bullet = Instantiate(LesserBullet, FProtation, Firepoint.rotation);  // spawns bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb.AddForce(Firepoint.right * (bulletForce-5), ForceMode2D.Impulse);  //add force to the bullet

        Vector3 FProtation2 = new Vector3(TripleFP[0].position.x,TripleFP[0].position.y,Mathf.Abs(TripleFP[0].position.z)); //neutralize negative value
        GameObject bullet2 = Instantiate(LesserBullet, FProtation2, TripleFP[0].rotation);  // spawns bullet
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb2.AddForce(TripleFP[0].right * (bulletForce-5), ForceMode2D.Impulse);  //add force to the bullet

        Vector3 FProtation3 = new Vector3(TripleFP[1].position.x,TripleFP[1].position.y,Mathf.Abs(TripleFP[1].position.z)); //neutralize negative value
        GameObject bullet3 = Instantiate(LesserBullet, FProtation3, TripleFP[1].rotation);  // spawns bullet
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb3.AddForce(TripleFP[1].right * (bulletForce-5), ForceMode2D.Impulse);  //add force to the bullet

        shoot_sound.Play();
        score_menu.ShotsTracker(3,0,0);
        // Firepoint.transform.position - transform.position;
        // var direction = Quaternion.Euler(0, 0, 45) * (Firepoint - transform.position);
        // _targetPosition = transform.position + direction;   
        // transform.position = Vector2.Lerp(transform.position, _targetPosition, Time.deltaTime * Speed);
    }

    void GrenadeShoot()
    {
        Debug.Log("grenade");

        Vector3 FProtation = new Vector3(Firepoint.position.x,Firepoint.position.y,Mathf.Abs(Firepoint.position.z)); //neutralize negative value
        GameObject grenade = Instantiate(GrenadePrefab, FProtation, Firepoint.rotation);  // spawns bullet
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
    }

    
}