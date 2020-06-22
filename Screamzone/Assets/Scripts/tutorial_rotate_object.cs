using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_rotate_object : MonoBehaviour
{
    // Start is called before the first frame update
    float baseRotation = -90;
    float buildupRotation = 0;
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0.0f, 1f, 0.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float rotate = MicInput.MicLoudness * 3;

        buildupRotation += rotate;

        if(buildupRotation >= 90)
        {
            buildupRotation = 90;
        }

        if(buildupRotation < 90)
        {
            if(rotate < 0.01)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, baseRotation);
                buildupRotation = 0;
            }
            else
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, baseRotation + buildupRotation);
            }
        }
        else
        {
            //Sometimes wouldn't rotate all the way flat
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
