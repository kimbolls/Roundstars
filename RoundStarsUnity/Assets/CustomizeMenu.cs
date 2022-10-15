using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomizeMenu : MonoBehaviour
{
    public GameObject Customizechar;
    public GameObject mainmenu;

    public int headIndex,eyesIndex,mouthIndex;
    public GameObject[] headItem,eyesItem,mouthItem;
    public GameObject[] torsoItem;
    public int torsoIndex;
    public TMP_Text playername_display;
    // public TMP_Text playername_edit;
    public TMP_InputField playername_edit;

    public string name;



    public Transform headPos,eyesPos,mouthPos;
    // Start is called before the first frame update
    void Start()
    {
        LoadCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        eyesItem[eyesIndex].SetActive(true);
        mouthItem[mouthIndex].SetActive(true);
        torsoItem[torsoIndex].SetActive(true);
        if(torsoIndex != 1)
        {
            playername_display.SetText(PlayerPrefs.GetString("player1Name"));
        }
        else{
            playername_display.SetText(PlayerPrefs.GetString("player2Name"));
        }
        // eyesItem[eyesIndex].transform.position = eyesPos.position;
    }

    public void ReturnMenu(){
        Customizechar.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void HeadPrev(){
        if(headIndex != 0)
        {
            headIndex--;
        }

    }
    public void HeadNext(){
        if(headIndex != headItem.Length-1)
        {
            headIndex++;
        }
    }
    public void EyesPrev(){
        if(eyesIndex != 0)
        {
            eyesItem[eyesIndex].SetActive(false);
            eyesIndex--;
        }
    }
    public void EyesNext(){
        if(eyesIndex != eyesItem.Length-1)
        {
            eyesItem[eyesIndex].SetActive(false);
            eyesIndex++;
        }
    }
    public void MouthPrev(){
        if(mouthIndex != 0)
        {
            mouthItem[mouthIndex].SetActive(false);
            mouthIndex--;
        }
    }
    public void MouthNext(){
        if(mouthIndex != mouthItem.Length-1)
        {
            mouthItem[mouthIndex].SetActive(false);
            mouthIndex++;
        }
    }

    public void TorsoPrev(){
        if(torsoIndex !=0)
        {
            torsoItem[torsoIndex].SetActive(false);
            torsoIndex--;
            LoadCharacter();
        }
    }

    public void TorsoNext(){
        if(torsoIndex != torsoItem.Length-1)
        {
            torsoItem[torsoIndex].SetActive(false);
            
            torsoIndex++;
            LoadCharacter();
        }
    }
    
    public void SaveCharacter(){
        if(torsoIndex == 0)
        {
            if(!string.IsNullOrWhiteSpace(playername_edit.text))
            {
                PlayerPrefs.SetString("player1Name",playername_edit.text);
                
            }
           
            PlayerPrefs.SetInt("player1Head",headIndex);
            PlayerPrefs.SetInt("player1Eyes",eyesIndex);
            PlayerPrefs.SetInt("player1Mouths",mouthIndex);
        }
        else
        {
            if(!string.IsNullOrWhiteSpace(playername_edit.text))
            {
                PlayerPrefs.SetString("player2Name",playername_edit.text);
                
            }
            PlayerPrefs.SetInt("player2Head",headIndex);
            PlayerPrefs.SetInt("player2Eyes",eyesIndex);
            PlayerPrefs.SetInt("player2Mouths",mouthIndex);
        }
        
    }

    public void LoadCharacter(){
        if(torsoIndex == 0)
        {
            Debug.Log("loadedp1");
            eyesItem[eyesIndex].SetActive(false);
            mouthItem[mouthIndex].SetActive(false);
            torsoItem[torsoIndex].SetActive(false);

            headIndex =  PlayerPrefs.GetInt("player1Head");
            eyesIndex =  PlayerPrefs.GetInt("player1Eyes");
            mouthIndex =  PlayerPrefs.GetInt("player1Mouths");
        }
        else
        {
            Debug.Log("loadedp2");
            eyesItem[eyesIndex].SetActive(false);
            mouthItem[mouthIndex].SetActive(false);
            torsoItem[torsoIndex].SetActive(false);
            headIndex = PlayerPrefs.GetInt("player2Head");
            eyesIndex = PlayerPrefs.GetInt("player2Eyes");
            mouthIndex = PlayerPrefs.GetInt("player2Mouths");
        }
    }
}
