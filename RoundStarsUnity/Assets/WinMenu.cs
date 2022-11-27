using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public GameObject[] buttonlist;
    public GameObject selected;
    public EventSystem eventsystem;
    public EnemySpawner enemyspawner;
    public TMP_Text winnertext,scoretext;
    public TMP_Text pointstext;

    public GameObject[] menus;

    public score_tracker score;
    // Start is called before the first frame update
    void Start()
    {
        eventsystem.SetSelectedGameObject(buttonlist[0]);
        
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnResume(){
        enemyspawner.ResumeGame();
    }

    public void OnMenu(){
        SceneManager.LoadScene(0);
    }
    public void OnQuit(){
        Application.Quit();
    }

    public void SetWinner(int x)
    {
        enemyspawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
        if(x == 0)
        {
            winnertext.SetText(PlayerPrefs.GetString("player1Name") + " WINS!");
            scoretext.SetText("{0}",score.player1_correctpoint);
        }
        else
        {
            winnertext.SetText(PlayerPrefs.GetString("player2Name") + " WINS!");
            scoretext.SetText("{0}",score.player2_correctpoint);
        }

        if(enemyspawner.gameMode == EnemySpawner.GameModeEnum.Singleplayer)
        {
            
            
            winnertext.SetText("TIME OUT!");
            pointstext.SetText("{0}",score.P1_points);
        }
    }
    public void OnRestart()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnScoreBoard()
    {
        
        menus[1].SetActive(true);
        menus[0].SetActive(false); 
    }
}
