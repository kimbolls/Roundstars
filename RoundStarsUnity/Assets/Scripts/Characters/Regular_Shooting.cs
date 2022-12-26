using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular_Shooting : MonoBehaviour
{

    public GameObject GunPrefab;
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject Gun;
    public Enemy_Movement movement;

    [SerializeField]
    private GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        Gun = Instantiate(GunPrefab,rb.position,Quaternion.identity);
        aim = movement.aimedplayer;
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        aim = movement.aimedplayer;
        StickGun();
    }

    void StickGun()
    {
        Transform PlayerPosition = aim.GetComponent<Transform>();
        Vector2 PlayerPos = PlayerPosition.position;
        Rigidbody2D Gunrb = Gun.GetComponent<Rigidbody2D>();
        Transform GunPosition = Gun.GetComponent<Transform>();
        Vector2 lookDir = PlayerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        Gunrb.position = rb.position;
        Gunrb.rotation = angle;
    }
}
