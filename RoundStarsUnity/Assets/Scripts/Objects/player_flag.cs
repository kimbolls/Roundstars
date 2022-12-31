using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_flag : MonoBehaviour
{
    public int playerID;
    public bool hybernate = false;
    public P1_Attributes player1;
    public P2_Attributes player2;
    public float playerHP;
    public GameObject ThisPlayer;
    public EnemySpawner enemySpawner;
    void Start()
    {
        enemySpawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
        player1 = GameObject.Find("Player 1").GetComponent<P1_Attributes>();

        if(enemySpawner.gameMode != EnemySpawner.GameModeEnum.Singleplayer)
        {
            player2 = GameObject.Find("Player 2").GetComponent<P2_Attributes>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerID == 1)
        {
            hybernate = player1.hybernate;
            playerHP = player1.current_hp;
        }
        else
        {
            hybernate = player2.hybernate;
            playerHP = player2.current_hp;
        }
        
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        flag FlagInfo = hitInfo.gameObject.GetComponent<flag>();
        if(FlagInfo != null && hybernate == false)
        {
            
            FlagInfo.StickFlag(ThisPlayer);

        }
    }
}
