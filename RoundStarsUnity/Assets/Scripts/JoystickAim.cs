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
    public Vector2 aimValue = Vector2.zero;

    public bool tripleshoot = false;
    public void OnShoot(InputAction.CallbackContext context){
        //jumped = context.ReadValue<bool>();
        shoot = context.action.triggered;
    }

    public void OnAim(InputAction.CallbackContext context){
        aimValue = context.ReadValue<Vector2>();
    }

    public void OnTriple(InputAction.CallbackContext context)
    {
        tripleshoot = context.action.triggered;
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

        if(tripleshoot)
        {
            gun2.tripleShoot();
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
