using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_shooting : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform Firepoint;
    public GameObject BulletPrefab;
    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        float StartDelay = 1f;
        float interval = 5f;
        float delay = 0.2f;
        InvokeRepeating("Shoot",StartDelay,interval);
        InvokeRepeating("Shoot",StartDelay += delay,interval);
        InvokeRepeating("Shoot",StartDelay += delay,interval);
        InvokeRepeating("Shoot",StartDelay += delay,interval);
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
