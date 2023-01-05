using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2_Shooting : MonoBehaviour
{
    public Transform TwistPoint;
    public float returnTime = .8f;
    public Player2_Movement movement;
    public JoystickAim joystick;
    public Vector3 angle;


    public Transform[] TripleFP;

    //
    public Transform Firepoint;
    public GameObject BulletPrefab;

    public float bulletForce;

    public float attackrate = 2f;
    public float triplerate = 5f;
    public float tripletimer;

    public GameObject LesserBullet;
    //public AudioSource ShootSound;
    float nextAttacktime;

    score_tracker score_menu;
    [SerializeField] private AudioSource shoot_sound;
    //

    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.Find("Player 2").GetComponent<Player2_Movement>();
        joystick = GameObject.Find("Player 2").GetComponent<JoystickAim>();

        score_menu = GameObject.Find("ScoreHUD").GetComponent<score_tracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tripletimer > 0)
        {
            tripletimer -= Time.deltaTime;
        }
        Aim();

    }

    public void Aim()
    {
        angle = TwistPoint.transform.localEulerAngles;
        float HorizontalAxis = joystick.aimValue.x;
        float VerticalAxis = joystick.aimValue.y;


        if (HorizontalAxis == 0f && VerticalAxis == 0f)
        {
            Vector3 currentRotation = TwistPoint.transform.localEulerAngles;
            Vector3 homeRotation;

            if (currentRotation.z > 180f)
            {
                homeRotation = new Vector3(0f, 0f, 359.999f);
            }
            else
            {
                homeRotation = Vector3.zero;
            }
            TwistPoint.transform.localEulerAngles = Vector3.Slerp(currentRotation, homeRotation, Time.deltaTime * returnTime);

        }
        else
        {
            TwistPoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);
        }




    }

    public void Shoot()
    {

        if (Time.time >= nextAttacktime)
        {
            if (Time.timeScale != 0f) // pressing Mouse 1 will trigger this
            {
                Vector3 FProtation = new Vector3(Firepoint.position.x, Firepoint.position.y, Mathf.Abs(Firepoint.position.z)); //neutralize negative value
                GameObject bullet = Instantiate(BulletPrefab, FProtation, Firepoint.rotation);  // spawns bullet
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
                rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
                score_menu.ShotsTracker(1, 0, 1);
            }
            nextAttacktime = Time.time + 1f / attackrate;
            shoot_sound.Play();
        }
    }

    public void tripleShoot()
    {
        if (Time.timeScale != 0f && tripletimer <= 0)
        {
            Vector3 FProtation = new Vector3(Firepoint.position.x, Firepoint.position.y, Mathf.Abs(Firepoint.position.z)); //neutralize negative value
            GameObject bullet = Instantiate(LesserBullet, FProtation, Firepoint.rotation);  // spawns bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
            rb.AddForce(Firepoint.right * (bulletForce - 5), ForceMode2D.Impulse);  //add force to the bullet

            Vector3 FProtation2 = new Vector3(TripleFP[0].position.x, TripleFP[0].position.y, Mathf.Abs(TripleFP[0].position.z)); //neutralize negative value
            GameObject bullet2 = Instantiate(LesserBullet, FProtation2, TripleFP[0].rotation);  // spawns bullet
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
            rb2.AddForce(TripleFP[0].right * (bulletForce - 5), ForceMode2D.Impulse);  //add force to the bullet

            Vector3 FProtation3 = new Vector3(TripleFP[1].position.x, TripleFP[1].position.y, Mathf.Abs(TripleFP[1].position.z)); //neutralize negative value
            GameObject bullet3 = Instantiate(LesserBullet, FProtation3, TripleFP[1].rotation);  // spawns bullet
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
            rb3.AddForce(TripleFP[1].right * (bulletForce - 5), ForceMode2D.Impulse);  //add force to the bullet
            tripletimer = triplerate;
            shoot_sound.Play();
            score_menu.ShotsTracker(3, 0, 1);
        }

        // Firepoint.transform.position - transform.position;
        // var direction = Quaternion.Euler(0, 0, 45) * (Firepoint - transform.position);
        // _targetPosition = transform.position + direction;   
        // transform.position = Vector2.Lerp(transform.position, _targetPosition, Time.deltaTime * Speed);
    }



}
