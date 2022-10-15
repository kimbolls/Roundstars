using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P1_Attributes : MonoBehaviour
{
    public float max_hp = 100f,current_hp;
    public P1_Movement movement;
    //public float max_mp,current_mp;
    public Slider HP_Slider;

    public bool hybernate = false;
    [SerializeField]
    private Gun1_Shooting shooting;
    private GameObject gun;
    public TMP_Text playername;

    [SerializeField]
    private float bfr_attackrate,bfr_movementspeed;

    public float regen_hp = 5f;
    private bool gunFound = false;
    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
        HP_Slider.maxValue = max_hp;
        playername.SetText(PlayerPrefs.GetString("player1Name"));
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("P1_Gun(Clone)") && gunFound == false)
        {
            FindGun();
        }
        if(current_hp <= 0)
        {
            // enter hybernation, and regen HP until full
            hybernate = true; 
            bfr_attackrate = shooting.attackrate;
            bfr_movementspeed = movement.speed;
            shooting.attackrate = shooting.attackrate / 2;
            movement.speed = movement.speed / 5;
        }
        else if(current_hp >= max_hp && gunFound == true && hybernate==true)
        {
            current_hp = max_hp;
            hybernate = false;
            shooting.attackrate = bfr_attackrate; 
            movement.speed = bfr_movementspeed;
        }   
        if(hybernate == true )
        {
            RegenFull();
           
            // movement.speed = 1f;
        }

         // update player hp with UI 
        HP_Slider.value = current_hp;
        //player_Ui.Setmana(current_mp);
    }

    public void TakeDamage(float damage)
    {

        if(hybernate == true)
        {
            //take no damage
        }
        else{
            current_hp -= damage;

        }
    }

    void RegenFull()
    {
        current_hp += regen_hp * Time.deltaTime;
    }

    void FindGun()
    {
        gun = GameObject.Find("P1_Gun(Clone)");
        shooting = gun.GetComponent<Gun1_Shooting>();
        bfr_attackrate = shooting.attackrate;
        bfr_movementspeed = movement.speed;
        gunFound = true;
    }
}
