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
    //public float max_timer,quiz_timer;
    public float bracetimer,max_bracetimer;
    public string questionDescription;
   
    public int player1_answer, player2_answer;
    public int TrueAnswer;
    public GameObject questionschosen;
    private bool fetchstatus = false;
    public int levelCount;
    public int player1_upgPoint,player2_upgPoint;
    public EnemySpawner enemyspawner;
    public GameObject[] wallbarrier;
    public GameObject[] questionsList;
    public string[] answerChoices;
    public GameObject quizCanvas;
    public P1_Attributes player1;
    public P2_Attributes player2;
    public score_tracker score;
    public ScoredMenu scoredscript;
    public GameObject scoredmenu;
    public flag flag;
    public float slowMoTimer;  
    public float maxslowMoTimer;  
    public GameObject upgrademenu;
    private bool slowMoStatus = false;
    public upgradescript  UpgradeScript;
    void Start(){

        //quiz_timer = max_timer;
        bracetimer = max_bracetimer;
        TrueAnswer = 1;
        FetchQuestions();
        quizCanvas.SetActive(false);
        player1 = GameObject.Find("Player 1").GetComponent<P1_Attributes>();
        player2 = GameObject.Find("Player 2").GetComponent<P2_Attributes>();
        flag = GameObject.Find("Flag").GetComponent<flag>();
        UpgradeScript = upgrademenu.GetComponent<upgradescript>();
        slowMoTimer = maxslowMoTimer;
        // scoredscript = GameObject.Find("ScoredMenu").GetComponent<ScoredMenu>();
        
    }

    void Update()
    {
        // if(quiz_timer >= 0)
        // {quiz_timer -= Time.deltaTime;}
        quizTimerDisplay.SetText("{0}",Mathf.Round(bracetimer));
        // if(quiz_timer <= 25 && fetchstatus == false)
        // {
        //     fetchstatus = true;
        // }
        // else if(quiz_timer <= 10 && fetchstatus == false)
        // {
        //     fetchstatus = true;
        // }
        
        if(slowMoStatus == true)
        {
            Time.timeScale = 0.2f;
            slowMoTimer -= Time.deltaTime;
            if(slowMoTimer <= 0)
            {
                slowMoTimer = maxslowMoTimer;
                maxslowMoTimer = 0.4f;
                Time.timeScale = 1f;
                slowMoStatus = false;
                scoredmenu.SetActive(false);
                ResetLevel();
            }
        }

        if(bracetimer <= 0)
        {
            DisableBrace();
            quizTimerDisplay.SetText("Fight!");
        }
        else if(bracetimer >= 0)
        {
            // if(bracetimer <= 10)
            // {
                quizCanvas.SetActive(true);
            // }
            bracetimer -= Time.deltaTime;
        }

        
        
        //-------------------
        
    }

    public void UpdateAnswer(int playerID,int answerID)
    {
        
        if(playerID == 1)
        {
            player1_answer = answerID;
            if(player1_answer == TrueAnswer)
            {
                Debug.Log("correct");
                score.P1_score += 100;
                player1_upgPoint++;
                slowMoStatus = true;
                scoredmenu.SetActive(true);
                scoredscript.player1Win();
                // ResetLevel(1);
            }
            else{
                player1.current_hp = 0;
            }
        }
        else{
            player2_answer = answerID;
            if(player2_answer == TrueAnswer)
            {
                Debug.Log("correct");
                score.P2_score += 100;
                player2_upgPoint++;
                slowMoStatus = true;
                scoredmenu.SetActive(true);
                scoredscript.player2Win();
                // ResetLevel(2);
            }
            else
            {
                player2.current_hp = 0;
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
            // if(answerChoices[x] == questionsScript.TrueAnswer)
            // {
            //     TrueAnswer = x;
            // }

        }
        for(int x = 0; x < answerChoices.Length; x++)
        {
            answerdescription[x].SetText(answerChoices[x]);
            if(answerChoices[x] == questionsScript.TrueAnswer)
            {
                TrueAnswer = x;
            }
        }
        questionDescription = questionsScript.questionDescription;
        quizDescription.SetText(questionDescription);   

    }

    void DisableBrace()
    {
        for(int i = 0; i < wallbarrier.Length; i++)
        {
            wallbarrier[i].SetActive(false);
        }
        
    }

    void ActivateBrace()
    {
        for(int i = 0; i < wallbarrier.Length; i++)
        {
            wallbarrier[i].SetActive(true);
        }
    }

    void ResetLevel()
    {
        // if(x == 1)
        // {
        //     player1_upgPoint++;
        // }
        // else{
        //     player2_upgPoint++;
        // }
        //quiz_timer = max_timer;
        bracetimer = max_bracetimer;
        levelCount++;
        ActivateBrace();
        FetchQuestions();
        enemyspawner.ResetPlayerPos(0);
        enemyspawner.ResetPlayerPos(1);

        if(player1_upgPoint == 5)
        {
            
            ResetScore(1);
        }
        else if(player2_upgPoint == 5)
        {
            ResetScore(2);
        }
    }

    void ResetScore(int player)
    {
        player1_upgPoint = 0;
        player2_upgPoint = 0;
        upgrademenu.SetActive(true);
        UpgradeScript.i = player;
        Time.timeScale = 0f;
    }

    void UpgradeTime()
    {
        
    }

    

    



}


