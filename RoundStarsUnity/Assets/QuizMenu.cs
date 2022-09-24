using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuizMenu : MonoBehaviour
{
    public GameObject[] buttonlist;
    public GameObject selected;
    public EventSystem eventsystem;

    public MasterQuiz masterquiz;

    public int playerID = 0;
    public bool answerstatus;
    public float answerTimer;
    public float maxanswerTimer;

    // Start is called before the first frame update
    void Start()
    {
        answerstatus = false;
        answerTimer = maxanswerTimer; 
        if(selected != null)
        {
            eventsystem.SetSelectedGameObject(buttonlist[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(answerstatus == false){
            answerTimer -= Time.deltaTime;
            if(answerTimer <= 0 )
            {
                if(playerID ==0){masterquiz.answerTimer1 = answerTimer;}
                else{masterquiz.answerTimer2 = answerTimer;}
                
            }
        }
    }

    public void selectA(){
        if(playerID == 0)
        {
            masterquiz.P1_answer = MasterQuiz.answerEnum.A;
            
        }
        else
        {   
            masterquiz.P2_answer = MasterQuiz.answerEnum.A;
        } 
        disableButton(0);
    }
    public void selectB(){
        if(playerID == 0)
        {
            masterquiz.P1_answer = MasterQuiz.answerEnum.B;
        }
        else
        {   
            masterquiz.P2_answer = MasterQuiz.answerEnum.B;
        }
        disableButton(1);
    }
    public void selectC(){
        if(playerID == 0)
        {
            masterquiz.P1_answer = MasterQuiz.answerEnum.C;
        }
        else
        {   
            masterquiz.P2_answer = MasterQuiz.answerEnum.C;
        }
        disableButton(2);
    }
    public void selectD(){
        if(playerID == 0)
        {
            masterquiz.P1_answer = MasterQuiz.answerEnum.D;
        }
        else
        {   
            masterquiz.P2_answer = MasterQuiz.answerEnum.D;
        }
        disableButton(3);
    }

     void disableButton(int i)
    {
        for(int x = 0; x < buttonlist.Length; x ++)
        {
            if(x != i)
            {
                Button btn = buttonlist[x].GetComponent<Button>();
                btn.interactable = false;
            }
        }

        if(playerID == 0)
        {
            masterquiz.answerTimer1 = answerTimer;
        }
        else{masterquiz.answerTimer2 = answerTimer;}
        answerstatus = true;
    }
}
