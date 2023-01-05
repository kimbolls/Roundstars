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

    [SerializeField] Image i_medal;
    [SerializeField] Sprite[] s_medal;
    [SerializeField] public float[] points_milestone;
    [SerializeField] public AudioManager audiomanage;
    // Start is called before the first frame update
    void Start()
    {
        audiomanage = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        eventsystem.SetSelectedGameObject(buttonlist[0]);
        updateMedal();
        Time.timeScale = 0f;

        audiomanage.Win_Music();

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
            pointstext.SetText("{0}",score.P1_points);
        }
        else
        {
            winnertext.SetText(PlayerPrefs.GetString("player2Name") + " WINS!");
            scoretext.SetText("{0}",score.player2_correctpoint);
            pointstext.SetText("{0}",score.P2_points);
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

    void updateMedal()
    {
        float WinnerPoints = 0;
        if(score.P1_points > score.P2_points)
        {
            WinnerPoints = score.P1_points;
        }
        else
        {
            WinnerPoints = score.P2_points;
        }

        if(WinnerPoints <= points_milestone[0]) //bronze
        {
            i_medal.sprite = s_medal[0];
        }
        else if(WinnerPoints <= points_milestone[1]) //silver
        {
            i_medal.sprite = s_medal[1];
        }
        else if(WinnerPoints <= points_milestone[2]) //gold
        {
            i_medal.sprite = s_medal[2];
        }
        else //plat
        {
            i_medal.sprite = s_medal[3]; 
        }




    }
}
