using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class QuizMenu : MonoBehaviour
{
    public TMP_Text quizDescription;
    public TMP_Text quizTimerDisplay;
    public TMP_Text[] answerdescription;

    public float max_timer,quiz_timer;
    public string[] answerChoices;

    public string questionDescription;
   
    public int player1_answer, player2_answer;
    public int TrueAnswer;
    public GameObject[] questionsList;
    
    public GameObject questionschosen;
    private bool fetchstatus = false;
    void Start(){

        quiz_timer = max_timer;
        TrueAnswer = 1;
        FetchQuestions();
    }

    void Update()
    {
        if(quiz_timer >= 0)
        {quiz_timer -= Time.deltaTime;}
        quizTimerDisplay.SetText("{0}",Mathf.Round(quiz_timer));
        if(quiz_timer <= 25 && fetchstatus == false)
        {
            fetchstatus = true;
        }
        else if(quiz_timer <= 10 && fetchstatus == false)
        {
            fetchstatus = true;
        }
    }

    public void UpdateAnswer(int playerID,int answerID)
    {
        if(playerID == 1)
        {
            player1_answer = answerID;
            if(player1_answer == TrueAnswer)
            {
                Debug.Log("correct");
            }
        }
        else{
            player2_answer = answerID;
            if(player2_answer == TrueAnswer)
            {
                Debug.Log("correct");
            }
        }
    }

    void FetchQuestions()
    {
        int i = Random.Range(0,questionsList.Length);
        questionschosen = questionsList[i];
        questions questionsScript = questionschosen.GetComponent<questions>();
        for(int x = 0; x < questionsScript.answerChoices.Length; x++)
        {
            answerChoices[x] = questionsScript.answerChoices[x];

        }
        for(int x = 0; x < answerChoices.Length; x++)
        {
            int rnd = Random.Range(0, answerChoices.Length);
            string tempGO = answerChoices[rnd];
            answerChoices[rnd] = answerChoices[x];
            answerChoices[x] = tempGO;
            if(answerChoices[x] == questionsScript.TrueAnswer)
            {
                TrueAnswer = x;
            }

        }
        for(int x = 0; x <answerChoices.Length; x++)
        {
            answerdescription[x].SetText(answerChoices[x]);
        }
        questionDescription = questionsScript.questionDescription;
        quizDescription.SetText(questionDescription);   

    }

    void ShuffleQuestions()
    {
        // string TrueAnswer_1;
        
    }



}


