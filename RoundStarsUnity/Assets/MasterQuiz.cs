using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterQuiz : MonoBehaviour
{
    // public enum answerEnum{A,B,C,D};
    // public answerEnum P1_answer = answerEnum.A;
    // public answerEnum P2_answer = answerEnum.A;
    public char P1_answer;
    public char P2_answer;
    public GameObject[] P1_choices;
    public GameObject[] P2_choices;

    public float P1_timer,P2_timer;
    public float max_timer;
    public float quiz_timer;
    // Start is called before the first frame update
    void Start()
    {
        quiz_timer = max_timer;
        for(int i =0; i < P1_choices.Length; i++)
        {
            answerReceiver answerreceiver = P1_choices[i].GetComponent<answerReceiver>();
            answerreceiver.indexNum = i;
        }
        for(int i =0; i < P2_choices.Length; i++)
        {
            answerReceiver answerreceiver = P2_choices[i].GetComponent<answerReceiver>();
            answerreceiver.indexNum = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        quiz_timer -= Time.deltaTime;
    }

    public void getAnswer(char answer,int player,float timer,int indexNum)
    {
        if(player == 1)
        {
            P1_answer = answer;
            P1_timer = timer;
            for(int i = 0; i < P1_choices.Length; i++)
            {
                if(i != indexNum)
                {
                    Destroy(P1_choices[i]);
                }
            }
        }
        else if(player == 2)
        {
            P2_answer = answer;
            P2_timer = timer;
             for(int i = 0; i < P2_choices.Length; i++)
            {
                if(i != indexNum)
                {
                    Destroy(P2_choices[i]);
                }
            }
        }
    }
}
