using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular_projectile : MonoBehaviour
{
    public int damage;
    public GameObject Particle;
    public SpriteRenderer Sprite;
    public int bouncecount = 2;
    void Start()
    {
        // bouncecount = 2;
        StartCoroutine(DestroyAfterTime(3f));
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        P1_Attributes player1 = hitInfo.gameObject.GetComponent<P1_Attributes>();
        if (player1 != null)
        {
            player1.TakeDamage(damage);

        }

        P2_Attributes player2 = hitInfo.gameObject.GetComponent<P2_Attributes>();
        if (player2 != null)
        {
            player2.TakeDamage(damage);

        }


        //  answerReceiver answer = hitInfo.gameObject.GetComponent<answerReceiver>();
        //  if(answer != null)
        //  {
        //     answer.TakeDamage(damage);
        //  }

        if (hitInfo.gameObject.tag != "bullets") // destroy if collide with anything/dont need?
        {




            if (hitInfo.gameObject.layer == 15 && bouncecount != 0)
            {
                Vector3 v = Vector3.Reflect(transform.right, hitInfo.contacts[0].normal);
                float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, rot);
                bouncecount--;
            }
            else
            {
                // impact = Instantiate(impact, transform.position, Quaternion.identity);
                GameObject ParticleObject = Instantiate(Particle, transform.position, Quaternion.identity);
                ParticleSystem Effect = ParticleObject.GetComponent<ParticleSystem>();
                var main = Effect.main;
                main.startColor = Sprite.color;
                Destroy(gameObject);

            }
        }

        // Destroy(impact, 0.5f);
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject ParticleObject = Instantiate(Particle, transform.position, Quaternion.identity);
        ParticleSystem Effect = ParticleObject.GetComponent<ParticleSystem>();
        var main = Effect.main;
        main.startColor = Sprite.color;
        Destroy(gameObject);
    }


}
