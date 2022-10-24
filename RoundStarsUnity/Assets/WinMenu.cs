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
    void OnQuit(){

    }

    public void SetWinner(int x)
    {
        if(x == 0)
        {
            winnertext.SetText("PLAYER " + PlayerPrefs.GetString("player1Name") + " WINS!");
            scoretext.SetText("{0}",score.player1_correctpoint);
        }
        else
        {
            winnertext.SetText("PLAYER " + PlayerPrefs.GetString("player2Name") + " WINS!");
            scoretext.SetText("{0}",score.player2_correctpoint);
        }
    }
}
