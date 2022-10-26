using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpslider_script : MonoBehaviour
{
    public Image hpfill;
    public Slider hpslider;
    // Start is called before the first frame update

    public Color cautioncolor,healthycolor,dangercolor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(hpslider.value <= 60 && hpslider.value > 30)
        {
            hpfill.color  = cautioncolor;
        }
        else if(hpslider.value <= 30)
        {
            hpfill.color = dangercolor;
        }
        else
        {
            hpfill.color = healthycolor;
        }
    }
}
