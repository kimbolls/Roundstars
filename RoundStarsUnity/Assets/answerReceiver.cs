using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerReceiver : MonoBehaviour
{
    public float max_hp;
    public float current_hp;

    // public enum answerEnum {A,B,C,D};
    // answerEnum answer;

    public char answer;
    public int player;
    private Regular_projectile projectile;
    private float damage;
    [SerializeField]
    private float timer;
    private bool timerstatus = true;

    public int indexNum;


    public MasterQuiz masterquiz;
    // Start is called before the first frame update
    void Start()
    {   
        current_hp = max_hp;
        timer = masterquiz.max_timer;
    }

    // Update is called once per frame
    void Update()
    {

        if(timerstatus ==true){
            timer -= Time.deltaTime;
        }
       
    }

    

    public void TakeDamage(float damage)
    {
        current_hp--;
        if(current_hp <= 0)
        {
            timerstatus = false;
            masterquiz.getAnswer(answer,player,timer,indexNum);
            Destroy(gameObject);
        }
    } 

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        
        if(hitInfo.gameObject.layer == 10)
        {
            projectile = hitInfo.gameObject.GetComponent<Regular_projectile>();
            damage = projectile.damage;
            TakeDamage(damage);
        }
        else if(hitInfo.gameObject.layer == 11)
        {
            projectile = hitInfo.gameObject.GetComponent<Regular_projectile>();
            damage = projectile.damage;
            TakeDamage(damage);
        }
    }
}
