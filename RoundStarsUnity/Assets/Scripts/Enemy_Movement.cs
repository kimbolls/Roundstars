using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject player1,player2;
    public Rigidbody2D rb;
    public GameObject aimedplayer;
    public float speed;
    public float aimtimer;
    public float maxaimtimer;
    
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        RandomAim();

    }

    // Update is called once per frame
    void Update()
    {
        aimtimer -= Time.deltaTime;
        if(aimtimer <= 0)
        {
            if(aimedplayer == player1)
            {
                aimedplayer = player2;
            }
            else
            {
                aimedplayer = player1;
            }
            aimtimer = maxaimtimer;
        }
    }

    void FixedUpdate()
    {

        Transform PlayerPosition = aimedplayer.GetComponent<Transform>();
        Vector2 PlayerPos = PlayerPosition.position;
        Vector2 Move = PlayerPos - rb.position;
        float moveBy = Move.x * speed;  // multiply the input with speed 
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        
    }

    void RandomAim(){
        
        int num = Random.Range(0,2);
        if(num == 0)
        {
            aimedplayer =  player1;
        }
        else if(num == 1)
        {
            aimedplayer =  player2;
        }
        
    
    }
}
