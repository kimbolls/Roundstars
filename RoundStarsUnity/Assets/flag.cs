using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag : MonoBehaviour
{
    public GameObject currentHolder;
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    public player_flag player;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHolder != null)
        {
           StickFlag(currentHolder);
           if(player.hybernate == true){
            UnStickFlag();
           } 
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        player = hitInfo.gameObject.GetComponent<player_flag>();
    }

    public void StickFlag(GameObject hitObject)
    {
        currentHolder = hitObject.gameObject;
        collider.enabled = false;
        rb.position = currentHolder.transform.position;
        rb.transform.rotation = Quaternion.Euler(0f,0f,0f);
        rb.mass = 0f;
        rb.gravityScale = 0f;
    }

    public void UnStickFlag()
    {
        currentHolder = null;
        collider.enabled = true;
        rb.mass = 1f;
        rb.gravityScale = 1f;
    }
}
