using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Customization : MonoBehaviour
{
    public Sprite[] eyes,mouths;
    public SpriteRenderer[] player1renderer;
    public SpriteRenderer[] player2renderer;
    // public GameObject
    //index 0 = eyes, 1 = mouths
    // Start is called before the first frame update
    void Start()
    {
        player1renderer[0].sprite = eyes[PlayerPrefs.GetInt("player1Eyes")];
        player1renderer[1].sprite = mouths[PlayerPrefs.GetInt("player1Mouths")];

        if(player2renderer[0] != null)
        {player2renderer[0].sprite = eyes[PlayerPrefs.GetInt("player2Eyes")];
        player2renderer[1].sprite = mouths[PlayerPrefs.GetInt("player2Mouths")];}

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
