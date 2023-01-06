using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer_zone : MonoBehaviour
{
    public int answerID;
    public int playerID;
    public QuizMenu quizmenu;
    public flag Flag_script;
    public P1_Attributes player1;
    public P2_Attributes player2;
    // Start is called before the first frame update
    void Start()
    {
        quizmenu = GameObject.Find("Quiz_Manager").GetComponent<QuizMenu>();
        Flag_script = GameObject.Find("Flag").GetComponent<flag>();

        player1 = GameObject.Find("Player 1").GetComponent<P1_Attributes>();

        GameObject temp = GameObject.Find("Player 2");
        if(temp)
        {
            player2 = GameObject.Find("Player 2").GetComponent<P2_Attributes>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    // always punish player if not their base
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (Flag_script.holderID == 3)
        {
            //do something
        }
        else if (Flag_script.holderID != playerID)
        {
            if(Flag_script.holderID == 1)
            {
                player1.current_hp = 0;
            }
            else
            {
                player2.current_hp = 0;
            }
        }
        else
        {
           quizmenu.UpdateAnswer(playerID, answerID); 
        }
        
        // if(playerID == 1)
        // {
        //     quizmenu.player1_answer = answerID;
        // }
        // else{
        //     quizmenu.player2_answer = answerID;
        // }
        //player = hitInfo.gameObject.GetComponent<player_flag>();
    }
}
