using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ppFlick : MonoBehaviour
{


    public double[] y;
    int counter = 0, max_counter;

    public int T = 20;

    private float nextActionTime = 0.0f;
    public float period = 0.05f;


    public Volume v;
    private UnityEngine.Rendering.Universal.Vignette vg;

    // Start is called before the first frame update
    void Start()
    {
        max_counter = (int)(T / period);
        Weistrasse ws = new Weistrasse();
        y = ws.CreateSignal(max_counter, 0.05);
        v.profile.TryGet(out vg);
        // You can leave this variable out of your function, so you can reuse it throughout your class.


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;

            if (counter == max_counter)
                counter = 0;

            float coef = (float)y[counter++];
            
            vg.color.Override(new Color(coef, coef, coef, 1));
        }
    }
}
