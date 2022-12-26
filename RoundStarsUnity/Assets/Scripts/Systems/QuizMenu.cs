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
   
    public int player1_answer, player2_answer;
    public int TrueAnswer;
    public GameObject questionschosen;
    private bool fetchstatus = false;
    public int levelCount;
    public int player1_upgPoint,player2_upgPoint;
    public EnemySpawner enemyspawner;
    public GameObject[] wallbarrier;
    //  GameObject[] questionsList1;
    //  GameObject[] questionsList2;
    //  GameObject[] questionsList3;
     string[] answerChoices;
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
    public int questiontype;
    public GameObject winmenu,winmenu2;
    public ReadDatabase readdatabase;
    public string questionDescription,correctAnswer;
    public string[] answerDescription = new string[3];
    public int questioncount = 0;

    WinMenu win;

    //new list
    [System.Serializable]
    public class Question
    {
        public string description;
        public string type;
        public string[] possibleAnswer = new string[3];
        public string correctAnswer;
        public bool answerstatus = false;
    }
    [System.Serializable]
    public class QuestionList
    {
        public Question[] questions;
    }
    public QuestionList CurrentQuestionList = new QuestionList();
    void Start(){

        Time.timeScale = 1f;
        questiontype = PlayerPrefs.GetInt("QuestionType");
        //quiz_timer = max_timer;
         GetTimer();
         score.SetTimer();
        bracetimer = max_bracetimer;
        
        // FetchQuestions(questiontype);
        // CreateNewQuestionList();


        quizCanvas.SetActive(false);
        player1 = GameObject.Find("Player 1").GetComponent<P1_Attributes>();
        if(enemyspawner.gameMode == EnemySpawner.GameModeEnum.Multiplayer)
        {
            player2 = GameObject.Find("Player 2").GetComponent<P2_Attributes>();
        }
        
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
                CheckEndGame();
            }
        }
        else
        {
            CheckEndGame();
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
                score.P1_points += 100;
                score.player1_correctpoint++;
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
                score.P2_points += 100;
                score.player2_correctpoint++;
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

    // void FetchQuestions(int questiontype)
    // {
    //     int i;
    //     if(questiontype == 0)
    //     {
    //         do{
    //             i = Random.Range(0,questionsList1.Length);
    //         questionschosen = questionsList1[i];
    //         }while(questionschosen == null);
            
           
    //     }
    //     else if(questiontype == 1)
    //     {
    //         do{
    //         i = Random.Range(0,questionsList2.Length);
    //         questionschosen = questionsList2[i];
    //         }while(questionschosen == null);
    //     }
    //     else if(questiontype == 2)
    //     {
    //         do{
    //         i = Random.Range(0,questionsList3.Length);
    //         questionschosen = questionsList3[i];
    //         }while(questionschosen == null);

    //     }
        
    //     questions questionsScript = questionschosen.GetComponent<questions>();
    //     for(int x = 0; x < questionsScript.answerChoices.Length; x++)
    //     {
    //         answerChoices[x] = questionsScript.answerChoices[x];

    //     }

    //     for(int x = 0; x < answerChoices.Length; x++)
    //     {
    //         int rnd = Random.Range(0, answerChoices.Length);
    //         string tempGO = answerChoices[rnd];
    //         answerChoices[rnd] = answerChoices[x];
    //         answerChoices[x] = tempGO;
    //         // if(answerChoices[x] == questionsScript.TrueAnswer)
    //         // {
    //         //     TrueAnswer = x;
    //         // }

    //     }
    //     for(int x = 0; x < answerChoices.Length; x++)
    //     {
    //         answerdescription[x].SetText(answerChoices[x]);
    //         if(answerChoices[x] == questionsScript.TrueAnswer)
    //         {
    //             TrueAnswer = x;
    //         }
    //     }
    //     questionDescription = questionsScript.questionDescription;
    //     quizDescription.SetText(questionDescription);   
    //     Destroy(questionschosen);

    // }

    void DisableBrace()
    {
        for(int i = 0; i < wallbarrier.Length; i++)
        {
            if(wallbarrier[i] != null)
            {wallbarrier[i].SetActive(false);}
        }
        
    }

    void ActivateBrace()
    {
        for(int i = 0; i < wallbarrier.Length; i++)
        {
            if(wallbarrier[i] != null)
            {wallbarrier[i].SetActive(true);}
        }
    }

    void ResetLevel()
    {
        bracetimer = max_bracetimer;
        score.bracecur = 0;
        levelCount++;
        
        questioncount++;
        Debug.Log(CurrentQuestionList.questions.Length);
        if(questioncount >= CurrentQuestionList.questions.Length)  //end game if all q answered
        {CheckEndGame();
        Debug.Log("endgame");}
        else{FetchQuestions2();}
        enemyspawner.ResetPlayerPos(0);
        ActivateBrace();
        if(enemyspawner.gameMode == EnemySpawner.GameModeEnum.Multiplayer)
        {   
            
            
            enemyspawner.ResetPlayerPos(1);
            player2.current_hp = player2.max_hp;
        }
        else
        {
            enemyspawner.SpawnStatus = true;
            if(enemyspawner.tempvar >= 1)
            {
                enemyspawner.Spawn_Stop();
            }
            for(int i = 0; i < enemyspawner.enemyList.Length; i++) //destroy enemy on reset
            {
                if(enemyspawner.enemyList[i] != null)
                {
                    Destroy(enemyspawner.enemyList[i]);
                }
                
            }

            for(int i = 0; i < enemyspawner.bulletList.Length; i++) //destroy bulelt on reset
            {
                if(enemyspawner.bulletList[i] != null)
                {
                    Destroy(enemyspawner.bulletList[i]);
                }
            }
        }
       

        player1.current_hp = player1.max_hp;
       

        if(player1_upgPoint == 3)
        {
            
            ResetScore(1);
        }
        else if(player2_upgPoint == 3)
        {
            ResetScore(2);
        }

        // if(score.player1_correctpoint != score.player2_correctpoint)
        // { 
        //     if(score.gametimer <= 0 )
        //     {
        //         WinMenu win = winmenu.GetComponent<WinMenu>();
        //         winmenu.SetActive(true);
        //         if(score.player1_correctpoint > score.player2_correctpoint)
        //         {
        //             win.SetWinner(0);
        //         }
        //         else
        //         {
        //             win.SetWinner(1);
        //         }
        //     }
        // }
    }

    void ResetScore(int player)
    {
        player1_upgPoint = 0;
        player2_upgPoint = 0;
        upgrademenu.SetActive(true);
        UpgradeScript.i = player;
        Time.timeScale = 0f;
    }

    public void CreateNewQuestionList()
    {
        //get questions type
        string y = readdatabase.uniquetype[questiontype];

        int x = 0;
        int tablesize = 0;
        // Debug.Log(readdatabase.myQuestionList.questions.Length);

        //initialize list size
        for(int i = 0; i < readdatabase.myQuestionList.questions.Length; i++)
        {
            if(readdatabase.myQuestionList.questions[i].type == y)
            {
                tablesize++;
            }
        }
        CurrentQuestionList.questions = new Question[tablesize];


        //enter list datas
        for(int i = 0; i < readdatabase.myQuestionList.questions.Length; i++)
        {
            if(readdatabase.myQuestionList.questions[i].type == y)
            {
                CurrentQuestionList.questions[x] = new Question();
                CurrentQuestionList.questions[x].type = readdatabase.myQuestionList.questions[i].type;
                CurrentQuestionList.questions[x].description = readdatabase.myQuestionList.questions[i].description;
                CurrentQuestionList.questions[x].possibleAnswer[0] = readdatabase.myQuestionList.questions[i].possibleAnswer[0];
                CurrentQuestionList.questions[x].possibleAnswer[1] = readdatabase.myQuestionList.questions[i].possibleAnswer[1];
                CurrentQuestionList.questions[x].possibleAnswer[2] = readdatabase.myQuestionList.questions[i].possibleAnswer[2];
                CurrentQuestionList.questions[x].correctAnswer = readdatabase.myQuestionList.questions[i].correctAnswer;
                x++;
            }
        }
        FetchQuestions2();
        
    }
    void FetchQuestions2()
    {
        int i;
        int x = 0;
        
        do{
            i = Random.Range(0,CurrentQuestionList.questions.Length);
           
        }while(CurrentQuestionList.questions[i].answerstatus == true);
        questionDescription = CurrentQuestionList.questions[i].description;
        correctAnswer = CurrentQuestionList.questions[i].correctAnswer;

        
        for(x = 0; x < 3; x++)
        {
            answerDescription[x] = CurrentQuestionList.questions[i].possibleAnswer[x];
        }

        //randomize answer choices
        for(int z = 0; z < 3; z++)
        {
            int rnd = Random.Range(0, 3);
            string tempGO = answerDescription[rnd];
            answerDescription[rnd] = answerDescription[z];
            answerDescription[z] = tempGO;
        }


        for( x = 0; x < 3; x++)
        {
            answerdescription[x].SetText(answerDescription[x]);  
            if(answerDescription[x] == correctAnswer)
            {
                TrueAnswer = x;
                
            }
            
        }
        quizDescription.SetText(questionDescription);  

        //prevents same questions repeated
        CurrentQuestionList.questions[i].answerstatus = true;
        

    }
    public void CheckEndGame()
    {
        if(enemyspawner.gameMode == EnemySpawner.GameModeEnum.Multiplayer)
        {
            if(score.player1_correctpoint != score.player2_correctpoint)
            { 
                if(score.gametimer <= 0 || questioncount >= CurrentQuestionList.questions.Length)
                {
                    if(win == null)
                    {
                        win = winmenu.GetComponent<WinMenu>();
                        winmenu.SetActive(true);
                    }
                   
                    Time.timeScale = 0f;
                    if(score.player1_correctpoint > score.player2_correctpoint)
                    {
                        win.SetWinner(0);
                    }
                    else
                    {
                        win.SetWinner(1);
                    }
                }
            }
        }
        else{
             if(score.gametimer <= 0 || questioncount >= CurrentQuestionList.questions.Length)
                {
                    if(win == null)
                    {
                        win = winmenu2.GetComponent<WinMenu>();
                        winmenu2.SetActive(true);
                    }
                    Debug.Log("Active state" + winmenu2.activeSelf);
                    Time.timeScale = 0f;
                    win.SetWinner(0);
                    
                }
        }
    }

    void GetTimer()
    {
        int y = PlayerPrefs.GetInt("BraceTimer"); 

        if(y == 0){max_bracetimer = 3;}
        else if(y == 1){max_bracetimer = 5;}
        else{max_bracetimer = 10;}
    }

    

    



}


