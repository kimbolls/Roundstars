using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{

    public float delay = 3f;
   
    public float radius;
    public float explosionforce;
    float countdown;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true; 
        }
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach(Collider2D nearbyobject in colliders)
        {
            Debug.Log("boom?");
            Rigidbody2D rb = nearbyobject.GetComponent<Rigidbody2D>();
            if(rb !=null)
            {
                rb.AddExplosionForce(explosionforce,transform.position,radius,radius);
            }
        }

        Destroy(gameObject);
    }

    
}
