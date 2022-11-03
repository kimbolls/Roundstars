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
    public enum GameModeEnum{Singleplayer,Multiplayer};
    [SerializeField]
    private GameObject enemy_1;
    [SerializeField]
    private bool SpawnStatus = true;
    public GameModeEnum  gameMode;
    public enum PhaseEnum{Game,Upgrade,Quiz,Pause};
    public PhaseEnum phase;
    public GameObject pausemenu;
    private int index;
    private int i,seconds;
    public bool paused;
    public Transform[] player_respawn;
    public GameObject[] Player;

    public void OnPaused(InputAction.CallbackContext context){
        
        paused = context.action.triggered;
        PauseGame(paused);
    }
    void Start()
    {
        
        // Difficulty = DifficultyEnum.Easy;
        
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
        PhaseControl();
    }

    int Randomize(int num)
    {
        num = Random.Range(0,index);
        return num;
    }
// enemy spawn
    void Spawn_Regular()
    {
        i = Randomize(i);
        GameObject enemy_1_spawn = Instantiate(enemy_1,SpawnPoint[i].position,Quaternion.identity);
    }
//
    void DifficultyReflect()
    {

    }
    void PhaseControl()
    {
        

        

        // if(WaveDuration <= 0)
        // {
        //     SpawnWave -= 1;  
        //     SpawnStatus = true;
        //     WaveDuration = MaxWaveDuration;
        //     //phase = PhaseEnum.Quiz;
        //     //Quiztime();
        // }
        // if(SpawnWave == 5 && SpawnStatus == true) 
        // {
        //     if(Difficulty == DifficultyEnum.Easy)
        //         {
        //             SpawnControl(8f);
        //         }
        //     else if(Difficulty == DifficultyEnum.Normal)
        //         {
        //             SpawnControl(3f);
        //         }
        //     else if(Difficulty == DifficultyEnum.Hard)
        //         {
        //             SpawnControl(2f);
        //         }
        //     SpawnStatus = false;
        // }
        // else if(SpawnWave == 4 && SpawnStatus == true) 
        // {
        //     if(Difficulty == DifficultyEnum.Easy)
        //         {
        //             SpawnControl(4f);
        //         }
        //     else if(Difficulty == DifficultyEnum.Normal)
        //         {
        //             SpawnControl(3f);
        //         }
        //     else if(Difficulty == DifficultyEnum.Hard)
        //         {
        //             SpawnControl(1f);
        //         }
        //     SpawnStatus = false;
        // }
        
    }

    public void PauseGame(bool paused)
    {
        if(paused && phase == PhaseEnum.Game)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
            phase = PhaseEnum.Pause;
        }
        else if(paused && phase == PhaseEnum.Pause)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        phase = PhaseEnum.Game;
        Time.timeScale =1f;
    }



    void SpawnControl(float a)
    {
        InvokeRepeating("Spawn_Regular",5f,a);
    }

    public void ResetPlayerPos(int i)
    {
        Player[i].transform.position = player_respawn[i].position;
        
    }
    
}
