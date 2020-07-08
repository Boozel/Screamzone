using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catapult : MonoBehaviour
{
    // Start is called before the first frame update
    float baseRotation = 0;
    float buildupRotation = 0;
    float accumulateLaunchSpeed = 0;
    bool launch = false;
    bool initialize = false;
    private Rigidbody rb;
    Vector3 m_EulerAngleVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotate = MicInput.MicLoudness;

        if(launch == false)
        {
            buildupRotation += rotate;

            if(rotate < 0.01 && initialize == true)
            {
                launch = true;
            }
            else
            {
                Vector3 m_EulerAngleVelocity = new Vector3(0, 0, buildupRotation*1.5f);
                //rb.AddTorque(0, 0, (buildupRotation));
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
                //gameObject.transform.eulerAngles = new Vector3(0, 0, buildupRotation);
            }

            if (initialize == false && gameObject.transform.eulerAngles.z >=10)
            {
                initialize = true;
            }
        }
        else
        {
            float releaseVal = 0;
            if (buildupRotation > baseRotation)
            {
                releaseVal = (int)buildupRotation / (int)10;
                accumulateLaunchSpeed += releaseVal;

                if(buildupRotation > 0)
                {
                    buildupRotation -= (buildupRotation / 10);
                    if(buildupRotation >0 && buildupRotation < 10)
                    {
                        buildupRotation = 0;
                    }
                }
            }

            if (gameObject.transform.eulerAngles.z >=100)
            {
                accumulateLaunchSpeed = 0;
            }
            //gameObject.transform.Rotate(0, 0, -(accumulateLaunchSpeed), Space.Self);
            Vector3 m_EulerAngleVelocity = new Vector3(0, 0, -accumulateLaunchSpeed*15);
            //rb.AddTorque(0, 0, (buildupRotation));
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
