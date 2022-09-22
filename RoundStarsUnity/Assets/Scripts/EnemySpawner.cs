using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Transform[] SpawnPoint;
    [SerializeField]
    private int SpawnWave;
    [SerializeField]
    private float MaxWaveDuration;
    [SerializeField]
    private float WaveDuration;
    [SerializeField]
    public enum DifficultyEnum{Easy,Normal,Hard};
    [SerializeField]
    private GameObject enemy_1;
    [SerializeField]
    private bool SpawnStatus = true;
    public DifficultyEnum  Difficulty;
    public enum PhaseEnum{Game,Upgrade,Quiz,Pause};
    public PhaseEnum phase;
    public Master_Navigator masterNavi;
    
    public GameObject QuizMenu;
    public GameObject PauseMenu;
    private int index;
    private int i,seconds;
    private string secondscount;
    // public bool paused;
    [SerializeField]
    private TMP_Text timer_display;
    // Start is called before the first frame update
    void Start()
    {
        WaveDuration = MaxWaveDuration;
        Difficulty = DifficultyEnum.Easy;
        index = SpawnPoint.Length;
    }

    // Update is called once per frame
    void Update()
    {
        timer_display.SetText("{0}",Mathf.Round(WaveDuration));
        PhaseControl();
        PauseGame(false);
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
        WaveDuration -= Time.deltaTime;
        seconds = (int) WaveDuration;
        secondscount = seconds.ToString();

        

        if(WaveDuration <= 0)
        {
            SpawnWave -= 1;  
            SpawnStatus = true;
            WaveDuration = MaxWaveDuration;
            phase = PhaseEnum.Quiz;
            PhaseChange(PhaseEnum.Quiz);
        }
        if(SpawnWave == 5 && SpawnStatus == true) 
        {
            if(Difficulty == DifficultyEnum.Easy)
                {
                    SpawnControl(5f);
                }
            else if(Difficulty == DifficultyEnum.Normal)
                {
                    SpawnControl(3f);
                }
            else if(Difficulty == DifficultyEnum.Hard)
                {
                    SpawnControl(2f);
                }
            SpawnStatus = false;
        }
        else if(SpawnWave == 4 && SpawnStatus == true) 
        {
            if(Difficulty == DifficultyEnum.Easy)
                {
                    SpawnControl(4f);
                }
            else if(Difficulty == DifficultyEnum.Normal)
                {
                    SpawnControl(3f);
                }
            else if(Difficulty == DifficultyEnum.Hard)
                {
                    SpawnControl(1f);
                }
            SpawnStatus = false;
        }
        
    }

    public void PauseGame(bool paused)
    {
        if(Input.GetKeyDown(KeyCode.Escape) || paused)
        {
            phase = PhaseEnum.Pause;
            PhaseChange(PhaseEnum.Pause);
        }
    }

    void PhaseChange(PhaseEnum phase)
    {
        if(phase == PhaseEnum.Quiz)
        {
            QuizMenu.SetActive(true);
            masterNavi.activemenu = masterNavi.quizmenu;
            Time.timeScale = 0f;
        }
        else if(phase == PhaseEnum.Pause)
        {
            PauseMenu.SetActive(true);
            masterNavi.activemenu = masterNavi.pausemenu;
            Time.timeScale = 0f;
        }
    }

    void SpawnControl(float a)
    {
        InvokeRepeating("Spawn_Regular",5f,a);
    }

    
    
}
