using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_Attributes : MonoBehaviour
{

    public float max_hp,current_hp;
    //public bool alive_status = true;

    public score_tracker score;
    public Regular_Shooting shooting;
    public Slider HP_Slider; 
    public bool alive_status = true;

    [SerializeField]
    private float enemyValue;

    private Regular_projectile projectile;
    private float damage;

    

    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
        score = GameObject.Find("ScoreHUD").GetComponent<score_tracker>();
        
       // HP_Slider.maxValue = max_hp;

    }

    // Update is called once per frame
    void Update()
    {
        //HP_Slider.value = current_hp;
    }

    public void TakeDamage(float damage,int player)
    {
        current_hp -= damage;
        if(current_hp <= 0 && alive_status == true)
        {
            //score increase to player here
            score.addScore(enemyValue,player);
            Destroy(shooting.Gun);
            current_hp = 0;
            alive_status = false;
            Destroy(gameObject);
        }
    }   

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        
        if(hitInfo.gameObject.layer == 10)
        {
            projectile = hitInfo.gameObject.GetComponent<Regular_projectile>();
            damage = projectile.damage;
            TakeDamage(damage,1);
            score.ShotsTracker(0,1,0);
        }
        else if(hitInfo.gameObject.layer == 11)
        {
            projectile = hitInfo.gameObject.GetComponent<Regular_projectile>();
             damage = projectile.damage;
            TakeDamage(damage,2);
            score.ShotsTracker(0,1,1);
        }
    }
}
