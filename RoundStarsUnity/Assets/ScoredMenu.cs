using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoredMenu : MonoBehaviour
{
    public TMP_Text winText;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        winText.SetText(text);
    }

    public void player1Win()
    {
        text = "SCORE TO PLAYER 1!";
    }

    public void player2Win()
    {   
        text = "SCORE TO PLAYER 2!";
    }
}
