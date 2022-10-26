using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class score_tracker : MonoBehaviour
{
    public float P1_score,P2_score;
    public TMP_Text P1_scoreText,P2_scoreText;
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
    public TMP_Text p1score_text,p2score_text;

    public  int player1_correctpoint,player2_correctpoint;
    public Slider braceslider;
    public float bracemax,bracecur;
    // Start is called before the first frame update
    void Start()
    {
        slidermaxvalue = gametimer;
        P1_score = 0;
        P2_score = 0;
        gametimer_slider.maxValue = slidermaxvalue;
        bracemax = quizmenu.max_bracetimer;
        braceslider.maxValue = bracemax;
        // set color

        //

    }

    // Update is called once per frame
    void Update()
    {   
        gametimer_text.SetText("{0}",Mathf.Round(gametimer));
        p1score_text.SetText("{0}",player1_correctpoint);
        p2score_text.SetText("{0}",player2_correctpoint);
        gametimer_slider.value = gametimer;

        // if(quizmenu.bracetimer == quizmenu.max_bracetimer)
        // {
        //     bracecur = 0;
        // }
        if(quizmenu.bracetimer > 0)
        {
            bracecur += Time.deltaTime;
        }

        if(gametimer <= 0)
        {
            gametimer_text.SetText("OVERTIME");
        }

        braceslider.value = bracecur;

        //game timer
        // if(quizmenu.bracetimer < 0)
        // {
        //     gametimer -= Time.deltaTime;
        // }
        gametimer -= Time.deltaTime;
        if(gametimer <= 0)
        {
            gametimer = 0;
        }
        //adaptive scoreboard here

        //display score
        P1_scoreText.SetText ("{0} Pts",P1_score);
        P2_scoreText.SetText ("{0} Pts",P2_score);

        //display upgrade points
        if(quizmenu.player1_upgPoint > 0 && quizmenu.player1_upgPoint < 5)
        {
            for(int i = 0; i < quizmenu.player1_upgPoint; i++)
            {
                imagesprite = p1_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite = spritelist[1];
            }
        }
        else if(quizmenu.player1_upgPoint == p1_upgradeimage.Length || quizmenu.player1_upgPoint == 0)
        {
            for(int i = 0; i < p1_upgradeimage.Length; i++)
            {
                imagesprite = p1_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite  = spritelist[0];
            }
        }

        if(quizmenu.player2_upgPoint > 0 && quizmenu.player2_upgPoint < 5)
        {
            for(int i = 0; i < quizmenu.player2_upgPoint; i++)
            {
                imagesprite = p2_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite  = spritelist[1];
            }
        }
        else if(quizmenu.player2_upgPoint == p2_upgradeimage.Length || quizmenu.player2_upgPoint == 0)
        {
            for(int i = 0; i < p2_upgradeimage.Length; i++)
            {
                imagesprite = p2_upgradeimage[i];
                imagesprite.GetComponent<Image>().sprite  = spritelist[0];
            }
        }
    }

    public void addScore(float enemyValue,int player)
    {
        if(player == 1)
        {
            P1_score += enemyValue;
        }
        else
        {
            P2_score += enemyValue;
        }
    }


}
