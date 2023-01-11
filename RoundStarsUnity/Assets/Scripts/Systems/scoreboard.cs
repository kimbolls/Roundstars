using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class scoreboard : MonoBehaviour
{
   public GameObject[] menus;
   public GameObject[] playerarea;
   public TMP_Text[] player1_text;
   public TMP_Text[] player2_text;
   WinMenu winmenu_script;
   public score_tracker Score_script;
   public EnemySpawner enemySpawner;
   public GameObject[] win_image;

   public int[] player_correctpoint;
   public int[] player_shotsfired;
   public float[] player_hitrate;
   
    void Start()
    {
        Score_script = GameObject.Find("ScoreHUD").GetComponent<score_tracker>();
        enemySpawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
       
        Score_script.CalculateHitRate();
        player_correctpoint[0] = Score_script.player1_correctpoint;
        player_shotsfired[0] = Score_script.player_shotsfired[0];
        player_hitrate[0] = Score_script.player_hitrate[0];
        
        player1_text[3].SetText(PlayerPrefs.GetString("player1Name"));
        player2_text[3].SetText(PlayerPrefs.GetString("player2Name"));
        if(enemySpawner.gameMode == EnemySpawner.GameModeEnum.Multiplayer)
        {   
            playerarea[1].SetActive(true);
            player_correctpoint[1] = Score_script.player2_correctpoint;
            player_shotsfired[1] = Score_script.player_shotsfired[1];
            player_hitrate[1] = Score_script.player_hitrate[1];

            player2_text[0].SetText("{0}",player_correctpoint[1]);
            player2_text[1].SetText("{0}",player_shotsfired[1]);
            player2_text[2].SetText("{0}%",Mathf.Round(player_hitrate[1]));

            if(player_correctpoint[0] > player_correctpoint[1])
            {
                win_image[0].SetActive(true);
            }
            else
            {
                win_image[1].SetActive(true);
            }


        }
        playerarea[0].SetActive(true);
        player1_text[0].SetText("{0}",player_correctpoint[0]);
        player1_text[1].SetText("{0}",player_shotsfired[0]);
        player1_text[2].SetText("{0}%",Mathf.Round(player_hitrate[0]));        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnQuit(){
        Application.Quit();
    }

    public void OnMenu(){
        SceneManager.LoadScene(0);
    }
    public void OnRestart()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnBack()
    {
        menus[1].SetActive(true);
        menus[0].SetActive(false); 
         
    }
}
