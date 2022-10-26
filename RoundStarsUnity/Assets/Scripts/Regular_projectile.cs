using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular_projectile : MonoBehaviour
{
    //public GameObject impact;
    public int damage;
    public GameObject Particle;
    //public SpriteRenderer Sprite;
    int bouncecount;
    void Start()
    {
        bouncecount = 2;
        Destroy(gameObject,3f);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
         P1_Attributes player1 = hitInfo.gameObject.GetComponent<P1_Attributes>();
         if(player1 != null)
         {
            player1.TakeDamage(damage);

         }

         P2_Attributes player2 = hitInfo.gameObject.GetComponent<P2_Attributes>();
         if(player2 != null)
         {
            player2.TakeDamage(damage);

         }


        //  answerReceiver answer = hitInfo.gameObject.GetComponent<answerReceiver>();
        //  if(answer != null)
        //  {
        //     answer.TakeDamage(damage);
        //  }

        if(hitInfo.gameObject.tag != "bullets") // destroy if collide with anything/dont need?
        {

        // impact = Instantiate(impact, transform.position, Quaternion.identity); *create effect upon collide*
        //GameObject ParticleObject = Instantiate(Particle,transform.position,Quaternion.identity);
        //ParticleSystem Effect = ParticleObject.GetComponent<ParticleSystem>();
        //var main = Effect.main;
        //main.startColor = Sprite.color;

            if(hitInfo.gameObject.layer == 15 && bouncecount != 0)
            {
                Vector3 v = Vector3.Reflect(transform.right, hitInfo.contacts[0].normal);
                float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, rot);
                bouncecount--;
            }
            else
            {
                Destroy(gameObject);

            }
        } 

        // Destroy(impact, 0.5f);
        }
        
    
}
