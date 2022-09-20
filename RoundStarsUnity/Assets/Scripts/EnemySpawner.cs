using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   
    private int index;
    private int i,seconds;
    private string secondscount;
    // Start is called before the first frame update
    void Start()
    {
        MaxWaveDuration = WaveDuration;
        Difficulty = DifficultyEnum.Easy;
        index = SpawnPoint.Length;
    }

    // Update is called once per frame
    void Update()
    {
       
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
        WaveDuration -= Time.deltaTime;
        seconds = (int) WaveDuration;
        secondscount = seconds.ToString();

        if(WaveDuration <= 0)
        {
            SpawnWave -= 1;  
            SpawnStatus = true;
            WaveDuration = MaxWaveDuration;

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

    void SpawnControl(float a)
    {
        InvokeRepeating("Spawn_Regular",5f,a);
    }

    
    
}
