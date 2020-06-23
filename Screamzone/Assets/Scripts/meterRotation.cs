using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meterRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* ROTATING THE POINTY THING

            We start at -90 deg ('r'). Straight up is 0 deg, and
            flat to the right is 90 deg. offering 180 degrees
            total.

            Our "dB Meter" ('d') runs from 0 (silence) to 1 (max decibels).

            This means each degree on our meter is equivalent to:
                r = (d * 180) - 90;
            
            The additional -90 is to normalize it with the default position (-90).
        */
        float rotate = (MicInput.MicLoudness * 180) + 180;
        gameObject.transform.eulerAngles = new Vector3(-rotate, -90, 90);
        Debug.Log(MicInput.MicLoudness);
    }
}
