using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{   
    public Rigidbody2D rb;
    public Transform Firepoint;
    public GameObject BulletPrefab;
    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",1f,3f);
        InvokeRepeating("Shoot",1.2f,3f);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void Shoot()
    {
        Vector3 FProtation = new Vector3(Firepoint.position.x,Firepoint.position.y,Mathf.Abs(Firepoint.position.z));
        GameObject bullet = Instantiate(BulletPrefab, FProtation, Firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
    }
}
