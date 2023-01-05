using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemyspawner;
    [SerializeField] private score_tracker scoretracker;
    [SerializeField] private AudioSource[] Singleplayer_music;
    [SerializeField] private AudioSource[] Multiplayer_music;
    [SerializeField] private AudioSource tutorial_music;
    [SerializeField] public AudioSource upgrade_music;
    [SerializeField] private AudioSource win_music;
    [SerializeField] private AudioSource Current_music;

    [SerializeField] private int phase_num = 1;
    [SerializeField] private float leadingpoint;

    // Start is called before the first frame update
    void Start()
    {
        enemyspawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
        scoretracker = GameObject.Find("ScoreHUD").GetComponent<score_tracker>();
    }

    // Update is called once per frame
    void Update()
    {


        PhaseTracker();
        if (!upgrade_music.isPlaying && !win_music.isPlaying)
        {
            if (enemyspawner.gameMode == EnemySpawner.GameModeEnum.Singleplayer)
            {
                Single_music();
            }
            else if (enemyspawner.gameMode == EnemySpawner.GameModeEnum.Multiplayer)
            {
                Multi_music();
            }
            else
            {
                Tuto_music();
            }
        }
    }

    void PhaseTracker()
    {
        float P1_points = scoretracker.P1_points;
        float P2_points = scoretracker.P2_points;
        leadingpoint = P1_points;


        if (P1_points > P2_points)
        {
            leadingpoint = P1_points;
        }
        else if (P1_points < P2_points)
        {
            leadingpoint = P2_points;
        }
        else if (P1_points == P2_points)
        {
            leadingpoint = P1_points;
        }


        if (leadingpoint <= scoretracker.points_milestone[0])
        {
            phase_num = 1;
        }
        else if (leadingpoint <= scoretracker.points_milestone[1])
        {
            phase_num = 2;
        }
        else
        {
            phase_num = 3;
        }
    }
    void Single_music()
    {
        if (phase_num == 1 && !Singleplayer_music[0].isPlaying && !upgrade_music.isPlaying)
        {
            Singleplayer_music[0].Play();
            Current_music = Singleplayer_music[0];
        }
        else if (phase_num == 2 && !Singleplayer_music[1].isPlaying && !upgrade_music.isPlaying)
        {
            Current_music.Stop();
            Singleplayer_music[1].Play();
            Current_music = Singleplayer_music[1];
        }
        else if (phase_num == 3 && !Singleplayer_music[2].isPlaying && !upgrade_music.isPlaying)
        {
            Current_music.Stop();
            Singleplayer_music[2].Play();
            Current_music = Singleplayer_music[2];
        }
    }

    void Multi_music()
    {
        if (phase_num == 1 && !Multiplayer_music[0].isPlaying && !upgrade_music.isPlaying)
        {
            Multiplayer_music[0].Play();
            Current_music = Multiplayer_music[0];
        }
        else if (phase_num == 2 && !Multiplayer_music[1].isPlaying && !upgrade_music.isPlaying)
        {
            Current_music.Stop();
            Multiplayer_music[1].Play();
            Current_music = Multiplayer_music[1];
        }
        else if (phase_num == 3 && !Multiplayer_music[2].isPlaying && !upgrade_music.isPlaying)
        {
            Current_music.Stop();
            Multiplayer_music[2].Play();
            Current_music = Multiplayer_music[2];
        }
    }

    void Tuto_music()
    {
        if (!tutorial_music.isPlaying)
        {
            tutorial_music.Play();
        }
    }

    public void Upgrade_Music(int i)
    {
        if (i == 0)
        {
            Current_music.Pause();
            upgrade_music.Play();
        }
        else
        {
            Current_music.UnPause();
            upgrade_music.Stop();
        }
    }

    public void Win_Music()
    {
        Current_music.Stop();
        win_music.Play();
    }

}
