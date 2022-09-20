using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class score_tracker : MonoBehaviour
{
    public float P1_score,P2_score;
    public TMP_Text P1_scoreText,P2_scoreText;
    

    
    // Start is called before the first frame update
    void Start()
    {
        P1_score = 0;
        P2_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //adaptive scoreboard here
        P1_scoreText.SetText ("{0} Pts",P1_score);
        P2_scoreText.SetText ("{0} Pts",P2_score);
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
