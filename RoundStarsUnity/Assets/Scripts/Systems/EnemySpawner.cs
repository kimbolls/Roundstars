using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Transform[] SpawnPoint;


    [SerializeField]
    public enum GameModeEnum { Singleplayer, Multiplayer, Tutorial };
    [SerializeField]
    private GameObject enemy_1;
    [SerializeField]
    private GameObject enemy_2;
    [SerializeField]
    public bool SpawnStatus = true;
    public GameModeEnum gameMode;
    public enum PhaseEnum { Game, Upgrade, Quiz, Pause };
    public PhaseEnum phase;
    public GameObject pausemenu;
    private int index;
    private int i, seconds;
    public bool paused;
    public Transform[] player_respawn;
    public GameObject[] Player;
    public QuizMenu quizmenu;
    public score_tracker scoretracker;
    public GameObject[] enemyList;
    public GameObject[] bulletList;
    public int tempvar = 0;

    public void OnPaused(InputAction.CallbackContext context)
    {

        paused = context.action.triggered;
        PauseGame(paused);
    }
    void Start()
    {
        //find scripts
        quizmenu = GameObject.Find("Quiz_Manager").GetComponent<QuizMenu>();
        scoretracker = GameObject.Find("ScoreHUD").GetComponent<score_tracker>();
        // pausemenu = GameObject.Find("PauseMenu");
        //
        SpawnStatus = true;
        index = SpawnPoint.Length;
        Player[0] = GameObject.Find("Player 1");
        Player[1] = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        // timer_display.SetText("{0}",Mathf.Round(WaveDuration));
        // WaveDuration -= Time.deltaTime;
        // seconds = (int) WaveDuration;
        // secondscount = seconds.ToString();

        if (gameMode == GameModeEnum.Singleplayer)
        {
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            bulletList = GameObject.FindGameObjectsWithTag("bullets");
            SpawnControl();
        }


    }

    int Randomize(int num)
    {
        num = Random.Range(0, index);
        return num;
    }

    void SpawnControl()
    {


        if (quizmenu.bracetimer <= 0)
        {
            if (SpawnStatus == true)
            {
                float delay, intervals;
                int playerpoints = scoretracker.player1_correctpoint;
                if (playerpoints <= 4)
                {
                    delay = 4f;
                    intervals = 8f;
                    tempvar++;
                }
                else if (playerpoints <= 7)
                {
                    delay = 3f;
                    intervals = 6f;
                    tempvar++;
                }
                else
                {
                    delay = 2f;
                    intervals = 4f;
                    tempvar++;
                }
                Spawn_Repeating(delay, intervals);
                SpawnStatus = false;

                Debug.Log("Spawner Active : " + tempvar + "/ Intervals = " + intervals);
            }
        }

        if (quizmenu.bracetimer == quizmenu.max_bracetimer)
        {
            SpawnStatus = true;
        }

    }

    public void PauseGame(bool paused)
    {
        if (pausemenu == null)
        {
            Debug.Log("pausemenu empty");
            pausemenu = GameObject.Find("PauseMenu");
        }
        if (paused && phase == PhaseEnum.Game)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
            phase = PhaseEnum.Pause;
        }
        else if (paused && phase == PhaseEnum.Pause)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        phase = PhaseEnum.Game;
        Time.timeScale = 1f;
    }



    void Spawn_Repeating(float delay, float intervals)
    {
        InvokeRepeating("Spawn_Regular", delay, intervals);
        InvokeRepeating("Spawn_Tank", delay + 5f, intervals + 4f);
    }

    public void Spawn_Stop()
    {
        CancelInvoke("Spawn_Regular");
        CancelInvoke("Spawn_Tank");
    }

    // enemy spawn
    void Spawn_Regular()
    {
        i = Randomize(i);
        GameObject enemy_1_spawn = Instantiate(enemy_1, SpawnPoint[i].position, Quaternion.identity);
    }

    void Spawn_Tank()
    {
        i = Randomize(i);
        GameObject enemy_1_spawn = Instantiate(enemy_2, SpawnPoint[i].position, Quaternion.identity);
    }
    //

    public void ResetPlayerPos(int i)
    {
        Player[i].transform.position = player_respawn[i].position;

    }

}
