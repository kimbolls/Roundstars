using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Aiming : MonoBehaviour
{
    public GameObject GunPrefab;
    public Rigidbody2D rb;  
    private GameObject Gun;

   

    public P1_Movement movement;
    
    // Start is called before the first frame update
    void Start()
    {
        Gun = Instantiate(GunPrefab,rb.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
      // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {   
        if(GunPrefab != null)
        {
        StickGun();
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    void StickGun()
    {   
        Rigidbody2D Gunrb = Gun.GetComponent<Rigidbody2D>();
        Transform GunPosition = Gun.GetComponent<Transform>();
        //Vector3 angle = Gunrb.transform.localEulerAngles;
        //Vector2 lookDir = mousePos - rb.position;
       // angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        //Gunrb.position = rb.position;
        //Gunrb.rotation = angle;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Gunrb.transform.rotation = Quaternion.Euler(0f,0f,angle);
        Gunrb.position = rb.position;
        Gunrb.rotation = angle;
       if(angle < -90 || angle > 90)
       {
        if(transform.eulerAngles.y == 0 )
        {
            Gun.transform.localRotation = Quaternion.Euler(180,0,-angle);
        }
        else if(transform.eulerAngles.y == 180){
            Gun.transform.localRotation = Quaternion.Euler(180,180,-angle);
        }
       }

            

        
    }

}
