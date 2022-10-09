using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class upgradescript : MonoBehaviour
{

    public int i; 
    public GameObject activeplayer;
    // attributes
    private P1_Attributes player1_atr;
    private P2_Attributes player2_atr;
    // shooting
    private Gun1_Shooting player1_gun;
    private Gun2_Shooting player2_gun;
    // movement
    private P1_Movement player1_mov;
    private Player2_Movement player2_mov;
    public TMP_Text playername;
    public GameObject thismenu;
    [SerializeField]
    private float addregen,addatkspd,addmovspd;

    // Start is called before the first frame update
    void Start()
    {
        player1_atr = GameObject.Find("Player 1").GetComponent<P1_Attributes>();
        player2_atr = GameObject.Find("Player 2").GetComponent<P2_Attributes>();

        player1_gun = GameObject.Find("P1_Gun(Clone)").GetComponent<Gun1_Shooting>();
        player2_gun = GameObject.Find("P2_Gun(Clone)").GetComponent<Gun2_Shooting>();

        player1_mov = GameObject.Find("Player 1").GetComponent<P1_Movement>();
        player2_mov = GameObject.Find("Player 2").GetComponent<Player2_Movement>();
    
        if(i == 1)
        {
            playername.SetText("PLAYER 1");
            
            
        }
        else{
            playername.SetText("PLAYER 2");
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeNo1(){
        thismenu.SetActive(false);
        Debug.Log("Increase hybernation");
        if(i == 1)
        {
            player1_atr.regen_hp += addregen;
        }
        else
        {
            player2_atr.regen_hp += addregen;
        }
        Time.timeScale = 1f;
    }

    public void UpgradeNo2(){
        thismenu.SetActive(false);
        Debug.Log("Increase Attack Speed");
         if(i == 1)
        {
            player1_gun.attackrate += addatkspd;
        }
        else
        {
            player2_gun.attackrate += addatkspd;
        }
        Time.timeScale = 1f;
    }

    public void UpgradeNo3(){
        thismenu.SetActive(false);
        Debug.Log("Increase Mov Speed");
         if(i == 1)
        {
            player1_mov.speed += addmovspd;
        }
        else
        {
            player2_mov.speed += addmovspd;
        }
        Time.timeScale = 1f;
    }
}
