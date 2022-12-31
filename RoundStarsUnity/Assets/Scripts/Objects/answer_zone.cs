using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer_zone : MonoBehaviour
{
    public int answerID;
    public int playerID;
    public QuizMenu quizmenu;
    // Start is called before the first frame update
    void Start()
    {
       quizmenu = GameObject.Find("Quiz_Manager").GetComponent<QuizMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        quizmenu.UpdateAnswer(playerID,answerID);
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
