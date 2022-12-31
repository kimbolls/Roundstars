using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHandler : MonoBehaviour
{
    public TextMesh DamageText;
    void Start()
    {
       Destroy(gameObject,0.8f);
       transform.localPosition += new Vector3(0,0.5f,0); 
    }

    public void DisplayDamage(float damage)
    {
        DamageText.text = damage.ToString(); 
    }

    
}
