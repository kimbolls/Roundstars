using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickAim : MonoBehaviour
{
    //public Transform Gun;
    
    public GameObject GunPrefab;
    public Rigidbody2D rb;
     
    private GameObject Gun;
    public bool shoot = false;
    private Gun2_Shooting gun2;

    public void OnShoot(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        shoot = context.action.triggered;
    }
    // Start is called before the first frame update
    void Start()
    {
        Gun = Instantiate(GunPrefab,rb.position,Quaternion.identity);
        gun2 = Gun.GetComponent<Gun2_Shooting>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shoot)
        {
            gun2.Shoot();  
        }

        if(GunPrefab != null)
        {
        StickGun();
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    public void StickGun(){
        Rigidbody2D Gunrb = Gun.GetComponent<Rigidbody2D>();
        Transform GunPosition = Gun.GetComponent<Transform>();
        Gunrb.position = rb.position;
       
    }
}
