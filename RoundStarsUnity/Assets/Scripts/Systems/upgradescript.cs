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
    private EnemySpawner enemyspawner;
    // shooting
    private Gun1_Shooting player1_gun;
    private Gun2_Shooting player2_gun;
    // movement
    private P1_Movement player1_mov;
    private Player2_Movement player2_mov;
    public TMP_Text playername;
    public GameObject thismenu;
    [SerializeField]
    private float addregen, addatkspd, addmovspd;


    [SerializeField] private Image eyes_image, mouths_image;
    [SerializeField] private GameObject[] torso_image;
    [SerializeField] private Sprite[] eyes_sprites, mouths_sprites;
    public Player_Customization customization;

    public AudioManager audiomanage;
    
    public GameObject[] buttonlist;
    public EventSystem eventsystem;
    // Start is called before the first frame update
    private void OnEnable()
    {
        eventsystem.SetSelectedGameObject(buttonlist[0]);
    }
    void Start()
    {
        eventsystem.SetSelectedGameObject(buttonlist[0]);
        audiomanage = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        enemyspawner = GameObject.Find("GameMaster").GetComponent<EnemySpawner>();
        customization = GameObject.Find("GameMaster").GetComponent<Player_Customization>();
        if (enemyspawner.gameMode == EnemySpawner.GameModeEnum.Multiplayer)
        {
            player2_atr = GameObject.Find("Player 2").GetComponent<P2_Attributes>();
            player2_gun = GameObject.Find("P2_Gun(Clone)").GetComponent<Gun2_Shooting>();
            player2_mov = GameObject.Find("Player 2").GetComponent<Player2_Movement>();
        }
        player1_atr = GameObject.Find("Player 1").GetComponent<P1_Attributes>();
        player1_gun = GameObject.Find("P1_Gun(Clone)").GetComponent<Gun1_Shooting>();
        player1_mov = GameObject.Find("Player 1").GetComponent<P1_Movement>();

        eyes_sprites = customization.eyes;
        mouths_sprites = customization.mouths;


    }

    // Update is called once per frame
    void Update()
    {
        if (i == 1)
        {
            playername.SetText(PlayerPrefs.GetString("player1Name"));
            eyes_image.sprite = eyes_sprites[PlayerPrefs.GetInt("player1Eyes")];
            mouths_image.sprite = mouths_sprites[PlayerPrefs.GetInt("player1Mouths")];
            torso_image[0].SetActive(true);
            torso_image[1].SetActive(false);
        }
        else
        {
            playername.SetText(PlayerPrefs.GetString("player2Name"));
            eyes_image.sprite = eyes_sprites[PlayerPrefs.GetInt("player2Eyes")];
            mouths_image.sprite = mouths_sprites[PlayerPrefs.GetInt("player2Mouths")];
            torso_image[0].SetActive(false);
            torso_image[1].SetActive(true);
        }

        if (!audiomanage.upgrade_music.isPlaying)
            audiomanage.Upgrade_Music(0);
    }

    public void UpgradeNo1()
    {
        thismenu.SetActive(false);
        Debug.Log("Increase hybernation");
        if (i == 1)
        {
            player1_atr.regen_hp += addregen;
        }
        else
        {
            player2_atr.regen_hp += addregen;
        }
        audiomanage.Upgrade_Music(1);
        Time.timeScale = 1f;
    }

    public void UpgradeNo2()
    {
        thismenu.SetActive(false);
        Debug.Log("Increase Attack Speed");
        if (i == 1)
        {
            player1_gun.attackrate += addatkspd;
        }
        else
        {
            player2_gun.attackrate += addatkspd;
        }
        audiomanage.Upgrade_Music(1);
        Time.timeScale = 1f;
    }

    public void UpgradeNo3()
    {
        thismenu.SetActive(false);
        Debug.Log("Increase Mov Speed");
        if (i == 1)
        {
            player1_mov.speed += addmovspd;
        }
        else
        {
            player2_mov.speed += addmovspd;
        }
        audiomanage.Upgrade_Music(1);
        Time.timeScale = 1f;
    }

    public void UpgradeDashCD()
    {
        thismenu.SetActive(false);
        Debug.Log("Reduce Dash CD");

        if (i == 1)
        {
            player1_mov.dashingCooldown -= 1;
        }
        else
        {
            player2_mov.dashingCooldown -= 1;
        }
        audiomanage.Upgrade_Music(1);
        Time.timeScale = 1f;
    }
}
