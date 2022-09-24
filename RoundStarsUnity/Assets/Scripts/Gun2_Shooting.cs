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

    //
    public Transform Firepoint;
    public GameObject BulletPrefab;

    public float bulletForce;

    public float attackrate = 2f;
    //public AudioSource ShootSound;
    float nextAttacktime;
    //

    // Start is called before the first frame update
    void Start()
    {
       movement = GameObject.Find("Player 2").GetComponent<Player2_Movement>();
       joystick = GameObject.Find("Player 2").GetComponent<JoystickAim>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Aim();
        
    }

    public void Aim(){
        angle = TwistPoint.transform.localEulerAngles;
        float HorizontalAxis = joystick.aimValue.x;
        float VerticalAxis = joystick.aimValue.y;

        
        if(HorizontalAxis == 0f && VerticalAxis == 0f)
        {
            Vector3 currentRotation = TwistPoint.transform.localEulerAngles;
            Vector3 homeRotation;

            if(currentRotation.z > 180f)
            {
                homeRotation = new Vector3(0f,0f,359.999f);
            }
            else
            {
                homeRotation = Vector3.zero;
            }
            TwistPoint.transform.localEulerAngles = Vector3.Slerp(currentRotation, homeRotation, Time.deltaTime * returnTime);

        }
        else
        {
            TwistPoint.transform.localEulerAngles = new Vector3(0f,0f,Mathf.Atan2(HorizontalAxis,VerticalAxis)*-180 / Mathf.PI + 90f);
        }
        
        


    }

    public void Shoot()
    {

        if(Time.time >= nextAttacktime)
        {
        if(Time.timeScale != 0f ) // pressing Mouse 1 will trigger this
        {
            Vector3 FProtation = new Vector3(Firepoint.position.x,Firepoint.position.y,Mathf.Abs(Firepoint.position.z)); //neutralize negative value
            GameObject bullet = Instantiate(BulletPrefab, FProtation, Firepoint.rotation);  // spawns bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
            rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
    }
            nextAttacktime = Time.time + 1f/ attackrate;
            //ShootSound.Play();
        }
        }
        
       
       
}
