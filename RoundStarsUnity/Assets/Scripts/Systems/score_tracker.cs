using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class score_tracker : MonoBehaviour
{
    public float P1_points, P2_points;
    public GameObject[] p1_upgradeimage;
    public GameObject[] p2_upgradeimage;
    // public GameObject p1_charimage,p2_charimage;
    // public GameObject p1_upimage,p2_upimage;
    public Sprite[] spritelist;
    public QuizMenu quizmenu;
    private GameObject imagesprite;

    public float gametimer;
    public TMP_Text gametimer_text;
    public Slider gametimer_slider;
    private float slidermaxvalue;
    public TMP_Text p1score_text, p2score_text;
    public TMP_Text p1points_text;

    public int player1_correctpoint, player2_correctpoint;
    public Slider braceslider;
    public float bracemax, bracecur;

    public int[] player_shotsfired;
    public float[] player_hitrate;
    public int[] player_shotsHit;

    public EnemySpawner enemySpawner;
    [SerializeField] public float[] points_milestone;
    public WinMenu winmenu;
    public TMP_Text[] playername_text;
    // Start is called before the first frame update
    void Start()
    {
        SetTimer();
        enemySpawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
        winmenu.points_milestone = points_milestone;
        slidermaxvalue = gametimer;
        P1_points = 0;
        P2_points = 0;

        playername_text[0].SetText(PlayerPrefs.GetString("player1Name"));
        playername_text[1].SetText(PlayerPrefs.GetString("player2Name"));
        if (!PlayerPrefs.HasKey("highscore_points")) PlayerPrefs.SetFloat("highscore_points", 0f);
        float highpoints = PlayerPrefs.GetFloat("highscore_points");
        Debug.Log("Highscore" + highpoints);
    }

    // Update is called once per frame
    void Update()
    {

        //primary scoreboard HUD
        gametimer_text.SetText("{0}", Mathf.Round(gametimer));
        p1score_text.SetText("{0}", P1_points);
        if (enemySpawner.gameMode == EnemySpawner.GameModeEnum.Singleplayer)
        {
            p1points_text.SetText(player1_correctpoint.ToString());
        }
        else
        {
            p2score_text.SetText("{0}", P2_points);
        }
        gametimer_slider.value = gametimer;

        if (quizmenu.bracetimer > 0)
        {
            bracecur += Time.deltaTime;
        }

        if (gametimer <= 0)
        {
            gametimer_text.SetText("OVERTIME");
        }

        braceslider.value = bracecur;
        if (enemySpawner.gameMode != EnemySpawner.GameModeEnum.Tutorial)
        {
            gametimer -= Time.deltaTime;
        }

        if (gametimer <= 0)
        {
            gametimer = 0;
        }

        //display upgrade points
        DisplayUpgrade();
    }

    void DisplayUpgrade()
    {
        if (quizmenu.player1_upgPoint > 0 && quizmenu.player1_upgPoint < 3)
        {
            for (int i = 0; i < quizmenu.player1_upgPoint; i++)
            {
                imagesprite = p1_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite = spritelist[1];
            }
        }
        else if (quizmenu.player1_upgPoint == p1_upgradeimage.Length || quizmenu.player1_upgPoint == 0)
        {
            for (int i = 0; i < p1_upgradeimage.Length; i++)
            {
                imagesprite = p1_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite = spritelist[0];
            }
        }

        if (quizmenu.player2_upgPoint > 0 && quizmenu.player2_upgPoint < 3)
        {
            for (int i = 0; i < quizmenu.player2_upgPoint; i++)
            {
                imagesprite = p2_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite = spritelist[1];
            }
        }
        else if (quizmenu.player2_upgPoint == p2_upgradeimage.Length || quizmenu.player2_upgPoint == 0)
        {
            for (int i = 0; i < p2_upgradeimage.Length; i++)
            {
                imagesprite = p2_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite = spritelist[0];
            }
        }
    }

    public void addScore(float enemyValue, int player)
    {
        if (player == 1)
        {
            P1_points += enemyValue;
        }
        else
        {
            P2_points += enemyValue;
        }
    }

    public void SetTimer()
    {
        int x;

        x = PlayerPrefs.GetInt("GameTimer");

        Debug.Log(x);

        if (x == 0) { gametimer = 90; }
        else if (x == 1) { gametimer = 180; }
        else { gametimer = 300; }

        gametimer_slider.maxValue = slidermaxvalue;
        bracemax = quizmenu.max_bracetimer;
        braceslider.maxValue = bracemax;

    }

    public void ShotsTracker(int x, int type, int player)
    {
        if (type == 0) //shots fired
        {
            player_shotsfired[player] += x;
        }
        else //shots confirmed
        {
            player_shotsHit[player]++;
        }
    }

    public void CalculateHitRate()
    {
        if (player_shotsfired[0] == 0)
        {
            player_hitrate[0] = 0;
        }
        else
        {
            player_hitrate[0] = 100 * ((float)player_shotsHit[0] / (float)player_shotsfired[0]);
        }

        if (player_shotsfired[1] == 0)
        {
            player_hitrate[1] = 0;
        }
        else
        {
            player_hitrate[1] = 100 * ((float)player_shotsHit[1] / (float)player_shotsfired[1]);
        }
    }


}
