using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag_hitbox : MonoBehaviour
{
    public GameObject flagObj;
    public Transform resetPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        flag flag = flagObj.GetComponent<flag>();
        flag.UnStickFlag();
        flagObj.transform.position = resetPoint.position;
    }
}
